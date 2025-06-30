using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using Qlyrapchieuphim.FormEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Qlyrapchieuphim
{
    public partial class Qlykhachhang : UserControl
    {
        SqlConnection conn = null;
        public Qlykhachhang()
        {
            InitializeComponent();
            //makh.MaxLength = 8;
            hotenkh.MaxLength = 100;
            email.MaxLength = 50;
            dataGridView1.ReadOnly = true;
            sdt.MaxLength = 15;
            makh.Enabled = false;
        }

        private void Reset()
        {
            makh.Clear();
            makh.Enabled = false;
            hotenkh.Clear();
            sdt.Clear();
            email.Clear();
            diemtichluy.Clear();
            dataGridView1.ClearSelection();
            this.Refresh();
        }
        private void LoadData()
        {
            
            string SqlQuery = "SELECT CustomerID, FullName, Phone, LoyaltyPoints, cs.UserID, Email  " +
                "FROM Customers cs JOIN Users usr ON (cs.UserID = usr.UserID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Customers");
            conn.Close();
            DataTable dt = ds.Tables["Customers"];
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
            
            this.Refresh();
        }
        private void them_Click(object sender, EventArgs e)
        {

            if (//string.IsNullOrWhiteSpace(makh.Text) ||
                string.IsNullOrWhiteSpace(hotenkh.Text) ||
                string.IsNullOrWhiteSpace(sdt.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(diemtichluy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (sdt.Text.Length < 6)
            {
                MessageBox.Show("Số điện thoại quá ngắn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int dtl;
            if (!int.TryParse(diemtichluy.Text, out dtl))
            {
                MessageBox.Show(
                    "Điểm tích lũy phải là số nguyên.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
            //SQL section - Users
            string SqlQuery = "INSERT INTO Users OUTPUT INSERTED.UserID VALUES (@Username, @Password, @Role, @Email)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = hotenkh.Text.Trim() + sdt.Text.Substring(0,4);//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = sdt.Text.Trim();//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = "customer";
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email.Text;
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
                            "Username không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        return;
                    default:
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        throw;
                }
                
            }
            

            //SQL section - Customers
            SqlQuery = "INSERT INTO Customers VALUES (@FullName, @Phone, @LoyaltyPoints, @UserID)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = hotenkh.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = sdt.Text;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = dtl;
            
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
                    case 2627:
                        MessageBox.Show(
                            "Mã khách hàng không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        break;
                    default:
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        throw;
                }
            }
            
        }

        

        private void Qlykhachhang_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            LoadData();
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox6.Text = "Tìm kiếm theo tên";
            guna2TextBox6.ForeColor = Color.Gray;
            dataGridView1.RowTemplate.Height = 45;
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

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
                    string customerId = dt.Rows[e.RowIndex]["CustomerID"].ToString();
                    using (FormSuaKhachHang popup = new FormSuaKhachHang(customerId))
                    {
                        //Todo: Lấy dữ liệu từ hàng này trong datagridview để truyền qua formSửa
                        popup.StartPosition = FormStartPosition.CenterParent;
                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData(); // Chỉ gọi nếu form kia trả về OK
                        }
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    // 👉 Click icon Delete


                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DataTable dt = dataGridView1.DataSource as DataTable;
                        string customerId = dt.Rows[e.RowIndex]["CustomerID"].ToString();

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                                conn.Open();

                            string deleteQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(); // Cập nhật lại DataGridView sau khi xóa
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            if (conn.State != ConnectionState.Closed)
                                conn.Close();
                        }
                        catch (Exception ex)
                        {
                            if (conn.State != ConnectionState.Closed)
                                conn.Close();
                            MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(makh.Text) ||
                    string.IsNullOrWhiteSpace(hotenkh.Text) ||
                    string.IsNullOrWhiteSpace(sdt.Text) ||
                    string.IsNullOrWhiteSpace(email.Text) ||
                    string.IsNullOrWhiteSpace(diemtichluy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int dtl;
            if (!int.TryParse(diemtichluy.Text, out dtl))
            {
                MessageBox.Show(
                    "Điểm tích lũy phải là số nguyên.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (sdt.Text.Length < 6)
            {
                MessageBox.Show("Số điện thoại quá ngắn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Update values in selected row

            //SQL Section - Customers
            string SqlQuery = "UPDATE Customers SET " +
                "FullName = @FullName, " +
                "Phone = @Phone, " +
                "LoyaltyPoints = @LoyaltyPoints " +
                "OUTPUT INSERTED.UserID " +
                "WHERE CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = int.Parse(makh.Text);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = hotenkh.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = sdt.Text;
            cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = dtl;
            int usrID;
            
            try
            {
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
                            "Mã khách hàng không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        return;
                    default:
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
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
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = hotenkh.Text.Trim() + sdt.Text.Substring(0, 4);//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = sdt.Text.Trim();//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = "customer";
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;
            
            try
            {
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
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        return;
                    default:
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        throw;
                }
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
                    conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["CustomerID"].ToString();
                        string SqlQuery = "DELETE FROM Customers OUTPUT DELETED.UserID WHERE CustomerID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        int usrID;
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
            Reset();
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                guna2TextBox6.Text = "Tìm kiếm theo tên";
                guna2TextBox6.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox6.Text.ToLower();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Helper.DrawNumbering(sender, e, this);
        }

        private void diemtichluy_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(diemtichluy.Text) && !int.TryParse(diemtichluy.Text, out _))
                errorProvider1.SetError(diemtichluy, "Phải là số nguyên.");
            else
                errorProvider1.Clear();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemKhachHang popup = new FormThemKhachHang())
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
