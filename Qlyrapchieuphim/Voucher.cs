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

namespace Qlyrapchieuphim
{
    public partial class Voucher : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Voucher()
        {
            
            InitializeComponent();
            trangthai.Enabled = false;
            trangthai.Visible = false;
            label4.Visible = false;
            maphathanh.MaxLength = 16;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            trangthai.SelectedIndex = 1;
            hieuluctu.Value = DateTime.Today;
            denngay.Value = DateTime.Today;
            guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
            guna2TextBox6.ForeColor = Color.Gray;
            dataGridView1.ReadOnly = true;
        }
        private void LoadData()
        {
            checkDate_database();
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MAPHATHANH, MENHGIA, NGAYPHATHANH, NGAYKETTHUC, TINHTRANG, MULTIPLE FROM VOUCHER";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "VOUCHER");
            DataTable dt = ds.Tables["VOUCHER"];
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e) //them
        {

            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgia;
            if (!double.TryParse(menhgia.Text, out mgia))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "INSERT INTO VOUCHER VALUES (@maph, @mg, @ngph, @ngkt, @ttr, @nhieu)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@maph", SqlDbType.Char).Value = maphathanh.Text;
            cmd.Parameters.Add("@mg", SqlDbType.Int).Value = menhgia.Text;
            cmd.Parameters.Add("@ngph", SqlDbType.Date).Value = hieuluctu.Value.Date;
            cmd.Parameters.Add("@ngkt", SqlDbType.Date).Value = denngay.Value.Date;
            cmd.Parameters.Add("@ttr", SqlDbType.NVarChar).Value = trangthai.SelectedItem;
            cmd.Parameters.Add("@nhieu", SqlDbType.Bit).Value = checkBox1.Checked;
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
        void Updatea()
        {
            trangthai.SelectedIndex = 1;
            maphathanh.Clear();
            maphathanh.Enabled = true;
            menhgia.Clear();
            hieuluctu.Value = DateTime.Now;
            denngay.Value = DateTime.Now;
            dataGridView1.ClearSelection();
            checkBox1.Checked = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgia;
            if (!double.TryParse(menhgia.Text, out mgia))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update values in selected row
            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "UPDATE VOUCHER SET " +
                "MENHGIA = @mg, " +
                "NGAYPHATHANH = @ngph, " +
                "NGAYKETTHUC = @ngkt, " +
                "TINHTRANG = @ttr, " +
                "MULTIPLE = @nhieu " +
                "WHERE MAPHATHANH = @maph";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@maph", SqlDbType.Char).Value = maphathanh.Text;
            cmd.Parameters.Add("@mg", SqlDbType.Int).Value = menhgia.Text;
            cmd.Parameters.Add("@ngph", SqlDbType.Date).Value = hieuluctu.Value.Date;
            cmd.Parameters.Add("@ngkt", SqlDbType.Date).Value = denngay.Value.Date;
            cmd.Parameters.Add("@ttr", SqlDbType.NVarChar).Value = trangthai.SelectedItem;
            cmd.Parameters.Add("@nhieu", SqlDbType.Bit).Value = checkBox1.Checked;
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
        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            maphathanh.Text = dt.Rows[row]["MAPHATHANH"].ToString();
            maphathanh.Enabled = false;
            DateTime start = (DateTime)dt.Rows[row]["NGAYPHATHANH"];
            DateTime end = (DateTime)dt.Rows[row]["NGAYKETTHUC"];
            hieuluctu.Value = start;
            denngay.Value = end;
            menhgia.Text = dt.Rows[row]["MENHGIA"].ToString();
            trangthai.SelectedItem = dt.Rows[row]["TINHTRANG"];
            checkBox1.Checked = (bool)dt.Rows[row]["MULTIPLE"];
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
            }
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
                        string temp_id = dt.Rows[selected]["MAPHATHANH"].ToString();
                        string SqlQuery = "DELETE FROM VOUCHER WHERE MAPHATHANH = @tempid";
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

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo mã voucher")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
                guna2TextBox6.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "Tìm kiếm theo mã voucher")
            {
                string tenCanTim = guna2TextBox6.Text.ToLower();
                string tenSV = " ";
                DataTable dt = dataGridView1.DataSource as DataTable;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        tenSV = dt.Rows[index]["MAPHATHANH"].ToString().ToLower();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            Updatea();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
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
        private void checkDate()
        {
            if (denngay.Value <= hieuluctu.Value)
                denngay.Value = hieuluctu.Value;
            if (denngay.Value < DateTime.Today)
                trangthai.SelectedIndex = 2; //hết hiệu lực
            else if (hieuluctu.Value <= DateTime.Today)
                trangthai.SelectedIndex = 0; //đang áp dụng
            else trangthai.SelectedIndex = 1; //chưa áp dụng
        }
        private void denngay_ValueChanged(object sender, EventArgs e)
        {
            checkDate();
        }

        private void hieuluctu_ValueChanged(object sender, EventArgs e)
        {
            checkDate();
        }

        private void Voucher_Paint(object sender, PaintEventArgs e)
        {
            checkDate();
        }
        private void checkDate_database()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MAPHATHANH, NGAYPHATHANH, NGAYKETTHUC FROM VOUCHER";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "VOUCHER");
            DataTable dt = ds.Tables["VOUCHER"];
            foreach (DataRow dr in dt.Rows)
            {
                string state = string.Empty;
                DateTime denngay = (DateTime)dr["NGAYKETTHUC"];
                DateTime hieuluctu = (DateTime)dr["NGAYPHATHANH"];
                if (denngay.Date < DateTime.Today)
                    state = "Đã hêt hiệu lực"; //hết hiệu lực
                else if (hieuluctu.Date <= DateTime.Today)
                    state = "Đang áp dụng"; //đang áp dụng
                else state = "Chưa áp dụng"; //chưa áp dụng
                SqlQuery = "UPDATE VOUCHER SET TINHTRANG = @state WHERE MAPHATHANH = @maph";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@state", SqlDbType.NVarChar).Value = state;
                cmd.Parameters.Add("@maph", SqlDbType.Char).Value = dr["MAPHATHANH"].ToString();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
