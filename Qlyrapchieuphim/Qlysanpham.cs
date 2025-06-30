using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Drawing.Imaging;
using Qlyrapchieuphim.FormEdit;

namespace Qlyrapchieuphim
{

    public partial class Qlysanpham : UserControl
    {
        SqlConnection conn = null;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        public Qlysanpham()
        {
            InitializeComponent();
            //masp.MaxLength = 4;
            ten.MaxLength = 50;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            masp.Enabled = false;
        }
        private void LoadData()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT ProductID, ProductName, Description, Price, ImageURL, pr.CategoryID, Quantity, ImportDate, Manufacturer, CategoryName " +
                "FROM Products pr JOIN ProductCategories pc ON (pr.CategoryID = pc.CategoryID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            DataTable dt = ds.Tables["Products"];
            dataGridView1.DataSource = dt;
            if (!dataGridView1.Columns.Contains("Actions"))
            {
                DataGridViewTextBoxColumn actionCol = new DataGridViewTextBoxColumn();
                actionCol.Name = "Actions";
                actionCol.HeaderText = "Actions";
                actionCol.Width = 60;
                dataGridView1.Columns.Add(actionCol);
            }

            dataGridView1.Columns["Actions"].DisplayIndex = dataGridView1.Columns.Count - 1;
            conn.Close();
            this.Refresh();
        }
        private bool CheckCategories()
        {
            int count;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM ProductCategories";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                loai.Enabled = true;
                errorProvider3.Clear();
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
                loai.DataSource = categories;
            }
            else
            {
                loai.Enabled = false;
                errorProvider3.SetError(loai, "Không có loại sản phẩm nào trong hệ thống!");
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        private void Qlysanpham_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            LoadData();
            CheckCategories();
            loai.SelectedIndex = 0;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox4.Text = "Tìm kiếm theo tên";
            guna2TextBox4.ForeColor = Color.Gray;
            dataGridView1.RowTemplate.Height = 45;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e) // soluong
        {
            if (!int.TryParse(soluong.Text, out _) && !string.IsNullOrEmpty(soluong.Text))
            {
                errorProvider1.SetError(soluong, "Phải là số nguyên.");
            }
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (//string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(ten.Text) ||
               string.IsNullOrWhiteSpace(giatien.Text) ||
               string.IsNullOrWhiteSpace(soluong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int so;
            double gia;
            if ((!int.TryParse(soluong.Text, out so)) || (!double.TryParse(giatien.Text, out gia)))
            {
                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string SqlQuery = "INSERT INTO Products OUTPUT INSERTED.ProductID VALUES (@ProductName, @Description, @Price, @ImageURL, @CategoryID, @Quantity, @ImportDate, @Manufacturer)";
            int typeID = int.Parse(Helper.SubStringBetween(loai.SelectedItem.ToString(), " (ID: ", ")"));

            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = "placeholder"; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ten.Text;
            comm.Parameters.Add("@CategoryID", SqlDbType.Int).Value = typeID;
            comm.Parameters.Add("@Price", SqlDbType.Decimal).Value = gia;
            comm.Parameters.Add("@Quantity", SqlDbType.Int).Value = so;
            comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = DateTime.Today - TimeSpan.FromDays(180); //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = "placeholder";//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            int prID;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                prID = int.Parse(comm.ExecuteScalar().ToString());
                conn.Close();
                SaveImage(prID);
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
            SqlQuery = "UPDATE Products SET " +
                "ImageURL = @ImageURL " +
                "WHERE ProductID = @ProductID ";
            comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            comm.Parameters.Add("@ProductID", SqlDbType.Int).Value = prID;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            LoadData();
            Updatea();

        }
        private void PrintToTextBoxes(int row)
        {
            // Lấy thông tin của dòng được chọn
            DataTable dt = dataGridView1.DataSource as DataTable;

            // Gán giá trị cho các TextBox
            masp.Text = dt.Rows[row]["ProductID"].ToString();
            masp.Enabled = false;
            ten.Text = dt.Rows[row]["ProductName"].ToString();
            loai.SelectedItem = dt.Rows[row]["CategoryName"] + " (ID:" + dt.Rows[row]["CategoryID"] + ")";
            giatien.Text = dt.Rows[row]["Price"].ToString();
            soluong.Text = dt.Rows[row]["Quantity"].ToString();
            string relative_picture_path = dt.Rows[row]["ImageURL"].ToString();
            picture_url = Path.Combine(projectFolder, relative_picture_path);
            try
            {
                using (FileStream stream = new FileStream(picture_url, FileMode.Open))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(relative_picture_path))
                {
                    switch (ex.GetType().ToString())
                    {
                        case "FileNotFoundException":
                            MessageBox.Show(
                            "Không tìm thấy file ảnh với đường dẫn tương ứng.",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                        case "DirectoryNotFoundException":
                            MessageBox.Show(
                            "Không tìm thấy thư mục với đường dẫn tương ứng.",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show(
                            "Lỗi dữ liệu!",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes(e.RowIndex);

            }

            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                // Tính vị trí click so với ô
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dataGridView1.PointToClient(Cursor.Position).X - cellRect.X;

                int iconSize = 32;
                int padding = 8;
                int editLeft = padding;
                int deleteLeft = editLeft + iconSize + padding;

                if (clickX >= editLeft && clickX < editLeft + iconSize)
                {
                    DataTable dt = dataGridView1.DataSource as DataTable;

                    // Gán giá trị cho các TextBox

                    String id = dt.Rows[e.RowIndex]["ProductID"].ToString();

                    // 👉 Click icon Edit
                    using (FormSuaSanPham popup = new FormSuaSanPham(id))
                    {
                        popup.StartPosition = FormStartPosition.CenterParent;

                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData(); // Chỉ gọi nếu form kia trả về OK
                        }

                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    int productId = Convert.ToInt32(dt.Rows[e.RowIndex]["ProductID"]);

                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa sản phẩm có ID {productId} không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Products WHERE ProductID = @ProductID";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", productId);

                            try
                            {
                                if (conn.State != ConnectionState.Open)
                                    conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                conn.Close();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Optional: Xóa file ảnh nếu tồn tại
                                    string imagePath = Path.Combine(projectFolder, dt.Rows[e.RowIndex]["ImageURL"].ToString());
                                    if (File.Exists(imagePath))
                                    {
                                        File.Delete(imagePath);
                                    }

                                    LoadData(); // Cập nhật lại danh sách
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                conn.Close();
                                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

            }
        }

        private void capnhat_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(ten.Text) ||
               string.IsNullOrWhiteSpace(giatien.Text) ||
               string.IsNullOrWhiteSpace(soluong.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int so;
            double gia;
            if ((!int.TryParse(soluong.Text, out so)) || (!double.TryParse(giatien.Text, out gia)))
            {
                MessageBox.Show("Giá tiền và số lượng phải được nhập dưới dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }




            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

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
            int typeID = int.Parse(Helper.SubStringBetween(loai.SelectedItem.ToString(), " (ID: ", ")"));

            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@ProductID", SqlDbType.Int).Value = int.Parse(masp.Text);
            comm.Parameters.Add("@Description", SqlDbType.NVarChar).Value = "placeholder"; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ten.Text;
            comm.Parameters.Add("@CategoryID", SqlDbType.Int).Value = typeID;
            comm.Parameters.Add("@Price", SqlDbType.Decimal).Value = gia;
            comm.Parameters.Add("@Quantity", SqlDbType.Int).Value = so;
            comm.Parameters.Add("@ImportDate", SqlDbType.Date).Value = DateTime.Today - TimeSpan.FromDays(180); //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            comm.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = "placeholder";//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            SaveImage(int.Parse(masp.Text));
            comm.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = picture_url;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                LoadData();
                Updatea();
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

        private void xoa_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["ProductID"].ToString();
                        string SqlQuery = "DELETE FROM Products WHERE ProductID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                        string relative_picture_path = dt.Rows[selected]["ImageURL"].ToString();
                        string fullPath = Path.Combine(projectFolder, relative_picture_path);
                        if (File.Exists(fullPath))
                            File.Delete(fullPath);
                    }
                    conn.Close();
                    LoadData();
                    Updatea();

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        void Updatea()
        {
            CheckCategories();
            masp.Clear();
            masp.Enabled = false;
            ten.Clear();
            loai.SelectedIndex = 0;
            giatien.Clear();
            soluong.Clear();
            dataGridView1.ClearSelection();
            pictureBox1.Image = null;
            picture_url = string.Empty;
            this.Refresh();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox4.Text.ToLower();
                string tenSV = " ";
                DataTable dt = dataGridView1.DataSource as DataTable;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        tenSV = dt.Rows[index]["ProductName"].ToString().ToLower();
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager.SuspendBinding();
                        if (tenSV.Contains(tenCanTim))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                        currencyManager.ResumeBinding();
                    }
                }
            }
        }

        private void guna2TextBox4_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox4.Text = "";

                guna2TextBox4.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox4.Text))
            {
                guna2TextBox4.Text = "Tìm kiếm theo tên";
                guna2TextBox4.ForeColor = Color.Gray;

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
        }

        private void giatien_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(giatien.Text, out _) && !string.IsNullOrEmpty(giatien.Text))
            {
                errorProvider2.SetError(giatien, "Phải là số thực.");
            }
        }
        private void SaveImage(int identity)
        {
            try
            {
                // 1. Kiểm tra xem PictureBox có hình ảnh không
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = SystemIcons.Error.ToBitmap();
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
                ImageFormat imageFormat = pictureBox1.Image.RawFormat;
                string fileName = masp.Text + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
                string fullPath = Path.Combine(newFolderPath, fileName);
                //delete if existing
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
                // 4. Lưu hình ảnh từ PictureBox vào thư mục
                using (FileStream stream = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite))
                {

                    //take image format and save in that format
                    Bitmap img = new Bitmap(pictureBox1.Image);
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
        private void themanh_Click(object sender, EventArgs e)
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
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemSanPham popup = new FormThemSanPham())
            {
                popup.StartPosition = FormStartPosition.CenterParent;

                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData(); // Chỉ gọi nếu form kia trả về OK
                }

            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                // Tọa độ vẽ
                int iconSize = 32;
                int padding = 8;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                int editX = e.CellBounds.X + padding;
                int deleteX = editX + iconSize + padding;

                // Vẽ icon Sửa
                e.Graphics.DrawImage(Properties.Resources.icons8_edit_32, new Rectangle(editX, iconY, iconSize, iconSize));
                // Vẽ icon Xóa
                e.Graphics.DrawImage(Properties.Resources.icons8_delete_32, new Rectangle(deleteX, iconY, iconSize, iconSize));
            }
        }

        private void loai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
