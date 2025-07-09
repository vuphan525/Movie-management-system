using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    public partial class Qlyhoadon : UserControl
    {
        public Qlyhoadon()
        {
            InitializeComponent();
        }

        public bool issearch = false;

        private void Qlyhoadon_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            timkiem.Format = DateTimePickerFormat.Custom;
            timkiem.CustomFormat = "dd/MM/yyyy";
            timkiem.Visible = false;

            guna2TextBox6.PlaceholderText = "Tìm kiếm theo SĐT khách hàng";
        }

        private void Qlyhoadon_VisibleChanged(object sender, EventArgs e)
        {
            Qlyhoadon_Load(sender, e);
        }

        private void LoadDataGridView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT BookingID, FullName, Phone, CreatedAt " +
                                  "FROM Bookings bks JOIN Customers cts ON bks.CustomerID = cts.CustomerID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
            }

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.DataSource is DataTable dt)
            {
                int bookingId = Convert.ToInt32(dt.Rows[e.RowIndex]["BookingID"]);
                Hoadon hoadon = new Hoadon(bookingId);
                hoadon.ShowCurrentPoints = false;
                hoadon.Show();
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            string input = guna2TextBox6.Text.Trim();

            if (!(dataGridView1.DataSource is DataTable dt))
                return;

            // Nếu chuỗi trống -> Hiện tất cả hóa đơn
            if (string.IsNullOrEmpty(input))
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                cm.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                        row.Visible = true;
                }

                cm.ResumeBinding();
                return;
            }

            // Nếu nhập chữ → cảnh báo và xóa
            if (input.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Vui lòng chỉ nhập số khi tìm kiếm theo số điện thoại.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox6.Text = "";
                return;
            }

            // Nếu có số → lọc theo cột "Phone"
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager.SuspendBinding();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.DataBoundItem is DataRowView drv)
                {
                    string phone = drv["Phone"].ToString();
                    row.Visible = phone.Contains(input);
                }
            }

            currencyManager.ResumeBinding();
            dataGridView1.ClearSelection();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!issearch)
            {
                timkiem.Visible = true;
                guna2Button1.Text = "Hủy tìm kiếm";
                issearch = true;

                FilterByDate(timkiem.Value.Date);
            }
            else
            {
                timkiem.Visible = false;
                guna2Button1.Text = "Tìm kiếm hóa đơn";
                issearch = false;
                timkiem.Value = DateTime.Now;

                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                cm.SuspendBinding();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }

                cm.ResumeBinding();
                dataGridView1.ClearSelection();
            }
        }

        private void date_FormThemSuatChieu_NgayChieu_ValueChanged(object sender, EventArgs e)
        {
            if (issearch)
            {
                FilterByDate(timkiem.Value.Date);
            }
        }

        private void FilterByDate(DateTime selectedDate)
        {
            if (!(dataGridView1.DataSource is DataTable dt))
                return;

            CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            cm.SuspendBinding();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.DataBoundItem is DataRowView drv)
                {
                    DateTime rowDate = drv["CreatedAt"] is DateTime dtValue ? dtValue : DateTime.MinValue;
                    row.Visible = rowDate.Date == selectedDate;
                }
            }

            cm.ResumeBinding();
            dataGridView1.ClearSelection();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý gì nếu không custom vẽ
        }
    }
}
