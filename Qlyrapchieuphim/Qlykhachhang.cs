using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Net.Mail;

namespace Qlyrapchieuphim
{
    public partial class Qlykhachhang : UserControl
    {
        string ConnString = Program.ConnString;
        public Qlykhachhang()
        {
            InitializeComponent();
            makh.MaxLength = 8;
            hotenkh.MaxLength = 100;
            email.MaxLength = 50;
            dataGridView1.ReadOnly = true;
            sdt.MaxLength = 15;
        }

        private void Reset()
        {
            makh.Clear();
            makh.Enabled = true;
            hotenkh.Clear();
            sdt.Clear();
            email.Clear();
            diemtichluy.Clear();
            dataGridView1.ClearSelection();
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MAKHACHHANG, TENKHACHHANG, SODIENTHOAI, EMAIL, DIEMTICHLUY FROM KHACHHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");
            DataTable dt = ds.Tables["KHACHHANG"];
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void them_Click(object sender, EventArgs e)
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
            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "INSERT INTO KHACHHANG VALUES (@makh, @tenkh, @sdt, @email, @dtl)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@makh", SqlDbType.Char).Value = makh.Text;
            cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = hotenkh.Text;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@dtl", SqlDbType.Int).Value = dtl;
            try
            {
                cmd.ExecuteNonQuery();
                LoadData();
                Reset();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "Mã nhân viên không được trùng nhau!",
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

        

        private void Qlykhachhang_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox6.Text = "Tìm kiếm theo tên";
            guna2TextBox6.ForeColor = Color.Gray;
        }

        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            makh.Text = dt.Rows[row]["MAKHACHHANG"].ToString();
            makh.Enabled = false;
            hotenkh.Text = dt.Rows[row]["TENKHACHHANG"].ToString();
            sdt.Text = dt.Rows[row]["SODIENTHOAI"].ToString();
            email.Text = dt.Rows[row]["EMAIL"].ToString();
            diemtichluy.Text = dt.Rows[row]["DIEMTICHLUY"].ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
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

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "UPDATE KHACHHANG SET " +
                "TENKHACHHANG = @tenkh, " +
                "SODIENTHOAI = @sdt, " +
                "EMAIL = @email, " +
                "DIEMTICHLUY = @dtl " +
                "WHERE MAKHACHHANG = @makh";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@makh", SqlDbType.Char).Value = makh.Text;
            cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = hotenkh.Text;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@dtl", SqlDbType.Int).Value = dtl;
            try
            {
                cmd.ExecuteNonQuery();
                LoadData();
                Reset();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "Mã nhân viên không được trùng nhau!",
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
                        string temp_id = dt.Rows[selected]["MAKHACHHANG"].ToString();
                        string SqlQuery = "DELETE FROM KHACHHANG WHERE MAKHACHHANG = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
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
                        tenSV = dt.Rows[index]["TENKHACHHANG"].ToString().ToLower();
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

        
    }
}
