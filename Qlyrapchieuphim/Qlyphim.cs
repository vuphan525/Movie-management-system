using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using Qlyrapchieuphim.FormEdit;


namespace Qlyrapchieuphim
{
    public partial class Qlyphim : UserControl
    {
        
        public Qlyphim()
        {
            InitializeComponent();  
            idphim.MaxLength = 4;
            tenphim.MaxLength = 100;
            dataGridView1.ReadOnly = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        string ConnString = Program.ConnString;
        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "select MAPHIM, TENPHIM, THELOAI, THOILUONG, MOTA, DANGCHIEU, POSTER_URL from BOPHIM";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "BOPHIM");
            DataTable dt = ds.Tables["BOPHIM"];
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
            
        }

        
        private void AddButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(idphim.Text) ||
                string.IsNullOrWhiteSpace(tenphim.Text) ||
                string.IsNullOrWhiteSpace(thoiluong.Text) ||
                string.IsNullOrWhiteSpace(trangthai.Text) ||
                string.IsNullOrWhiteSpace(mota.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(thoiluong.Text, out _))
            {
                // Hiển thị MessageBox nếu không phải là số
                MessageBox.Show(
                    "Thời lượng phải được nhập dươi dạng một số thực!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (mota.Text.Length > 512)
            {
                MessageBox.Show(
                    "Mô tả không quá 512 ký tự!!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                    );
            }
            //poster
            
            string SqlQuery = "INSERT INTO BOPHIM VALUES (@MAPHIM, @TENPHIM, @THELOAI, @THOILUONG, @MOTA, @POSTER_URL, 'TRAILER_URL', @TRANGTHAI)";
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@MAPHIM", SqlDbType.Char).Value = idphim.Text;
            comm.Parameters.Add("@TENPHIM", SqlDbType.NVarChar).Value = tenphim.Text;
            comm.Parameters.Add("@THELOAI", SqlDbType.NVarChar).Value = theloai.Text;
            comm.Parameters.Add("@THOILUONG", SqlDbType.Float).Value = float.Parse(thoiluong.Text);
            comm.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = mota.Text;
            comm.Parameters.Add("@TRANGTHAI", SqlDbType.NVarChar).Value = trangthai.Text;
            SaveImage();
            comm.Parameters.Add("@POSTER_URL", SqlDbType.VarChar).Value = poster_url;
            try
            {
                comm.ExecuteNonQuery();
                LoadData();
                Reset();
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
            
            //int stt = dataGridView1.RowCount + 1;
            //dataGridView1.Rows.Add(stt.ToString("D2"), idphim.Text, tenphim.Text, theloai.Text,thoiluong.Text,trangthai.Text,mota.Text );

        }
        void Reset()
        {
            idphim.Clear();
            idphim.Enabled = true;
            tenphim.Clear();
            theloai.SelectedIndex = 0;
            thoiluong.Clear();
            trangthai.SelectedIndex = 1;
            mota.Clear();
            dataGridView1.ClearSelection();
            pictureBox1.Image = null;
            poster_url = string.Empty;
        }

        private void Qlyphim_Load(object sender, EventArgs e)
        {
            theloai.SelectedIndex = 0;
            trangthai.SelectedIndex = 1;
            dataGridView1.AutoSize = false;
            SearchTextBox.Text = "Tìm kiếm theo tên";
            SearchTextBox.ForeColor = Color.Gray;
            LoadData();
            dataGridView1.ClearSelection();
            dataGridView1.RowTemplate.Height = 45;
        }
        

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idphim.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (
                string.IsNullOrWhiteSpace(idphim.Text) ||
                string.IsNullOrWhiteSpace(tenphim.Text) ||
                string.IsNullOrWhiteSpace(thoiluong.Text) ||
                string.IsNullOrWhiteSpace(trangthai.Text) ||
                string.IsNullOrWhiteSpace(mota.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(thoiluong.Text, out int he))
            {
                // Hiển thị MessageBox nếu không phải là số
                MessageBox.Show("Thời lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mota.Text.Length > 512)
            {
                MessageBox.Show(
                    "Mô tả không quá 512 ký tự!!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }

            string SqlQuery = "UPDATE BOPHIM SET " +
                "TENPHIM =  @TENPHIM," +
                "THELOAI = @THELOAI," +
                "THOILUONG = @THOILUONG," +
                "MOTA = @MOTA, " +
                "POSTER_URL = @POSTER_URL," +
                "TRAILER_URL = 'TRAILER_URL'," +
                "DANGCHIEU = @TRANGTHAI " +
                "WHERE MAPHIM = @MAPHIM";
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlQuery, conn);
            comm.Parameters.Add("@MAPHIM", SqlDbType.Char).Value = idphim.Text;
            comm.Parameters.Add("@TENPHIM", SqlDbType.NVarChar).Value = tenphim.Text;
            comm.Parameters.Add("@THELOAI", SqlDbType.NVarChar).Value = theloai.Text;
            comm.Parameters.Add("@THOILUONG", SqlDbType.Float).Value = float.Parse(thoiluong.Text);
            comm.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = mota.Text;
            comm.Parameters.Add("@TRANGTHAI", SqlDbType.NVarChar).Value = trangthai.Text;
            SaveImage();
            comm.Parameters.Add("POSTER_URL", SqlDbType.VarChar).Value = poster_url;
            try
            {
                comm.ExecuteNonQuery();
                LoadData();
                Reset();
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
            idphim.Text = dt.Rows[row]["MAPHIM"].ToString();
            idphim.Enabled = false;
            tenphim.Text = dt.Rows[row]["TENPHIM"].ToString();
            theloai.SelectedItem = dt.Rows[row]["THELOAI"].ToString();
            thoiluong.Text = dt.Rows[row]["THOILUONG"].ToString();
            trangthai.SelectedItem = dt.Rows[row]["DANGCHIEU"].ToString();
            mota.Text = dt.Rows[row]["MOTA"].ToString();
            string relative_poster_path = dt.Rows[row]["POSTER_URL"].ToString();
            poster_url = Path.Combine(projectFolder, relative_poster_path);
            try
            {
                using (FileStream stream = new FileStream(poster_url, FileMode.Open))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(relative_poster_path))
                {
                    if (ex is FileNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy file poster",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    if (ex is DirectoryNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy folder poster",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            check = true;
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
                    // 👉 Click icon Edit
                    using (FormSuaPhim popup = new FormSuaPhim())
                    {
                        popup.StartPosition = FormStartPosition.CenterParent;
                        popup.ShowDialog(FindForm());
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    // 👉 Click icon Delete
                    MessageBox.Show("Bạn vừa click nút xóa (tạm thời chưa có hành động).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dòng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(ConnString);
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["MAPHIM"].ToString();
                        string SqlQuery = "DELETE FROM BOPHIM WHERE MAPHIM = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                        string fullPath = Path.Combine(projectFolder, "posters", temp_id + ".png");
                        if (File.Exists(fullPath))
                            File.Delete(fullPath);
                    }
                    conn.Close();
                    LoadData();
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Tìm kiếm theo tên")
            {
                SearchTextBox.Text = "";

                SearchTextBox.ForeColor = Color.Black;
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Tìm kiếm theo tên";
                SearchTextBox.ForeColor = Color.Gray;

            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = SearchTextBox.Text.ToLower();
                string tenSV = " ";
                DataTable dt = dataGridView1.DataSource as DataTable;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        tenSV = dt.Rows[index]["TENPHIM"].ToString().ToLower();
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
       
        public bool check=false;
        private void Qlyphim_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Reset();
                }
                check = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Reset();
                }
            }
            check = false;
        }
        
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {

                dataGridView1.ClearSelection();
                Reset();
                check = false;

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

                string newFolderPath = Path.Combine(projectFolder, "posters");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                // 3. Tạo tên file hình ảnh (ví dụ: image.png)
                ImageFormat imageFormat = pictureBox1.Image.RawFormat;
                string fileName = idphim.Text + "." + new ImageFormatConverter().ConvertToString(imageFormat).ToLower(); // Tên file hình ảnh (bạn có thể thay đổi tên này)
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
                    poster_url = Path.Combine("posters", fileName);
                }

                //MessageBox.Show("Hình ảnh đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        using(FileStream stream = new FileStream(filePath, FileMode.Open))
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (FormThemPhim popup = new FormThemPhim())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog(FindForm()); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
