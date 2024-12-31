using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Qlyrapchieuphim
{
    public partial class Banve : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Banve()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            date.Visible = false;
            label4.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
        }
        private bool CheckMovie()
        {
            int count;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM BOPHIM";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                tenphim.Enabled = true;
                errorProvider1.Clear();
                SqlQuery = "SELECT MAPHIM, TENPHIM FROM BOPHIM";
                string[] movies = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    movies[i] = reader.GetString(1) + " (ID: " + reader.GetString(0) + ")";
                    i++;
                }
                tenphim.DataSource = movies;
            }
            else
            {
                tenphim.Enabled = false;
                errorProvider1.SetError(tenphim, "Không có phim trong hệ thống!");
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
            string SqlQuery = "SELECT MASUATCHIEU, THOIGIANBATDAU, NGAYCHIEU, MAPHONG, sc.MAPHIM, TENPHIM " +
                "FROM SUATCHIEU sc , BOPHIM p " +
                "WHERE (sc.MAPHIM = p.MAPHIM)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUATCHIEU");
            DataTable dt = ds.Tables["SUATCHIEU"];
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        if (!row.IsNewRow)
            //        {
            //            int index = row.Index;
            //            DateTime d;
            //            DateTime t;
            //            DateTime.TryParse(dt.Rows[index]["NGAYCHIEU"].ToString(), out DateTime dateFromRow);
            //            d = dateFromRow;

            //            TimeSpan.TryParse(dt.Rows[index]["THOIGIANBATDAU"].ToString(), out TimeSpan timeFromRow);
            //            t = new DateTime(d.Ticks + timeFromRow.Ticks);
                        
            //            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            //            currencyManager.SuspendBinding();
            //            row.Cells["stateColumn"].Value = "Đang bán vé";
            //            if (d.Date < DateTime.Today)
            //            {
            //                row.Cells["stateColumn"].Value = "Đã qua giờ bán vé";

            //            }
            //            else if (d.Date == DateTime.Today)
            //            {
            //                if (t.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
            //                {
            //                    row.Cells["stateColumn"].Value = "Đã qua giờ bán vé";
            //                }
            //            }
            //            currencyManager.ResumeBinding();
            //        }
            //    }
            //}
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }
        private void lvLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            formbanve a= new formbanve();
            a.Show();
           
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

        private void Banve_Load(object sender, EventArgs e)
        {
            LoadData();
            if (CheckMovie())
                tenphim.SelectedIndex = 0;
            date.Value = DateTime.Today;
        }
        public bool issearch = false;
        private void Search_Click(object sender, EventArgs e)
        {
            if (!issearch)
            {
                date.Visible = true;
                label4.Visible = true;
                Search.Text = "Hủy tìm kiếm";
                issearch = true;
                DateTime a = date.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        if (!DateTime.TryParse(dt.Rows[index]["NGAYCHIEU"].ToString(), out DateTime dateFromRow))
                        {
                            MessageBox.Show(
                                "Không thể đọc ngày chiếu",
                                "Lỗi dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager.SuspendBinding();
                        if (dateFromRow.Date == a)
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
                dataGridView1.ClearSelection();
            }
            else
            {
                Search.Text = "Tìm kiếm suất chiếu";
                date.Visible = false;
                label4.Visible= false;
                issearch = false;
                date.Value = DateTime.Today;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }
        private void date_ValueChanged(object sender, EventArgs e)
        {
            
            if (issearch)
            {
                DateTime a = date.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        if (!DateTime.TryParse(dt.Rows[index]["NGAYCHIEU"].ToString(), out DateTime dateFromRow))
                        {
                            MessageBox.Show(
                                "Không thể đọc ngày chiếu",
                                "Lỗi dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager.SuspendBinding();
                        if (dateFromRow.Date == a)
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
                dataGridView1.ClearSelection();
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (e.RowIndex >= 0)
            {
                formbanve bv = new formbanve(dt.Rows[e.RowIndex]["MASUATCHIEU"].ToString());
                bv.Show();
            }
        }
    }
}
