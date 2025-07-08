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
namespace Qlyrapchieuphim
{
    public partial class FormThemSanPham : Form
    {
        int prID;
        public FormThemSanPham()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            pictureBox_ThemSanPham_Poster.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection conn = null;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private void FormThemSanPham_Load(object sender, EventArgs e)
        {
            date_ThemSanPham_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_ThemSanPham_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_ThemSanPham_NgayNhap.Value = DateTime.Today;
            CheckCategories();
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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_ThemSanPham_TenSP.Clear();
            cb_ThemSanPham_LoaiSP.SelectedIndex = -1;
            lbl_ThemSanPham_GiaTien.Clear();
            lbl_ThemSanPham_SoLuong.Clear();
            lbl_ThemSanPham_NhaCungCap.Clear();
            date_ThemSanPham_NgayNhap.Value = DateTime.Today;
            lbl_ThemSanPham_MoTa.Clear();
            pictureBox_ThemSanPham_Poster.Image = null;
            this.Refresh();
        }
        private void them_Click(object sender, EventArgs e)
        {
            if (//string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(lbl_ThemSanPham_TenSP.Text) ||
               string.IsNullOrWhiteSpace(lbl_ThemSanPham_GiaTien.Text) ||
               string.IsNullOrWhiteSpace(lbl_ThemSanPham_SoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int so;
            double gia;
            if ((!int.TryParse(lbl_ThemSanPham_SoLuong.Text, out so)) || (!double.TryParse(lbl_ThemSanPham_GiaTien.Text, out gia)))
            {
                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string SqlQuery = "INSERT INTO Products OUTPUT INSERTED.ProductID VALUES (@ProductName, @Description, @Price, @ImageURL, @CategoryID, @Quantity, @ImportDate, @Manufacturer)";
            int typeID = int.Parse(Helper.SubStringBetween(cb_ThemSanPham_LoaiSP.SelectedItem.ToString(), " (ID: ", ")"));

            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value =lbl_ThemSanPham_MoTa.Text; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = lbl_ThemSanPham_TenSP.Text;
            comm.Parameters.Add("@CategoryID", SqlDbType.Int).Value = typeID;
            comm.Parameters.Add("@Price", SqlDbType.Decimal).Value = gia;
            comm.Parameters.Add("@Quantity", SqlDbType.Int).Value = so;
            comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = date_ThemSanPham_NgayNhap.Value; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value =lbl_ThemSanPham_NhaCungCap.Text;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            
            try
            {
                conn.Open();
                prID = int.Parse(comm.ExecuteScalar().ToString());
                conn.Close();
                SaveImage(prID);
                this.Close();
                this.DialogResult = DialogResult.OK;

            }



            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "ID sản phẩm không được trùng nhau!",
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
            SqlQuery = "UPDATE Products SET " +
                "ImageURL = @ImageURL " +
                "WHERE ProductID = @ProductID ";
            comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            comm.Parameters.Add("@ProductID", SqlDbType.Int).Value = prID;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        private bool CheckCategories()
        {
            int count;
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM ProductCategories";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
               cb_ThemSanPham_LoaiSP.Enabled = true;
               
                SqlQuery = "SELECT CategoryID, CategoryName FROM ProductCategories";
                string[] categories = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    categories[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
                    i++;
                }
                cb_ThemSanPham_LoaiSP.DataSource = categories;
            }
            else
            {
                cb_ThemSanPham_LoaiSP.Enabled = false;
               
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        private void btn_ThemSanPham_Poster_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý chọn hình ảnh cho sản phẩm
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
                            pictureBox_ThemSanPham_Poster.Image = Image.FromStream(stream);
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
                if (pictureBox_ThemSanPham_Poster.Image == null)
                {
                    pictureBox_ThemSanPham_Poster.Image = SystemIcons.Error.ToBitmap();
                    return;
                }

                // 2. Tạo đường dẫn đến thư mục "New folder" trong thư mục dự án

                string newFolderPath = Path.Combine(projectFolder, "product_images");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                // 3. Tạo tên file hình ảnh (ví dụ: image.png)
                ImageFormat imageFormat = pictureBox_ThemSanPham_Poster.Image.RawFormat;
                string fileName = $"product_{prID}"  + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
                string fullPath = Path.Combine(newFolderPath, fileName);
                //delete if existing
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                // 4. Lưu hình ảnh từ PictureBox vào thư mục
                using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
                {

                    //take image format and save in that format
                    Bitmap img = new Bitmap(pictureBox_ThemSanPham_Poster.Image);
                    img.Save(stream, imageFormat);
                    picture_url = Path.Combine("product_images", fileName);
                }

                //MessageBox.Show("Hình ảnh đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.ToString()}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
