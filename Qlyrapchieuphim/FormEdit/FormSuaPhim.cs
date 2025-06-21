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
        }
        private string movieId;

public FormSuaPhim(string id)
{
    InitializeComponent();
    movieId = id;
}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection conn = null;

        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private void FormSuaPhim_Load(object sender, EventArgs e)
        {
            date_FormSuaPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormSuaPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";

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

                        if (reader["ReleaseDate"] != DBNull.Value)
                            date_FormSuaPhim_NgayPhatHanh.Value = Convert.ToDateTime(reader["ReleaseDate"]);

                        if (reader["ImportDate"] != DBNull.Value)
                            date_FormSuaPhim_NgayNhap.Value = Convert.ToDateTime(reader["ImportDate"]);

                        lbl_FormSuaPhim_NhaPhatHanh.Text = reader["Manufacturer"].ToString();

                        // Load PosterURL nếu cần
                        poster_url = reader["PosterURL"].ToString();
                        string imagePath = Path.Combine(projectFolder, "posters", movieId + ".png");
                        if (File.Exists(imagePath))
                        {
                            using (var temp = Image.FromFile(imagePath))
                            {
                                pictureBox_FormSuaPhim_Poster.Image = new Bitmap(temp); // tạo bản sao -> không giữ file
                            }
                        }
                    }
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(lbl_FormSuaPhim_TenPhim.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaPhim_ThoiLuong.Text) ||
                string.IsNullOrWhiteSpace(cb_FormSuaPhim_TinhTrang.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaPhim_MoTa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thời lượng phải là số
            if (!int.TryParse(lbl_FormSuaPhim_ThoiLuong.Text, out int duration))
            {
                MessageBox.Show("Thời lượng phải được nhập dưới dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài mô tả
            if (lbl_FormSuaPhim_MoTa.Text.Length > 512)
            {
                MessageBox.Show("Mô tả không quá 512 ký tự!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra movieId hợp lệ
            if (!int.TryParse(movieId, out int id))
            {
                MessageBox.Show("Mã phim không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu ảnh trước khi cập nhật
            SaveImage(id);

            // Kiểm tra poster_url hợp lệ
            if (string.IsNullOrEmpty(poster_url))
            {
                MessageBox.Show("Poster chưa được chọn hoặc lưu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuẩn bị câu lệnh SQL
            string SqlQuery = "UPDATE Movies SET " +
                "Title = @Title, " +
                "Genre = @Genre, " +
                "Duration = @Duration, " +
                "Description = @Description, " +
                "PosterURL = @PosterURL, " +
                "Status = @Status, " +
                "ReleaseDate = @ReleaseDate, " +
                "ImportDate = @ImportDate, " +
                "Manufacturer = @Manufacturer " +
                "WHERE MovieID = @MovieID";

            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);

            using (SqlCommand comm = new SqlCommand(SqlQuery, conn))
            {
                // Truyền tham số
                comm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = lbl_FormSuaPhim_TenPhim.Text;
                comm.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = cb_FormSuaPhim_TheLoai.Text;
                comm.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;
                comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormSuaPhim_MoTa.Text;
                comm.Parameters.Add("@PosterURL", SqlDbType.VarChar).Value = poster_url;
                comm.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cb_FormSuaPhim_TinhTrang.Text;
                comm.Parameters.Add("@ReleaseDate", SqlDbType.Date).Value = date_FormSuaPhim_NgayPhatHanh.Value;
                comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = date_FormSuaPhim_NgayNhap.Value;
                comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = lbl_FormSuaPhim_NhaPhatHanh.Text;
                comm.Parameters.Add("@MovieID", SqlDbType.Int).Value = id;

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Đã xảy ra lỗi khi cập nhật phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveImage(int identity)
        {
            try
            {
                // 1. Kiểm tra xem PictureBox có hình ảnh không
                if (pictureBox_FormSuaPhim_Poster == null)
                {
                    pictureBox_FormSuaPhim_Poster.Image = SystemIcons.Error.ToBitmap();
                    return;
                }

                // 2. Tạo đường dẫn đến thư mục "New folder" trong thư mục dự án

                string newFolderPath = Path.Combine(projectFolder, "posters");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                // 3. Tạo tên file hình ảnh (ví dụ: image.png)
                ImageFormat imageFormat = pictureBox_FormSuaPhim_Poster.Image.RawFormat;
                string fileName = identity.ToString() + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
                string fullPath = Path.Combine(newFolderPath, fileName);
                //delete if existing
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                // 4. Lưu hình ảnh từ PictureBox vào thư mục
                using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    //take image format and save in that format
                    Bitmap img = new Bitmap(pictureBox_FormSuaPhim_Poster.Image);
                    img.Save(stream, imageFormat);
                    poster_url = Path.Combine("posters", fileName);
                }

                //MessageBox.Show("Hình ảnh đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_FormSuaPhim_ThemPoster_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo hộp thoại chọn file
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Chỉ cho phép chọn file hình ảnh
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    openFileDialog.Title = "Chọn hình ảnh";

                    // Kiểm tra xem người dùng có chọn file không
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy đường dẫn file hình ảnh
                        string filePath = openFileDialog.FileName;

                        // Hiển thị hình ảnh trong PictureBox
                        using (FileStream stream = new FileStream(filePath, FileMode.Open))
                        {
                            pictureBox_FormSuaPhim_Poster.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_FormSuaPhim_Poster_Click(object sender, EventArgs e)
        {

        }
    }
}
