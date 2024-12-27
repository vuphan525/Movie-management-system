using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Configuration;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Qlyrapchieuphim
{
    public partial class Qlysuatchieu : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Qlysuatchieu()
        {
            InitializeComponent();

            giochieu.ShowUpDown = true;
            idTextBox.MaxLength = 6;

        }
        private bool CheckMovie()
        {
            int count;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM BOPHIM";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();
            
            if (count >0)
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
        //private void CheckRoom()
        //{
        //    int count;
        //    SqlConnection conn = new SqlConnection(ConnString);
        //    conn.Open();
        //    string SqlQuery = "SELECT COUNT(*) FROM PHONGCHIEU";
        //    SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
        //    count = (int)countCmd.ExecuteScalar();
            
        //    if (count > 0)
        //    {
        //        phongchieu.Enabled = true;
        //        errorProvider2.Clear();
        //        SqlQuery = "SELECT MAPHONG FROM PHONGCHIEU";
        //        string[] rooms = new string[count];
        //        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        int i = 0;
        //        while (reader.Read())
        //        {
        //            rooms[i] = reader.GetString(0);
        //            i++;
        //        }
        //        phongchieu.DataSource = rooms;
        //    }
        //    else
        //    {
        //        phongchieu.Enabled = false;
        //        errorProvider2.SetError(phongchieu, "Không có phòng trong hệ thống!");
        //    }
        //    conn.Close();
        //}
        
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
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void guna2Button1_Click(object sender, EventArgs e) //updateButton
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
           if (ngaychieu.Value <= DateTime.Now.Date)
            {
                if (giochieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
                {
                    MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (giochieu.Value < DateTime.Now && ngaychieu.Value < DateTime.Now.Date)
            //{
            //    MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
            //        "Lỗi nhập liệu",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    if (giochieu.Value < DateTime.Now)
            //    {
            //        // Hiển thị MessageBox nếu không phải là số
            //        MessageBox.Show("Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    if (ngaychieu.Value.Date < DateTime.Now.Date)
            //    {
            //        // Hiển thị MessageBox nếu không phải là số
            //        MessageBox.Show("Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            // Update values in selected row

            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "UPDATE SUATCHIEU SET " +
                "MAPHIM = @idphim, " +
                "MAPHONG = @idphong, " +
                "NGAYCHIEU = @ngaychieu, " +
                "THOIGIANBATDAU = @tgbd " +
                "WHERE MASUATCHIEU = @id";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            string tp = tenphim.SelectedItem.ToString();
            int position = tp.IndexOf(" (ID: ") + 6;
            string mp = tp.Substring(position, 4);
            cmd.Parameters.Add("@idphim", SqlDbType.Char).Value = mp;
            cmd.Parameters.Add("@idphong", SqlDbType.Char).Value = phongchieu.SelectedItem;
            cmd.Parameters.Add("@ngaychieu", SqlDbType.Date).Value = ngaychieu.Value.Date;
            cmd.Parameters.Add("@tgbd",SqlDbType.Time).Value = giochieu.Value.TimeOfDay.StripMilliseconds();
            cmd.Parameters.Add("@id", SqlDbType.Char).Value = idTextBox.Text;
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

        private void them_Click(object sender, EventArgs e)
        {

            if (ngaychieu.Value <= DateTime.Now.Date)
            {
                if (giochieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
                {
                    MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (giochieu.Value <= DateTime.Now && ngaychieu.Value <= DateTime.Now.Date)
            //{
            //    MessageBox.Show(
            //        "Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
            //        "Lỗi nhập liệu",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    if (giochieu.Value < DateTime.Now)
            //    {
            //        // Hiển thị MessageBox nếu không phải là số
            //        MessageBox.Show(
            //            "Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!",
            //            "Lỗi nhập liệu",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);
            //        return;
            //    }
            //    if (ngaychieu.Value < DateTime.Now.Date)
            //    {
            //        // Hiển thị MessageBox nếu không phải là số
            //        MessageBox.Show(
            //            "Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!",
            //            "Lỗi nhập liệu",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã suất chiếu!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            //SQL section
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "INSERT INTO SUATCHIEU VALUES (@masc, @tgbd, @ngchieu, @maphong, @maphim)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.Char).Value = idTextBox.Text;
            cmd.Parameters.Add("@tgbd", SqlDbType.Time).Value = giochieu.Value.TimeOfDay.StripMilliseconds();
            cmd.Parameters.Add("@ngchieu", SqlDbType.Date).Value = ngaychieu.Value.Date;
            cmd.Parameters.Add("@maphong", SqlDbType.Char).Value = phongchieu.SelectedItem;
            string tp = tenphim.SelectedItem.ToString();
            int position = tp.IndexOf(" (ID: ") + 6;
            string mp = tp.Substring(position, 4);
            cmd.Parameters.Add("@maphim", SqlDbType.Char).Value = mp;
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
            idTextBox.Clear();
            idTextBox.Enabled = true;
            if (CheckMovie())
                tenphim.SelectedIndex = 0;
            phongchieu.SelectedIndex = 0;
            ngaychieu.Value = DateTime.Now;
            giochieu.Value = DateTime.Now;
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
                        string temp_id = dt.Rows[selected]["MASUATCHIEU"].ToString();
                        string SqlQuery = "DELETE FROM SUATCHIEU WHERE MASUATCHIEU = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Updatea();
            }
        }
        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            idTextBox.Text = dt.Rows[row]["MASUATCHIEU"].ToString();
            idTextBox.Enabled = false;
            DateTime date = (DateTime)dt.Rows[row]["NGAYCHIEU"];
            ngaychieu.Value = date;
            TimeSpan time = (TimeSpan)dt.Rows[row]["THOIGIANBATDAU"];
            giochieu.Value = new DateTime(time.Ticks + date.Ticks);
            tenphim.SelectedItem = dt.Rows[row]["TENPHIM"] + " (ID: " + dt.Rows[row]["MAPHIM"] + ")";
            phongchieu.SelectedItem = dt.Rows[row]["MAPHONG"];
        }
        private void Qlysuatchieu_Load(object sender, EventArgs e)
        {
            
            dataGridView1.AutoSize = false;
            
            giochieu.Value = DateTime.Now;
            ngaychieu.Value = DateTime.Now;
            if (CheckMovie())
                tenphim.SelectedIndex = 0;

            phongchieu.SelectedIndex = 0;
            timkiem.Visible = false;
            timkiem.Value = DateTime.Now;
            LoadData();
            dataGridView1.ClearSelection();
        }
        public bool issearch = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
            }
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (!issearch)
            {
                timkiem.Visible = true;

                guna2Button1.Text = "Hủy tìm kiếm";
                issearch = true;
                DateTime a = timkiem.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        if (DateTime.TryParse(dt.Rows[index]["NGAYCHIEU"].ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
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
                timkiem.Visible = false;
                guna2Button1.Text = "Tìm kiếm suất chiếu";
                issearch = false;
                timkiem.Value = DateTime.Now;

            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void timkiem_ValueChanged(object sender, EventArgs e)
        {

            if (issearch)
            {
                DateTime a = timkiem.Value.Date;
                DataTable dt = dataGridView1.DataSource as DataTable;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        if (DateTime.TryParse(dt.Rows[index]["NGAYCHIEU"].ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
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

        private void Qlysuatchieu_Paint(object sender, PaintEventArgs e)
        {
            CheckMovie();
            if (!tenphim.Enabled || !phongchieu.Enabled)
            {
                them.Enabled = false;
                xoa.Enabled = false;
                chinhsua.Enabled = false;
            }
            else
            {
                them.Enabled = true;
                xoa.Enabled = true;
                chinhsua.Enabled = true;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
        }
    }
    public static class TimeExtensions
    {
        public static TimeSpan StripMilliseconds(this TimeSpan time)
        {
            return new TimeSpan(time.Days, time.Hours, time.Minutes, time.Seconds);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            if (giochieu.Value < DateTime.Now && ngaychieu.Value < DateTime.Now.Date)
            {

                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (giochieu.Value < DateTime.Now)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaychieu.Value.Date < DateTime.Now.Date)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = tenphim.Text;
           
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = phongchieu.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = ngaychieu.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = giochieu.Text;

            Updatea();
        }

        private void them_Click(object sender, EventArgs e)
        {
          

            if (giochieu.Value < DateTime.Now && ngaychieu.Value < DateTime.Now.Date)
            {

                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (giochieu.Value < DateTime.Now)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaychieu.Value < DateTime.Now.Date)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), tenphim.Text,  phongchieu.Text, ngaychieu.Text, giochieu.Text);

            Updatea();
        }
        void Updatea()
        {
            tenphim.SelectedIndex = 0;
           
            phongchieu.SelectedIndex = 0;
            
            ngaychieu.Value = DateTime.Now;
            giochieu.Value = DateTime.Now;
            dataGridView1.ClearSelection();


        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    CapNhatSTT();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Updatea();
        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void Qlysuatchieu_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            giochieu.Value = DateTime.Now;
            ngaychieu.Value = DateTime.Now;
            tenphim.SelectedIndex = 0;

            phongchieu.SelectedIndex = 0;
            timkiem.Visible = false;
            timkiem.Value = DateTime.Now;
        }
        public bool issearch = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                tenphim.Text = row.Cells[1].Value.ToString();
                
                phongchieu.Text = row.Cells[2].Value.ToString();
                ngaychieu.Text = row.Cells[3].Value.ToString();
                giochieu.Text = row.Cells[4].Value.ToString();

            }
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (!issearch)
            {
                timkiem.Visible = true;

                guna2Button1.Text = "Hủy tìm kiếm";
                issearch = true;
                DateTime a = timkiem.Value.Date;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
                        }

                        if (dateFromRow.Date == a)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            else
            {
                timkiem.Visible = false;
                guna2Button1.Text = "Tìm kiếm suất chiếu";
                issearch = false;
                timkiem.Value = DateTime.Now;

            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void timkiem_ValueChanged(object sender, EventArgs e)
        {

            if (issearch)
            {
                DateTime a = timkiem.Value.Date;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (DateTime.TryParse(row.Cells[3].Value.ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
                        }

                        if (dateFromRow.Date == a)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void giochieu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ngaychieu_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
