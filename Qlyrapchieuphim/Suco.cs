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

namespace Qlyrapchieuphim
{
    public partial class Suco : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Suco()
        {
            InitializeComponent();
            dataGridView1.AutoSize = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            tinhtrang.SelectedIndex = 2;
            ngaytiepnhan.Value=DateTime.Today;
            masuco.MaxLength = 16;
        }

        private bool CheckNV()
        {
            int count;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM NHANVIEN";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                manv.Enabled = true;
                errorProvider1.Clear();
                SqlQuery = "SELECT MANHANVIEN, TENNHANVIEN FROM NHANVIEN";
                string[] employees = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    employees[i] = reader.GetString(0) + ": " + reader.GetString(1);
                    i++;
                }
                manv.DataSource = employees;
            }
            else
            {
                manv.Enabled = false;
                errorProvider1.SetError(manv, "Không có nhân viên trong hệ thống!");
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MASUCO, TENSUCO, sc.MANHANVIEN, TENNHANVIEN, TINHTRANG, NGAYBAOCAO, MOTA " +
                "FROM SUCO sc , NHANVIEN nv " +
                "WHERE (sc.MANHANVIEN = nv.MANHANVIEN)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUCO");
            DataTable dt = ds.Tables["SUCO"];
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void guna2Button1_Click(object sender, EventArgs e) //bcButton
        {
            if (manv.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tensuco.Text) ||
                string.IsNullOrWhiteSpace(mota.Text) ||
                string.IsNullOrEmpty(masuco.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "INSERT INTO SUCO VALUES (@masc, @tensc, @manv, @tinhtrang, @ngbc, @mota)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.Char).Value = masuco.Text;
            cmd.Parameters.Add("@tensc", SqlDbType.NVarChar).Value = tensuco.Text;
            string tp = manv.SelectedItem.ToString();
            int position = tp.IndexOf(": ");
            string mnv = tp.Substring(0, position);
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = mnv;
            cmd.Parameters.Add("@ngbc", SqlDbType.Date).Value = ngaytiepnhan.Value.Date;
            cmd.Parameters.Add("@tinhtrang", SqlDbType.NVarChar).Value = tinhtrang.SelectedItem;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar).Value = mota.Text;
            try
            {
                cmd.ExecuteNonQuery();
                LoadData();
                Updatea();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "Mã suất chiếu không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    default:
                        throw;
                }
            }
            conn.Close();

            Updatea();

        }
        void Updatea()
        {
            masuco.Clear();
            masuco.Enabled =true;
            tinhtrang.SelectedIndex = 2;
            tensuco.Clear();
            if (CheckNV())
                manv.SelectedIndex = 0;
            ngaytiepnhan.Value = DateTime.Today;
            mota.Clear();
            dataGridView1.ClearSelection();
        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (manv.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tensuco.Text) ||
                string.IsNullOrWhiteSpace(mota.Text) ||
                string.IsNullOrEmpty(masuco.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "UPDATE SUCO SET " +
                "MANHANVIEN = @manv, " +
                "TENSUCO = @tensc, " +
                "NGAYBAOCAO = @ngbc, " +
                "TINHTRANG = @ttr, " +
                "MOTA = @mota " +
                "WHERE MASUCO = @masc";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            string tp = manv.SelectedItem.ToString();
            int position = tp.IndexOf(": ");
            string mnv = tp.Substring(0, position);
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = mnv;
            cmd.Parameters.Add("@tensc", SqlDbType.NVarChar).Value = tensuco.Text;
            cmd.Parameters.Add("@ngbc", SqlDbType.Date).Value = ngaytiepnhan.Value.Date;
            cmd.Parameters.Add("@masc", SqlDbType.Char).Value = masuco.Text;
            cmd.Parameters.Add("@ttr", SqlDbType.NVarChar).Value = tinhtrang.SelectedItem;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar).Value = mota.Text;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                LoadData();
                Updatea();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "Mã suất chiếu không được trùng nhau!",
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
                        string temp_id = dt.Rows[selected]["MASUCO"].ToString();
                        string SqlQuery = "DELETE FROM SUCO WHERE MASUCO = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Updatea();
        }
        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            masuco.Text = dt.Rows[row]["MASUCO"].ToString();
            masuco.Enabled = false;
            DateTime date = (DateTime)dt.Rows[row]["NGAYBAOCAO"];
            ngaytiepnhan.Value = date;
            manv.SelectedItem = dt.Rows[row]["MANHANVIEN"] + ": " + dt.Rows[row]["TENNHANVIEN"];
            tinhtrang.SelectedItem = dt.Rows[row]["TINHTRANG"];
            tensuco.Text = dt.Rows[row]["TENSUCO"].ToString();
            mota.Text = dt.Rows[row]["MOTA"].ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
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

        private void Suco_Load(object sender, EventArgs e)
        {
            Updatea();
            LoadData();
        }

        private void Suco_Paint(object sender, PaintEventArgs e)
        {
            CheckNV();
            if (!manv.Enabled)
            {
                bcButton.Enabled = false;
                xoa.Enabled = false;
                capnhat.Enabled = false;
            }
            else
            {
                bcButton.Enabled = true;
                xoa.Enabled = true;
                capnhat.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
        }
    }
}
