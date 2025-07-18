﻿using System;
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
        SqlConnection conn = null;
        public Qlysuatchieu()
        {
            InitializeComponent();

            giochieu.ShowUpDown = true;
            //idTextBox.MaxLength = 6;
            idTextBox.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Segoe UI", 12);
        }
        private bool CheckMovie()
        {
            int count;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                tenphim.Enabled = true;
                errorProvider1.Clear();
                SqlQuery = "SELECT MovieID, Title FROM Movies WHERE Status = N'Đang chiếu'";
                string[] movies = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    movies[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
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
        private bool CheckRoom()
        {
            int count;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM Rooms";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                phongchieu.Enabled = true;
                errorProvider2.Clear();
                SqlQuery = "SELECT RoomID, RoomName FROM Rooms";
                string[] rooms = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    rooms[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
                    i++;
                }
                phongchieu.DataSource = rooms;
            }
            else
            {
                phongchieu.Enabled = false;
                errorProvider2.SetError(phongchieu, "Không có phòng trong hệ thống!");
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }

        private void LoadData()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string SqlQuery = "SELECT ShowtimeID, StartTime, st.RoomID, st.MovieID, Title, RoomName " +
                "FROM Showtimes st JOIN Movies mv ON (st.MovieID = mv.MovieID) " +
                "JOIN Rooms rm ON (rm.RoomID = st.RoomID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Showtime");
            DataTable dt = ds.Tables["Showtime"];
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
            this.Refresh();
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

            string SqlQuery = "UPDATE Showtimes SET " +
                "MovieID = @MovieID, " +
                "RoomID = @RoomID, " +
                "StartTime = @StartTime, " +
                "Price = @Price " +
                "WHERE ShowtimeID = @ShowtimeID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            //string tp = tenphim.SelectedItem.ToString();
            //int startAt = tp.IndexOf(" (ID: ") + " (ID: ".Length;
            //int stopAt = tp.LastIndexOf(')');

            int mp = int.Parse(Helper.SubStringBetween(tenphim.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = mp;
            int roomID = int.Parse(Helper.SubStringBetween(phongchieu.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = ngaychieu.Value + giochieu.Value.TimeOfDay.StripMilliseconds();
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = 65000;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@ShowtimeID", SqlDbType.Int).Value = int.Parse(idTextBox.Text);
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
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
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
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

            string id = idTextBox.Text;

            string SqlQuery = "INSERT INTO Showtimes VALUES (@MovieID, @RoomID, @StartTime, @Price )";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            //cmd.Parameters.Add("@ShowtimeID", SqlDbType.Char).Value = idTextBox.Text;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = ngaychieu.Value + giochieu.Value.TimeOfDay.StripMilliseconds();
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = 65000; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            int roomID = int.Parse(Helper.SubStringBetween(phongchieu.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
            int movieID = int.Parse(Helper.SubStringBetween(tenphim.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = movieID;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
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
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            //add table for logging seats 

            //SqlQuery = "CREATE TABLE S_";
            //SqlQuery += id.Trim();
            //SqlQuery += " (" +
            //    "SeatName varchar(4) PRIMARY KEY, " +
            //    "CellValue bit DEFAULT 0," +
            //    ") ON [PRIMARY]; " +
            //    "CREATE UNIQUE NONCLUSTERED INDEX ";
            //SqlQuery += "IX_S" + id.Trim();
            //SqlQuery += " ON dbo.S_";
            //SqlQuery += id.Trim();
            //SqlQuery += " " +
            //            "(SeatName); ";
            //cmd = new SqlCommand(SqlQuery, conn);
            //if (conn.State != ConnectionState.Open)
            //    conn.Open();
            //cmd.ExecuteNonQuery();
            //for (char c = 'A'; c <= 'J'; c++)
            //{
            //    for (int i = 1; i <= 14; i++)
            //    {
            //        SqlQuery = "INSERT INTO S_";
            //        SqlQuery += id.Trim();
            //        SqlQuery += " VALUES(@seat, @bit)";
            //        cmd = new SqlCommand(SqlQuery, conn);
            //        cmd.Parameters.Add("@seat", SqlDbType.VarChar).Value = c.ToString() + i.ToString();
            //        cmd.Parameters.Add("@bit", SqlDbType.Bit).Value = false;
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            conn.Close();
        }
        void Updatea()
        {
            idTextBox.Clear();
            //idTextBox.Enabled = true;
            if (CheckMovie())
                tenphim.SelectedIndex = 0;
            if (CheckRoom())
                phongchieu.SelectedIndex = 0;
            ngaychieu.Value = DateTime.Now;
            giochieu.Value = DateTime.Now + TimeSpan.FromHours(1);
            dataGridView1.ClearSelection();
            this.Refresh();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    DataTable dt = dataGridView1.DataSource as DataTable;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["ShowtimeID"].ToString();
                        string SqlQuery = "DELETE FROM Showtimes WHERE ShowtimeID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Int).Value = temp_id;
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
            idTextBox.Text = dt.Rows[row]["ShowtimeID"].ToString();
            idTextBox.Enabled = false;
            DateTime date = (DateTime)dt.Rows[row]["StartTime"];
            ngaychieu.Value = date.Date;
            TimeSpan time = date.TimeOfDay;
            giochieu.Value = new DateTime(time.Ticks + date.Ticks);
            tenphim.SelectedItem = dt.Rows[row]["Title"] + " (ID: " + dt.Rows[row]["MovieID"] + ")";
            phongchieu.SelectedItem = dt.Rows[row]["RoomName"] + " (ID: " + dt.Rows[row]["RoomID"] + ")";
        }
        private void Qlysuatchieu_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.AutoSize = false;

            giochieu.Value = DateTime.Now + TimeSpan.FromHours(1);
            ngaychieu.Value = DateTime.Now;
            if (CheckMovie())
                tenphim.SelectedIndex = 0;
            if (CheckRoom())
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

                    DataTable dt = dataGridView1.DataSource as DataTable;
                    string id = dt.Rows[e.RowIndex]["ShowtimeID"].ToString();

                    using (FormSuaSuatChieu popup = new FormSuaSuatChieu(id))
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
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    string temp_id = dt.Rows[e.RowIndex]["ShowtimeID"].ToString();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa suất chiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (conn.State != ConnectionState.Open)
                                conn.Open();

                            // Xóa suất chiếu
                            string deleteQuery = "DELETE FROM Showtimes WHERE ShowtimeID = @tempid";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.Add("@tempid", SqlDbType.Int).Value = temp_id;
                            cmd.ExecuteNonQuery();

                            // Xoá bảng chỗ ngồi tương ứng (nếu có)
                            string dropTableQuery = "IF OBJECT_ID('dbo.S_" + temp_id.Trim() + "', 'U') IS NOT NULL DROP TABLE S_" + temp_id.Trim();
                            cmd = new SqlCommand(dropTableQuery, conn);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Đã xóa suất chiếu và dữ liệu ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException sqlex)
                        {
                            if (sqlex.Number == 547)
                            {
                                MessageBox.Show(
                                    "Không thể xóa suất chiếu, đã có khách hàng đặt vé suất chiếu này.",
                                    "Không thể xóa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("Lỗi khi xóa: " + sqlex.Message + "\nSQL Exception number: " + sqlex.Number, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                                conn.Close();

                            LoadData();
                            Updatea();
                        }
                    }

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
                        if (DateTime.TryParse(dt.Rows[index]["StartTime"].ToString(), out DateTime dateFromRow))
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
                        if (DateTime.TryParse(dt.Rows[index]["StartTime"].ToString(), out DateTime dateFromRow))
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
            //CheckMovie();
            //CheckRoom();
            //if (!tenphim.Enabled || !phongchieu.Enabled)
            //{
            //    them.Enabled = false;
            //    xoa.Enabled = false;
            //    chinhsua.Enabled = false;
            //}
            //else
            //{
            //    them.Enabled = true;
            //    xoa.Enabled = true;
            //    chinhsua.Enabled = true;
            //}
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
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
    }
}
