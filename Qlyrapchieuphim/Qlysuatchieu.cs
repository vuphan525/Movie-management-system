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
using Qlyrapchieuphim.FormEdit;

namespace Qlyrapchieuphim
{
    public partial class Qlysuatchieu : UserControl
    {
        string ConnString = Program.ConnString;
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
            string SqlQuery = "SELECT COUNT(*) FROM BOPHIM WHERE DANGCHIEU = N'Đang chiếu'";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();
            
            if (count >0)
            {
                tenphim.Enabled = true;
                errorProvider1.Clear();
                SqlQuery = "SELECT MAPHIM, TENPHIM FROM BOPHIM WHERE DANGCHIEU = N'Đang chiếu'";
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
            if (ngaychieu.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;

            }
            else if (ngaychieu.Value.Date == DateTime.Today)
            {
                if (giochieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
                {
                    MessageBox.Show("Giờ chiếu phải lớn hơn ngày giờ hiện tại!",
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
                            "Mã suất chiếu, ngày chiếu, giờ chiếu và phòng chiếu không được trùng nhau!",
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

            if (ngaychieu.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;

            }
            else if (ngaychieu.Value.Date == DateTime.Today)
            {
                if (giochieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
                {
                    MessageBox.Show("Giờ chiếu phải lớn hơn ngày giờ hiện tại!",
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
                return;
            }
            //SQL section
                //add entry
            SqlConnection conn = new SqlConnection(ConnString);
            string id = idTextBox.Text;
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
                            "Mã suất chiếu, ngày chiếu, giờ chiếu và phòng chiếu không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    default:
                        throw;
                }
            }
            //add table for logging seats
            SqlQuery = "CREATE TABLE S_";
            SqlQuery += id.Trim();
            SqlQuery += " (" +
                "SeatName varchar(4) PRIMARY KEY, " +
                "CellValue bit DEFAULT 0," +
                ") ON [PRIMARY]; " +
                "CREATE UNIQUE NONCLUSTERED INDEX ";
            SqlQuery += "IX_S" + id.Trim();
            SqlQuery += " ON dbo.S_";
            SqlQuery += id.Trim();
            SqlQuery += " " +
                        "(SeatName); ";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.ExecuteNonQuery();
            for (char c = 'A'; c <= 'J'; c++)
            {
                for (int i = 1; i <= 14; i++)
                {
                    SqlQuery = "INSERT INTO S_";
                    SqlQuery += id.Trim();
                    SqlQuery += " VALUES(@seat, @bit)";
                    cmd = new SqlCommand(SqlQuery, conn);
                    cmd.Parameters.Add("@seat", SqlDbType.VarChar).Value = c.ToString() + i.ToString();
                    cmd.Parameters.Add("@bit", SqlDbType.Bit).Value = false;
                    cmd.ExecuteNonQuery();
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
            giochieu.Value = DateTime.Now + TimeSpan.FromHours(1);
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

                        //delete seatlog from database
                        SqlQuery = "DROP TABLE S_" + temp_id.Trim();
                        cmd = new SqlCommand(SqlQuery, conn);
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
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.AutoSize = false;
            
            giochieu.Value = DateTime.Now + TimeSpan.FromHours(1);
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
                    // 👉 Click icon Edit
                    using (FormSuaSuatChieu popup = new FormSuaSuatChieu())
                    {
                        popup.StartPosition = FormStartPosition.CenterParent;
                        popup.ShowDialog(FindForm());
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    // 👉 Click icon Delete
                    MessageBox.Show("Bạn vừa click nút xóa (tạm thời chưa có hành động).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemSuatChieu popup = new FormThemSuatChieu())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog(FindForm()); 
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
    }
    public static class TimeExtensions
    {
        public static TimeSpan StripMilliseconds(this TimeSpan time)
        {
            return new TimeSpan(time.Hours, time.Minutes, time.Seconds);
        }

        
    }
}
