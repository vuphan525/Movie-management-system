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

namespace Qlyrapchieuphim
{
    
    public partial class Qlysanpham : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        public Qlysanpham()
        {
            InitializeComponent();
            masp.MaxLength = 4;
            ten.MaxLength = 50;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MASP, TENSP, LOAI, GIA, SOLUONG, PICTUREPATH FROM SANPHAM";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SANPHAM");
            DataTable dt = ds.Tables["SANPHAM"];
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void Qlysanpham_Load(object sender, EventArgs e)
        {
            LoadData();
            loai.SelectedIndex = 0;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox4.Text = "Tìm kiếm theo tên";
            guna2TextBox4.ForeColor = Color.Gray;
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
            if ((!int.TryParse(soluong.Text, out so)) || (!double.TryParse(giatien.Text, out  gia)))
            {
                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            string SqlQuery = "INSERT INTO SANPHAM VALUES (@masp, @tensp, @loai, @gia, @sl, @path)";
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@masp", SqlDbType.Char).Value = masp.Text;
            comm.Parameters.Add("@tensp", SqlDbType.NVarChar).Value = ten.Text;
            comm.Parameters.Add("@loai", SqlDbType.NVarChar).Value = loai.Text;
            comm.Parameters.Add("@gia", SqlDbType.Float).Value = gia;
            comm.Parameters.Add("@sl", SqlDbType.Int).Value = so;
            SaveImage();
            comm.Parameters.Add("@path", SqlDbType.VarChar).Value = picture_url;
            try
            {
                comm.ExecuteNonQuery();
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
            conn.Close();

            
        }
        private void PrintToTextBoxes(int row)
        {
            // Lấy thông tin của dòng được chọn
            DataTable dt = dataGridView1.DataSource as DataTable;

            // Gán giá trị cho các TextBox
            masp.Text = dt.Rows[row]["MASP"].ToString();
            masp.Enabled = false;
            ten.Text = dt.Rows[row]["TENSP"].ToString();
            loai.SelectedItem = dt.Rows[row]["LOAI"].ToString();
            giatien.Text = dt.Rows[row]["GIA"].ToString();
            soluong.Text = dt.Rows[row]["SOLUONG"].ToString();
            string relative_picture_path = dt.Rows[row]["PICTUREPATH"].ToString();
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
                    if (ex is FileNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy file ảnh.",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    if (ex is DirectoryNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy folder ảnh",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        pictureBox1.Image =  null;
                    }
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes(e.RowIndex);
                
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
                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!",
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
            string SqlQuery = "UPDATE SANPHAM SET " +
                "TENSP =  @tensp, " +
                "LOAI = @loai, " +
                "GIA = @gia, " +
                "SOLUONG = @sl, " +
                "PICTUREPATH = @path " +
                "WHERE MASP = @masp";
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@masp", SqlDbType.Char).Value = masp.Text;
            comm.Parameters.Add("@tensp", SqlDbType.NVarChar).Value = ten.Text;
            comm.Parameters.Add("@loai", SqlDbType.NVarChar).Value = loai.Text;
            comm.Parameters.Add("@gia", SqlDbType.Float).Value = gia;
            comm.Parameters.Add("@sl", SqlDbType.Int).Value = so;
            SaveImage();
            comm.Parameters.Add("@path", SqlDbType.VarChar).Value = picture_url;
            try
            {
                comm.ExecuteNonQuery();
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
            conn.Close();



        }

        private void xoa_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    SqlConnection conn = new SqlConnection(ConnString);
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["MASP"].ToString();
                        string SqlQuery = "DELETE FROM SANPHAM WHERE MASP = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                        string relative_picture_path = dt.Rows[selected]["PICTUREPATH"].ToString();
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
            masp.Clear();
            masp.Enabled = true;
            ten.Clear();
            loai.SelectedIndex = 0;
            giatien.Clear();
            soluong.Clear();
            dataGridView1.ClearSelection();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox4.Text.ToLower();
                string tenSV = " ";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[2].Value != null)
                        {
                            tenSV = row.Cells[2].Value.ToString().ToLower();

                        }
                        else
                        {

                            MessageBox.Show(" Không có dữ liệu trong bảng!");
                        }

                        if (tenSV.Contains(tenCanTim))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
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
            if (!int.TryParse(giatien.Text, out _) && !string.IsNullOrEmpty(giatien.Text))
            {
                errorProvider2.SetError(giatien, "Phải là số nguyên.");
            }
        }
        private void SaveImage()
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

                string newFolderPath = Path.Combine(projectFolder, "food&drinks");

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
                    picture_url = Path.Combine("food&drinks", fileName);
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
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void them_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(ten.Text) ||

               string.IsNullOrWhiteSpace(giatien.Text) ||
               string.IsNullOrWhiteSpace(soluong.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((!int.TryParse(soluong.Text, out int so)) && (!double.TryParse(giatien.Text, out double gia)))
            {

                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (!int.TryParse(soluong.Text, out int he))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Số lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!double.TryParse(giatien.Text, out double hea))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giá tiền  phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int a = ConvertStringToInteger(giatien.Text);
            int b = ConvertStringToInteger(soluong.Text);
            string hj = b.ToString("D2");
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), masp.Text, ten.Text, loai.Text, a+" VND",hj);

            Updatea();
        }

        int ConvertStringToInteger(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                // Xử lý trường hợp không hợp lệ (ví dụ: thông báo lỗi)
                return 0; // Hoặc một giá trị mặc định khác
            }
        }
        string RemoveVND(string input)
        {
            return input.Replace("VND", "");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                masp.Text = row.Cells[1].Value.ToString();
                ten.Text = row.Cells[2].Value.ToString();
                loai.Text = row.Cells[3].Value.ToString();
                giatien.Text = RemoveVND(row.Cells[4].Value.ToString());
                soluong.Text = row.Cells[5].Value.ToString();
                
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
            if ((!int.TryParse(soluong.Text, out int so)) && (!double.TryParse(giatien.Text, out double gia)))
            {
                
                    MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                
                
            }
            else
            {
                if (!int.TryParse(soluong.Text, out int he))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Số lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!double.TryParse(giatien.Text, out double hea))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giá tiền  phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            


               
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row
            int a = ConvertStringToInteger(giatien.Text);
            int b = ConvertStringToInteger(soluong.Text);
            string hj = b.ToString("D2");
          
            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = masp.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = ten.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = loai.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = a+" VND";
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = hj;
            Updatea();
         
           

        }

        private void xoa_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    CapNhatSTT();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Updatea();
            
        }
        void Updatea()
        {
            masp.Clear();
            ten.Clear();
            loai.SelectedIndex = 0;
            giatien.Clear();
            soluong.Clear();
            dataGridView1.ClearSelection();


        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox4.Text.ToLower();
                string tenSV = " ";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[2].Value != null)
                        {
                            tenSV = row.Cells[2].Value.ToString().ToLower();

                        }
                        else
                        {

                            MessageBox.Show(" Không có dữ liệu trong bảng!");
                        }

                        if (tenSV.Contains(tenCanTim))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
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
    }
}
