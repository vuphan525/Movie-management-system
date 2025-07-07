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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Qlyrapchieuphim
{
    public partial class FormThemPhim : Form
    {
        public FormThemPhim()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            pictureBox_FormThemPhim_Poster.SizeMode = PictureBoxSizeMode.Zoom;
        }
        SqlConnection conn = null;

        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private void FormThemPhim_Load(object sender, EventArgs e)
        {
            date_FormThemPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormThemPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormThemPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormThemPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            if (/*string.IsNullOrWhiteSpace(idphim.Text) ||*/
               string.IsNullOrWhiteSpace(lbl_FormThemPhim_TenPhim.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemPhim_NhaPhatHanh.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemPhim_ThoiLuong.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemPhim_MoTa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lbl_FormThemPhim_ThoiLuong.Text, out _))
            {
                // Hiển thị MessageBox nếu không phải là số
                MessageBox.Show(
                    "Thời lượng phải được nhập dươi dạng một số nguyên!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (lbl_FormThemPhim_MoTa.Text.Length > 512)
            {
                MessageBox.Show(
                    "Mô tả không quá 512 ký tự!!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            //poster
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);

            string SqlQuery = "INSERT INTO Movies OUTPUT INSERTED.MovieID VALUES (@Title, @Description, @Duration, @PosterURL, @Genre, @Status, @ReleaseDate, @ImportDate, @Manufacturer)";
            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            //comm.Parameters.Add("@MovieID", SqlDbType.Int).Value = idphim.Text;
            comm.Parameters.Add("@Title", SqlDbType.NVarChar).Value = lbl_FormThemPhim_TenPhim.Text;
            comm.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = cb_FormThemPhim_TheLoai.Text;
            comm.Parameters.Add("@Duration", SqlDbType.Int).Value = int.Parse(lbl_FormThemPhim_ThoiLuong.Text);
            comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormThemPhim_MoTa.Text;
            comm.Parameters.Add("@Status", SqlDbType.NVarChar).Value =cb_FormThemPhim_TinhTrang.Text;
            comm.Parameters.Add("@ReleaseDate", SqlDbType.Date).Value = date_FormThemPhim_NgayPhatHanh.Value.ToString(); //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = date_FormThemPhim_NgayNhap.Value.ToString(); //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = lbl_FormThemPhim_NhaPhatHanh.Text; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@PosterURL", SqlDbType.VarChar).Value = poster_url;
            int mvID;
            try
            { 
                conn.Open();
                mvID = int.Parse(comm.ExecuteScalar().ToString());
                conn.Close();
                SaveImage(mvID);
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "ID phim không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            SqlQuery = "UPDATE MOVIES SET " +
                "PosterURL = @PosterURL " +
                "WHERE MovieID = @MovieID ";
            comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@PosterURL", SqlDbType.VarChar).Value = poster_url;
            comm.Parameters.Add("@MovieID", SqlDbType.Int).Value = mvID;
            conn.Open();
            comm.ExecuteNonQuery();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();

            //ToDo: Xử lý thêm phim 

        }

        private void AddPosterButton_Click(object sender, EventArgs e)
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
                            pictureBox_FormThemPhim_Poster.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SaveImage(int identity)
        {
            try
            {
                // 1. Kiểm tra xem PictureBox có hình ảnh không
                if (pictureBox_FormThemPhim_Poster.Image == null)
                {
                    pictureBox_FormThemPhim_Poster.Image = SystemIcons.Error.ToBitmap();
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
                ImageFormat imageFormat = pictureBox_FormThemPhim_Poster.Image.RawFormat;
                string fileName = identity.ToString() + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
                string fullPath = Path.Combine(newFolderPath, fileName);
                //delete if existing
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                // 4. Lưu hình ảnh từ PictureBox vào thư mục
                using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    //take image format and save in that format
                    Bitmap img = new Bitmap(pictureBox_FormThemPhim_Poster.Image);
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void lbl_FormThemPhim_MoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_FormThemPhim_MovieID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_FormThemPhim_TheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void date_FormThemPhim_NgayNhap_ValueChanged(object sender, EventArgs e)
        {
        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemPhim_TenPhim.Clear();
            cb_FormThemPhim_TheLoai.SelectedIndex = -1;
            lbl_FormThemPhim_ThoiLuong.Clear();
            cb_FormThemPhim_TinhTrang.SelectedIndex = -1;
            date_FormThemPhim_NgayNhap.Value = DateTime.Now;
            date_FormThemPhim_NgayPhatHanh.Value = DateTime.Now;
            lbl_FormThemPhim_NhaPhatHanh.Clear();
            lbl_FormThemPhim_MoTa.Clear();
            pictureBox_FormThemPhim_Poster.Image = null; // Assuming guna2PictureBox1 is the picture box for the poster
            this.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
