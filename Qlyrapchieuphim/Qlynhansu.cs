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

namespace Qlyrapchieuphim
{
    public partial class Qlynhansu : UserControl
    {
        public Qlynhansu()
        {
            InitializeComponent();
            manv.MaxLength = 4;
            hoten.MaxLength = 100;
            email.MaxLength = 50;
            dataGridView1.ReadOnly = true;
            sodienthoai.MaxLength = 15;
            string[] trt = new string[] { "Nghỉ việc", "Đang làm việc", "Tạm thời" };
            trangthai.Items.AddRange(trt);
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MANHANVIEN, TENNHANVIEN, SODIENTHOAI, EMAIL, NGSINH, TRANGTHAI FROM NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            DataTable dt = ds.Tables["NHANVIEN"];
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void them_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(manv.Text) ||
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

            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "INSERT INTO NHANVIEN VALUES (@manv, @tennv, N'Nhân viên', @sdt, @email, 'dc', 0.0, @ngsinh, @trthai)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = manv.Text;
            cmd.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = hoten.Text;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sodienthoai.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@ngsinh", SqlDbType.Date).Value = ngaysinh.Value;
            cmd.Parameters.Add("@trthai", SqlDbType.NVarChar).Value = trangthai.Text;
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

        private void Qlynhansu_Load(object sender, EventArgs e)
        {
            trangthai.SelectedIndex = 1;
            dataGridView1.AutoSize = false;
            SearchTextBox.Text = "Tìm kiếm theo tên";
            SearchTextBox.ForeColor = Color.Gray;
            ngaysinh.Value = DateTime.Now;
            LoadData();
            dataGridView1.ClearSelection();
        }

        private void capnhat_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
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



            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "UPDATE NHANVIEN SET " +
                "TENNHANVIEN = @tennv, " +
                "CHUCVU = N'Nhân viên', " +
                "SODIENTHOAI = @sdt, " +
                "EMAIL = @email, " +
                "DIACHI = 'dc', " +
                "LUONG = 0.0, " +
                "NGSINH = @ngsinh, " +
                "TRANGTHAI = @trthai " +
                "WHERE MANHANVIEN = @manv";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = manv.Text;
            cmd.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = hoten.Text;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sodienthoai.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@ngsinh", SqlDbType.Date).Value = ngaysinh.Value;
            cmd.Parameters.Add("@trthai", SqlDbType.NVarChar).Value = trangthai.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            Reset();
        }
        private void Reset()
        {
            manv.Clear();
            manv.Enabled = true;
            hoten.Clear();
            sodienthoai.Clear();
            email.Clear();
            trangthai.SelectedIndex = 1;
            ngaysinh.Value = DateTime.Now;
            dataGridView1.ClearSelection();
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
                        string temp_id = dt.Rows[selected]["MANHANVIEN"].ToString();
                        string SqlQuery = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid",SqlDbType.Char).Value = temp_id;
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
            manv.Text = dt.Rows[row]["MANHANVIEN"].ToString();
            manv.Enabled = false;
            hoten.Text = dt.Rows[row]["TENNHANVIEN"].ToString();
            sodienthoai.Text = dt.Rows[row]["SODIENTHOAI"].ToString();
            email.Text = dt.Rows[row]["EMAIL"].ToString();
            ngaysinh.Value = (DateTime)dt.Rows[row]["NGSINH"];
            trangthai.SelectedItem = dt.Rows[row]["TRANGTHAI"].ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
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
                        tenSV = dt.Rows[index]["TENNHANVIEN"].ToString().ToLower();
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
    }
}
