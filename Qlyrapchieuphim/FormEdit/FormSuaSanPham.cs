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
using System.Windows.Controls;
using System.Windows.Forms;
namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaSanPham : Form
    {
        
        SqlConnection conn = null;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        string id;
        public FormSuaSanPham(string id = "")
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            this.id = id;
            pictureBox_FormSuaSanPham_Poster.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaSanPham_Load(object sender, EventArgs e)
        {
            date_FormSuaSanPham_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaSanPham_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormSuaSanPham_NgayNhap.Value = DateTime.Today;
            CheckCategories();
            LoadSanPhamByID(id);
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
        private bool CheckCategories()
        {
            int count;
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM ProductCategories";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                cb_FormSuaSanPham_LoaiSP.Enabled = true;

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
                cb_FormSuaSanPham_LoaiSP.DataSource = categories;
            }
            else
            {
                cb_FormSuaSanPham_LoaiSP.Enabled = false;

            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        private void LoadSanPhamByID(string id)
        {
            string query = "SELECT ProductName, Description, Price, ImageURL, CategoryID, Quantity, ImportDate, Manufacturer " +
                           "FROM Products WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = int.Parse(id);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_FormSuaSanPham_MaSP.Text = id;
                            lbl_FormSuaSanPham_TenSP.Text = reader["ProductName"].ToString();
                            lbl_FormSuaSanPham_MoTa.Text = reader["Description"].ToString();
                            lbl_FormSuaSanPham_GiaTien.Text = reader["Price"].ToString();
                            lbl_FormSuaSanPham_SoLuong.Text = reader["Quantity"].ToString();
                            lbl_FormSuaSanPham_NhaCungCap.Text = reader["Manufacturer"].ToString();

                            // Ngày nhập
                            if (reader["ImportDate"] != DBNull.Value)
                                date_FormSuaSanPham_NgayNhap.Value = Convert.ToDateTime(reader["ImportDate"]);

                            // Load ảnh nếu có
                            string imageUrl = reader["ImageURL"].ToString();
                            picture_url = imageUrl; // lưu lại đường dẫn hiện tại để so sánh sau nếu cần

                            string imagePath = Path.Combine(projectFolder, imageUrl);
                            if (File.Exists(imagePath))
                            {
                                using (var bmpTemp = new Bitmap(imagePath))
                                {
                                    pictureBox_FormSuaSanPham_Poster.Image = new Bitmap(bmpTemp);
                                }
                            }

                            // Gán lại selected index cho combobox Loại SP dựa trên CategoryID
                            int categoryId = Convert.ToInt32(reader["CategoryID"]);
                            for (int i = 0; i < cb_FormSuaSanPham_LoaiSP.Items.Count; i++)
                            {
                                string item = cb_FormSuaSanPham_LoaiSP.Items[i].ToString();
                                if (item.Contains($"ID: {categoryId}"))
                                {
                                    cb_FormSuaSanPham_LoaiSP.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btn_FormSuaSanPham_CapNhat_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(lbl_FormSuaSanPham_TenSP.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaSanPham_GiaTien.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaSanPham_SoLuong.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int so;
            double gia;
            if ((!int.TryParse(lbl_FormSuaSanPham_SoLuong.Text, out so)) || (!double.TryParse(lbl_FormSuaSanPham_GiaTien.Text, out gia)))
            {
                MessageBox.Show("Giá tiền và số lượng phải được nhập dưới dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
           



           
            // Update values in selected row
            string SqlQuery = "UPDATE Products SET " +
                "ProductName =  @ProductName, " +
                "Description = @Description, " +
                "Price = @Price, " +
                "ImageURL = @ImageURL, " +
                "CategoryID = @CategoryID, " +
                "Quantity = @Quantity, " +
                "ImportDate = @ImportDate, " +
                "Manufacturer = @Manufacturer " +
                "WHERE ProductID = @ProductID";
            int typeID = int.Parse(Helper.SubStringBetween(cb_FormSuaSanPham_LoaiSP.SelectedItem.ToString(), " (ID: ", ")"));

            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@ProductID", SqlDbType.Int).Value = int.Parse(id);
            comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormSuaSanPham_MoTa.Text; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = lbl_FormSuaSanPham_TenSP.Text;
            comm.Parameters.Add("@CategoryID", SqlDbType.Int).Value = typeID;
            comm.Parameters.Add("@Price", SqlDbType.Decimal).Value = gia;
            comm.Parameters.Add("@Quantity", SqlDbType.Int).Value = so;
            comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = date_FormSuaSanPham_NgayNhap.Value; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = lbl_FormSuaSanPham_NhaCungCap.Text;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            SaveImage(int.Parse(id));
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                this.Close();
                this.DialogResult = DialogResult.OK;
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
                        break;
                    default:
                        throw;
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        private void SaveImage(int identity)
        {
            try
            {
                if (pictureBox_FormSuaSanPham_Poster.Image == null)
                {
                    pictureBox_FormSuaSanPham_Poster.Image = SystemIcons.Error.ToBitmap();
                    return;
                }

                string newFolderPath = Path.Combine(projectFolder, "product_images");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                // Fix tên file
                ImageFormat imageFormat = pictureBox_FormSuaSanPham_Poster.Image.RawFormat;
                string fileName = $"product_{int.Parse(id)}" + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
                string fullPath = Path.Combine(newFolderPath, fileName);

                // So sánh nếu ảnh đã tồn tại
                if (File.Exists(fullPath))
                {
                    using (MemoryStream newImageStream = new MemoryStream())
                    using (MemoryStream existingImageStream = new MemoryStream(File.ReadAllBytes(fullPath)))
                    {
                        pictureBox_FormSuaSanPham_Poster.Image.Save(newImageStream, ImageFormat.Png);
                        byte[] newImageBytes = newImageStream.ToArray();
                        byte[] existingImageBytes = existingImageStream.ToArray();

                        if (newImageBytes.SequenceEqual(existingImageBytes))
                        {
                            // Ảnh không đổi => bỏ qua
                            return;
                        }
                    }

                    File.Delete(fullPath);
                }

                // Lưu ảnh mới (dùng ImageFormat.Png thay vì RawFormat)
                using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    Bitmap img = new Bitmap(pictureBox_FormSuaSanPham_Poster.Image);
                    img.Save(stream, ImageFormat.Png); // Không còn lỗi encoder
                    picture_url = Path.Combine("product_images", fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

            //lbl_FormSuaSanPham_MaSP.Clear();
            //lbl_FormSuaSanPham_TenSP.Clear();
            //cb_FormSuaSanPham_LoaiSP.SelectedIndex = -1;
            //lbl_FormSuaSanPham_GiaTien.Clear();
            //lbl_FormSuaSanPham_SoLuong.Clear();
            //lbl_FormSuaSanPham_NhaCungCap.Clear();
            //date_FormSuaSanPham_NgayNhap.Value = DateTime.Today;
            //lbl_FormSuaSanPham_MoTa.Clear();
            //pictureBox_FormSuaSanPham_Poster.Image = null;
            //this.Refresh();


            LoadSanPhamByID(id);
        }

        private void btn_FormSuaSanPham_ThemPoster_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm poster cho sản phẩm
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
                            pictureBox_FormSuaSanPham_Poster.Image = System.Drawing.Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
