using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Qlyrapchieuphim
{
    public partial class Banve : UserControl
    {
        SqlConnection conn = null;
        private int userID = -1;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
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
            try
            {
                
                string SqlQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
                SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                count = (int)countCmd.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    tenphim.Enabled = true;
                    errorProvider1.Clear();
                    SqlQuery = "SELECT MovieID, Title FROM Movies WHERE Status = N'Đang chiếu'";
                    string[] movies = new string[count];
                    SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        movies[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0) + ")";
                        i++;
                    }
                    conn.Close();
                    tenphim.DataSource = movies;
                }
                else
                {
                    tenphim.Enabled = false;
                    errorProvider1.SetError(tenphim, "Không có phim trong hệ thống!");
                }
                
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phim đang chiếu: " + ex.Message);
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                return false;
            }
        }
        private void LoadData()
        {
            string SqlQuery = "SELECT ShowtimeID, StartTime, RoomID, st.MovieID, Title " +
                "FROM Showtimes st JOIN Movies mv ON (st.MovieID = mv.MovieID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Showtimes");
            conn.Close() ;
            DataTable dt = ds.Tables["Showtimes"];
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

        }
        private void lvLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            LoadData();
            if (CheckMovie())
                tenphim.SelectedIndex = 0;
            
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = "dd/MM/yyyy";
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

                DateTime selectedDate = date.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null) return;

                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        string rawDate = dt.Rows[index]["StartTime"].ToString();

                        // Định dạng hỗ trợ cả kiểu 1 chữ số hoặc 2 chữ số
                        string[] formats = {
                    "d/M/yyyy h:mm tt", "d/M/yyyy h:mm:ss tt",
                    "dd/MM/yyyy hh:mm tt", "dd/MM/yyyy hh:mm:ss tt",
                    "M/d/yyyy h:mm tt", "M/d/yyyy h:mm:ss tt",
                    "MM/dd/yyyy hh:mm tt", "MM/dd/yyyy hh:mm:ss tt"
                };

                        if (!DateTime.TryParseExact(rawDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateFromRow))
                        {
                            MessageBox.Show("Không thể đọc ngày chiếu: " + rawDate, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.Visible = false;
                            continue;
                        }

                        // So sánh phần ngày
                        row.Visible = (dateFromRow.Date == selectedDate);
                    }
                }

                currencyManager.ResumeBinding();
                dataGridView1.ClearSelection();
            }
            else
            {
                Search.Text = "Tìm kiếm suất chiếu";
                date.Visible = false;
                label4.Visible = false;
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
                DateTime selectedDate = date.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt == null) return;

                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        string dateStr = dt.Rows[index]["StartTime"].ToString();

                        // Danh sách các định dạng có thể xảy ra (rất linh hoạt)
                        string[] formats = {
                    "d/M/yyyy h:mm tt",
                    "dd/MM/yyyy hh:mm tt",
                    "d/M/yyyy h:mm:ss tt",
                    "dd/MM/yyyy hh:mm:ss tt",
                    "M/d/yyyy h:mm tt",
                    "MM/dd/yyyy hh:mm tt",
                    "M/d/yyyy h:mm:ss tt",
                    "MM/dd/yyyy hh:mm:ss tt"
                };

                        if (!DateTime.TryParseExact(dateStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateFromRow))
                        {
                            MessageBox.Show("Không thể đọc ngày chiếu: " + dateStr, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.Visible = false; // Ẩn dòng lỗi
                            continue;
                        }

                        // So sánh phần ngày
                        row.Visible = (dateFromRow.Date == selectedDate);
                    }
                }

                currencyManager.ResumeBinding();
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
                formbanve bv = new formbanve((int)dt.Rows[e.RowIndex]["ShowtimeID"]);
                bv.UserId = userID;
                bv.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
