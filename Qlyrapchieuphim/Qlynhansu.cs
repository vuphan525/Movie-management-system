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
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Net.Mail;
using Qlyrapchieuphim.FormEdit;


namespace Qlyrapchieuphim
{
    public partial class Qlynhansu : UserControl
    {
        SqlConnection conn;
        public Qlynhansu()
        {
            InitializeComponent();
            //manv.MaxLength = 4;
            trangthai.Enabled = false;
            hoten.MaxLength = 100;
            email.MaxLength = 50;
            dataGridView1.ReadOnly = true;
            sodienthoai.MaxLength = 15;
            usrnameTxtBox.MaxLength = 100;
            passTxtBox.MaxLength = 100;
            //string[] trt = new string[] { "Nghỉ việc", "Đang làm việc", "Tạm thời" };
            //trangthai.Items.AddRange(trt);
            manv.Enabled = false;
        }
        private void LoadData()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT StaffID, FullName, Phone, usr.UserID, DateOfBirth, Username, Password, Role, Email " +
                "FROM Staffs sf LEFT JOIN Users usr ON (sf.UserID = usr.UserID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Staffs");
            DataTable dt = ds.Tables["Staffs"];
            //dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;

            // Xóa cột "Actions" nếu đã tồn tại (tránh trùng)
            //if (dataGridView1.Columns.Contains("Actions"))
            //{
            //    dataGridView1.Columns.Remove("Actions");
            //}

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
        private void them_Click(object sender, EventArgs e)
        {

            if (//string.IsNullOrWhiteSpace(manv.Text) ||
                string.IsNullOrWhiteSpace(hoten.Text) ||
                string.IsNullOrWhiteSpace(sodienthoai.Text) ||
                string.IsNullOrWhiteSpace(email.Text) )
                
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DateTime birthDate = ngaysinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Test email format
            try
            {
                MailAddress test_mail = new MailAddress(email.Text);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show(
                    "Địa chỉ mail không đúng định dạng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Lỗi địa chỉ mail.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                return;
            }

            //SQL section - Users
            string SqlQuery = "INSERT INTO Users OUTPUT INSERTED.UserID VALUES (@Username, @Password, @Role, @Email)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = usrnameTxtBox.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = passTxtBox.Text.Trim();
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = chucvu.SelectedItem;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email.Text;

            //cmd.Parameters.Add("@manv", SqlDbType.Char).Value = manv.Text;
            //cmd.Parameters.Add("@trthai", SqlDbType.NVarChar).Value = trangthai.Text;
            int usrID;
            
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                usrID = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Mã nhân viên không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }

            //SQL section - Staffs
            SqlQuery = "INSERT INTO Staffs VALUES (@FullName, @Phone, @UserID, @DateOfBirth)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = hoten.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = sodienthoai.Text;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = ngaysinh.Value.Date;
            
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                Reset();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Username không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }
            

        }

        private void Qlynhansu_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            //trangthai.SelectedIndex = 1;
            chucvu.SelectedIndex = 0;
            dataGridView1.AutoSize = false;
            SearchTextBox.Text = "Tìm kiếm theo tên";
            SearchTextBox.ForeColor = Color.Gray;
            ngaysinh.Value = DateTime.Today.Subtract(TimeSpan.FromDays(365 * 19));
            LoadData();
            dataGridView1.ClearSelection();
            dataGridView1.RowTemplate.Height = 45;
        }

        private void capnhat_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(manv.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(manv.Text) ||
                   string.IsNullOrWhiteSpace(hoten.Text) ||
                   string.IsNullOrWhiteSpace(sodienthoai.Text) ||
                   string.IsNullOrWhiteSpace(email.Text) )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DateTime birthDate = ngaysinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                MailAddress test_mail = new MailAddress(email.Text);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show(
                    "Địa chỉ mail không đúng định dạng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Lỗi địa chỉ mail.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                return;
            }

            //SQL Section - Staffs
            string SqlQuery = "UPDATE Staffs SET " +
                "FullName = @FullName, " +
                "Phone = @Phone, " +
                "DateOfBirth = @DateOfBirth " +
                "OUTPUT INSERTED.UserID " +
                "WHERE StaffID = @StaffID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = int.Parse(manv.Text);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = hoten.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = sodienthoai.Text;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = ngaysinh.Value;
            int usrID;
            
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                usrID = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Mã nhân viên không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }
            
            //SQL Section - Users
            SqlQuery = "UPDATE Users SET " +
                "Username = @Username, " +
                "Password = @Password, " +
                "Role = @Role, " +
                "Email = @Email " +
                "WHERE UserID = @UserID";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = usrnameTxtBox.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = passTxtBox.Text.Trim();
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = chucvu.SelectedItem;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;
            
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                Reset();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Username không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }
            
        }
        private void Reset()
        {
            manv.Clear();
            manv.Enabled = false;
            hoten.Clear();
            sodienthoai.Clear();
            email.Clear();
            passTxtBox.Clear();
            usrnameTxtBox.Clear();
            //trangthai.SelectedIndex = 1;
            chucvu.SelectedIndex = 0;
            ngaysinh.Value = DateTime.Today.Subtract(TimeSpan.FromDays(365 * 19));
            dataGridView1.ClearSelection();
            this.Refresh();
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
                        string temp_id = dt.Rows[selected]["StaffID"].ToString();
                        //if (temp_id == "0")
                        //{
                        //    MessageBox.Show(
                        //        "Không thể xoá tài khoản ADMIN mặc định.",
                        //        "Thông báo",
                        //        MessageBoxButtons.OK,
                        //        MessageBoxIcon.Information);
                        //    return;
                        //}
                        int usrID;
                        string SqlQuery = "DELETE FROM Staffs OUTPUT DELETED.UserID WHERE StaffID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid",SqlDbType.Char).Value = temp_id;
                        usrID = int.Parse(cmd.ExecuteScalar().ToString());

                        SqlQuery = "DELETE FROM Users WHERE UserID = @usrID";
                        cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@usrID", SqlDbType.Char).Value = usrID;
                        cmd.ExecuteNonQuery();

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
            LoadData();
            Reset();

        }
        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            manv.Text = dt.Rows[row]["StaffID"].ToString();
            manv.Enabled = false;
            hoten.Text = dt.Rows[row]["FullName"].ToString();
            sodienthoai.Text = dt.Rows[row]["Phone"].ToString();
            email.Text = dt.Rows[row]["Email"].ToString();
            ngaysinh.Value = (DateTime)dt.Rows[row]["DateOfBirth"];
            usrnameTxtBox.Text = dt.Rows[row]["Username"].ToString();
            passTxtBox.Text = dt.Rows[row]["Password"].ToString();
            chucvu.SelectedItem = dt.Rows[row]["Role"].ToString();
        }
    
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
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
                    string Id = dt.Rows[e.RowIndex]["StaffID"].ToString();
                    // 👉 Click icon Edit
                    using (FormSuaNhanVien popup = new FormSuaNhanVien(Id))
                    {


                        


                        //Todo: Lấy dữ liệu từ hàng này trong datagridview để truyền qua formSửa

                        popup.StartPosition = FormStartPosition.CenterParent;
                        ;
                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData(); // Chỉ gọi nếu form kia trả về OK
                        }
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            DataTable dt = dataGridView1.DataSource as DataTable;
                            string staffId = dt.Rows[e.RowIndex]["StaffID"].ToString();
                            int userId = -1;

                            // Lệnh 1: Lấy UserID từ bảng Staffs và xoá Staff
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Staffs OUTPUT DELETED.UserID WHERE StaffID = @staffId", conn))
                            {
                                cmd1.Parameters.AddWithValue("@staffId", staffId);

                                bool wasClosed = conn.State == ConnectionState.Closed;
                                if (wasClosed) conn.Open();

                                object resultUserId = cmd1.ExecuteScalar();

                                if (wasClosed) conn.Close(); // Đóng nếu chính hàm này đã mở
                                if (resultUserId == null)
                                {
                                    MessageBox.Show("Không thể xoá nhân viên. Có thể mã không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                userId = Convert.ToInt32(resultUserId);
                            }

                            // Lệnh 2: Xoá User theo UserID
                            using (SqlCommand cmd2 = new SqlCommand("DELETE FROM Users WHERE UserID = @userId", conn))
                            {
                                cmd2.Parameters.AddWithValue("@userId", userId);

                                bool wasClosed = conn.State == ConnectionState.Closed;
                                if (wasClosed) conn.Open();

                                cmd2.ExecuteNonQuery();

                                if (wasClosed) conn.Close();
                            }

                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại danh sách
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xoá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


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
                        tenSV = dt.Rows[index]["FullName"].ToString().ToLower();
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager.SuspendBinding();
                        if (tenSV.Contains(tenCanTim) && tenSV != "anon")
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
        

        private void guna2TextBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Tìm kiếm theo tên";
                SearchTextBox.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox5_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Tìm kiếm theo tên")
            {
                SearchTextBox.Text = "";

                SearchTextBox.ForeColor = Color.Black;
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
            //Helper.DrawNumbering(sender, e, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemNhanVien popup = new FormThemNhanVien())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                
                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData(); // Chỉ gọi nếu form kia trả về OK
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
