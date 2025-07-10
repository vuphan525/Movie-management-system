using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaPhim : Form
    {
        public FormSuaPhim()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            pictureBox_FormSuaPhim_Poster.SizeMode = PictureBoxSizeMode.Zoom;
            lbl_FormSuaPhim_MoTa.MaxLength = 512;
            cb_FormSuaPhim_TinhTrang.Enabled = false;
        }

        private string movieId;
        bool isTimeChanging = false;
        public FormSuaPhim(string id)
        {
            InitializeComponent();
            movieId = id;
            LoadMovieData(movieId);
            this.Paint += FormThemPhim_Paint;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;

        private void FormSuaPhim_Load(object sender, EventArgs e)
        {
            date_FormSuaPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormSuaPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";
            isTimeChanging = true;
            date_FormSuaPhim_NgayNhap.Value = DateTime.Today;
            date_FormSuaPhim_NgayPhatHanh.Value = DateTime.Today;
            isTimeChanging = false;
            UpdateReleaseState();
            LoadMovieData(movieId);
        }

        private void FormThemPhim_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2;
            Color borderColor = Color.MediumSlateBlue;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(lbl_FormSuaPhim_TenPhim.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaPhim_ThoiLuong.Text) ||
                string.IsNullOrWhiteSpace(cb_FormSuaPhim_TinhTrang.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaPhim_MoTa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string SqlQuery = "UPDATE Movies SET " +
                "Title = @Title, " +
                "Genre = @Genre, " +
                "Duration = @Duration, " +
                "Description = @Description, " +
                "PosterURL = @PosterURL, " +
                "Status = @Status, " +
                "ReleaseDate = @ReleaseDate, " +
                "ImportDate = @ImportDate, " +
                "Manufacturer = @Manufacturer, " +
                "Price = @Price " +
                "WHERE MovieID = @MovieID";

            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlCommand comm = new SqlCommand(SqlQuery, conn))
            {
                comm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = lbl_FormSuaPhim_TenPhim.Text;
                comm.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = cb_FormSuaPhim_TheLoai.Text;
                comm.Parameters.Add("@Duration", SqlDbType.Int).Value = int.Parse(lbl_FormSuaPhim_ThoiLuong.Text);
                comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormSuaPhim_MoTa.Text;
                comm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cb_FormSuaPhim_TinhTrang.Text;
                comm.Parameters.Add("@ReleaseDate", SqlDbType.Date).Value = date_FormSuaPhim_NgayPhatHanh.Value;
                comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = date_FormSuaPhim_NgayNhap.Value;
                comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = cb_FormSuaPhim_NhaPhatHanh.SelectedItem.ToString();
                comm.Parameters.Add("@Price", SqlDbType.Decimal).Value = decimal.Parse(lbl_FormSuaPhim_Gia.Text);

                SaveImage(int.Parse(movieId));
                comm.Parameters.Add("@PosterURL", SqlDbType.VarChar).Value = poster_url;
                comm.Parameters.Add("@MovieID", SqlDbType.Int).Value = int.Parse(movieId);

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("ID phim không được trùng nhau!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveImage(int identity)
        {
            try
            {
                if (pictureBox_FormSuaPhim_Poster.Image == null)
                {
                    return;
                }

                string newFolderPath = Path.Combine(projectFolder, "posters");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                string fileName = identity.ToString() + ".png";
                string fullPath = Path.Combine(newFolderPath, fileName);

                byte[] newImageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox_FormSuaPhim_Poster.Image.Save(ms, ImageFormat.Png);
                    newImageBytes = ms.ToArray();
                }

                if (File.Exists(fullPath))
                {
                    byte[] existingBytes = File.ReadAllBytes(fullPath);
                    if (existingBytes.SequenceEqual(newImageBytes))
                    {
                        poster_url = Path.Combine("posters", fileName);
                        return;
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();

                File.WriteAllBytes(fullPath, newImageBytes);
                poster_url = Path.Combine("posters", fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMovieData(string movieId)
        {
            using (SqlConnection conn = Helper.getdbConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Movies WHERE MovieID = @MovieID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MovieID", SqlDbType.Char).Value = movieId;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbl_FormSuaPhim_TenPhim.Text = reader["Title"].ToString();
                        cb_FormSuaPhim_TheLoai.Text = reader["Genre"].ToString();
                        lbl_FormSuaPhim_ThoiLuong.Text = reader["Duration"].ToString();
                        lbl_FormSuaPhim_MoTa.Text = reader["Description"].ToString();
                        cb_FormSuaPhim_TinhTrang.Text = reader["Status"].ToString();
                        lbl_FormSuaPhim_Gia.Text = reader["Price"].ToString() ;
                        
                        isTimeChanging = true;
                        if (reader["ReleaseDate"] != DBNull.Value)
                            date_FormSuaPhim_NgayPhatHanh.Value = Convert.ToDateTime(reader["ReleaseDate"]);

                        if (reader["ImportDate"] != DBNull.Value)
                            date_FormSuaPhim_NgayNhap.Value = Convert.ToDateTime(reader["ImportDate"]);
                        isTimeChanging = false;
                        UpdateReleaseState();

                        cb_FormSuaPhim_NhaPhatHanh.SelectedItem = reader["Manufacturer"].ToString();

                        poster_url = reader["PosterURL"].ToString();
                        string imagePath = Path.Combine(projectFolder, "posters", movieId + ".png");
                        if (File.Exists(imagePath))
                        {
                            using (var img = new Bitmap(imagePath))
                            {
                                pictureBox_FormSuaPhim_Poster.Image = new Bitmap(img);
                            }
                        }
                    }
                }
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        private void btn_FormSuaPhim_ThemPoster_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    openFileDialog.Title = "Chọn hình ảnh";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        if (pictureBox_FormSuaPhim_Poster.Image != null)
                        {
                            pictureBox_FormSuaPhim_Poster.Image.Dispose();
                            pictureBox_FormSuaPhim_Poster.Image = null;
                        }

                        using (var original = new Bitmap(filePath))
                        {
                            pictureBox_FormSuaPhim_Poster.Image = new Bitmap(original);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi chọn ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaPhim_TenPhim.Clear();
            cb_FormSuaPhim_TheLoai.SelectedIndex = -1;
            lbl_FormSuaPhim_ThoiLuong.Clear();
            cb_FormSuaPhim_TinhTrang.SelectedIndex = -1;
            date_FormSuaPhim_NgayNhap.Value = DateTime.Today;
            date_FormSuaPhim_NgayPhatHanh.Value = DateTime.Today;
            cb_FormSuaPhim_NhaPhatHanh.SelectedIndex = 0;
            lbl_FormSuaPhim_MoTa.Clear();
            pictureBox_FormSuaPhim_Poster.Image = null;
            this.Refresh();
        }

        private void lbl_FormSuaPhim_Gia_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(lbl_FormSuaPhim_Gia.Text, out _))
            {
                errorProvider_Gia.SetError(lbl_FormSuaPhim_Gia, "Thời lượng phải được nhập dươi dạng một số thực!");
                AddButton.Enabled = false;
            }
            else
            {
                errorProvider_Gia.Clear();
                AddButton.Enabled = true;
            }
        }

        private void lbl_FormSuaPhim_ThoiLuong_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_FormSuaPhim_ThoiLuong.Text, out _))
            {
                errorProvider_ThoiLuong.SetError(lbl_FormSuaPhim_ThoiLuong, "Thời lượng phải được nhập dươi dạng một số nguyên!");
                AddButton.Enabled = false;
            }
            else
            {
                errorProvider_ThoiLuong.Clear();
                AddButton.Enabled = true;
            }
        }
        private void UpdateReleaseState()
        {
            if (date_FormSuaPhim_NgayPhatHanh.Value.Date <= DateTime.Today)
                cb_FormSuaPhim_TinhTrang.SelectedIndex = 0;
            else
                cb_FormSuaPhim_TinhTrang.SelectedIndex = 1;
        }
        private bool IsReleaseImportTimeValid()
        {
            return (date_FormSuaPhim_NgayPhatHanh.Value.Date >= date_FormSuaPhim_NgayNhap.Value.Date);
        }

        private void date_FormSuaPhim_NgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (isTimeChanging)
                return;
            if (!IsReleaseImportTimeValid())
            {
                MessageBox.Show(new Form() { TopMost = true },
                    "Ngày nhập phải từ ngày phát hành trở về trước!",
                    "Lỗi dữ liệu.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                date_FormSuaPhim_NgayNhap.Value = date_FormSuaPhim_NgayPhatHanh.Value.Date;
            }
            UpdateReleaseState();
        }

        private void date_FormSuaPhim_NgayPhatHanh_ValueChanged(object sender, EventArgs e)
        {
            if (isTimeChanging)
                return;
            if (!IsReleaseImportTimeValid())
            {
                MessageBox.Show(new Form() { TopMost = true },
                    "Ngày phát hành phải từ ngày nhập trở đi!",
                    "Lỗi dữ liệu.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                date_FormSuaPhim_NgayPhatHanh.Value = date_FormSuaPhim_NgayNhap.Value.Date;
            }
            UpdateReleaseState();
        }
    }
}
