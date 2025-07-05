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
using System.Globalization;
using System.Text.RegularExpressions;

namespace Qlyrapchieuphim
{
    public partial class FormThemSuatChieu : Form
    {
        private int duration = 0; // Biến này có thể dùng để lưu trữ thời gian chiếu phim, nếu cần thiết
        public FormThemSuatChieu()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            this.Load += FormThemSuatChieu_Load;
            label6.Hide();
            lbl_FormThemSuatChieu_MaSuatChieu.Hide();
        }

        private void loadDataGridView()
        {
            // ====== NGÀY CHIẾU ======
            var dgvNgay = dataGridView_FormThemSuatChieu_BangNgayChieu;

            dgvNgay.AllowUserToAddRows = false;
            dgvNgay.RowTemplate.Height = 40;
            dgvNgay.ColumnHeadersHeight = 40;
            dgvNgay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNgay.MultiSelect = false;
            dgvNgay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvNgay.Columns.Count == 0)
            {
                dgvNgay.Columns.Add("STT", "STT");
                dgvNgay.Columns.Add("Time", "Ngày chiếu");

                var actionColumn = new DataGridViewTextBoxColumn();
                actionColumn.Name = "Actions";
                actionColumn.HeaderText = "Actions";
                dgvNgay.Columns.Add(actionColumn);
            }

            // ====== GIỜ CHIẾU ======
            var dgvGio = dataGridView_FormThemSuatChieu_BangGioChieu;

            dgvGio.AllowUserToAddRows = false;
            dgvGio.RowTemplate.Height = 40;
            dgvGio.ColumnHeadersHeight = 40;
            dgvGio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGio.MultiSelect = false;
            dgvGio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvGio.Columns.Count == 0)
            {
                dgvGio.Columns.Add("STT", "STT");
                dgvGio.Columns.Add("Time", "Giờ chiếu");

                var actionColumn2 = new DataGridViewTextBoxColumn();
                actionColumn2.Name = "Actions";
                actionColumn2.HeaderText = "Actions";
                dgvGio.Columns.Add(actionColumn2);
            }

            date_FormThemSuatChieu_GioChieu.ShowUpDown = true;
            date_FormThemSuatChieu_GioChieu.Format = DateTimePickerFormat.Time;

            // ====== PHÒNG CHIẾU ======
            var dgvRap = dataGridView_FormThemSuatChieu_BangPhongChieu;

            dgvRap.AllowUserToAddRows = false;
            dgvRap.RowTemplate.Height = 40;
            dgvRap.ColumnHeadersHeight = 40;
            dgvRap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRap.MultiSelect = false;
            dgvRap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvRap.Columns.Count == 0)
            {
                dgvRap.Columns.Add("STT", "STT");
                dgvRap.Columns.Add("Room", "Phòng chiếu");

                var actionColumn2 = new DataGridViewTextBoxColumn();
                actionColumn2.Name = "Actions";
                actionColumn2.HeaderText = "Actions";
                dgvRap.Columns.Add(actionColumn2);
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemSuatChieu_Load(object sender, EventArgs e)
        {
            date_FormThemSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";


            date_FormThemSuatChieu_GioChieu.ShowUpDown = true;
            date_FormThemSuatChieu_GioChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_GioChieu.CustomFormat = "hh:mm";


            if (CheckMovie())
                cb_FormThemSuatChieu_TenPhim.SelectedIndex = 0;
            if (CheckRoom())
                cb_FormThemSuatChieu_PhongChieu.SelectedIndex = 0;
            date_FormThemSuatChieu_NgayChieu.Value = DateTime.Today.AddDays(1);
            date_FormThemSuatChieu_GioChieu.Value = DateTime.Now.AddHours(1);

            loadDataGridView();
        }

        private bool CheckRoom()
        {
            int count;
            try
            {
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    string SqlQuery = "SELECT COUNT(*) FROM Rooms";
                    conn.Open();
                    using (SqlCommand countCmd = new SqlCommand(SqlQuery, conn))
                        count = (int)countCmd.ExecuteScalar();
                }

                if (count > 0)
                {
                    cb_FormThemSuatChieu_PhongChieu.Enabled = true;
                    string[] rooms = new string[count];

                    using (SqlConnection conn = Helper.getdbConnection())
                    {
                        string SqlQuery = "SELECT RoomID, RoomName FROM Rooms";
                        using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                        {
                            conn.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    rooms[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
                                    i++;
                                }
                            }
                        }
                    }
                    cb_FormThemSuatChieu_PhongChieu.DataSource = rooms;
                }
                else
                {
                    cb_FormThemSuatChieu_PhongChieu.Enabled = false;

                }
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phòng chiếu: " + ex.Message);
                return false;
            }
        }

        private bool CheckMovie()
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    string countQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
                    conn.Open();
                    using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                        count = (int)countCmd.ExecuteScalar();
                }


                if (cb_FormThemSuatChieu_TenPhim == null)
                {
                    MessageBox.Show("ComboBox 'cb_FormThemSuatChieu_TenPhim' chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (count > 0)
                {
                    cb_FormThemSuatChieu_TenPhim.Enabled = true;

                    string movieQuery = "SELECT MovieID, Title FROM Movies WHERE Status = N'Đang chiếu'";
                    using (SqlConnection conn = Helper.getdbConnection())
                    using (SqlCommand cmd = new SqlCommand(movieQuery, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> movies = new List<string>();
                            while (reader.Read())
                            {
                                string title = reader.IsDBNull(1) ? "Không rõ tiêu đề" : reader.GetString(1);
                                int id = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                                movies.Add($"{title} (ID: {id})");
                            }

                            cb_FormThemSuatChieu_TenPhim.DataSource = movies;
                        }
                    }
                }
                else
                {
                    cb_FormThemSuatChieu_TenPhim.Enabled = false;
                    cb_FormThemSuatChieu_TenPhim.DataSource = null;
                }

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phim đang chiếu: " + ex.Message);
                return false;
            }
        }

        private void FormThemPhim_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2;
            Color borderColor = Color.MediumSlateBlue;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.Clear();
            dataGridView_FormThemSuatChieu_BangGioChieu.Rows.Clear();
            dataGridView_FormThemSuatChieu_BangPhongChieu.Rows.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            //if (date_FormThemSuatChieu_NgayChieu.Value.Date < DateTime.Today)
            //{
            //    MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
            //    "Lỗi nhập liệu",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Warning);
            //    return;

            //}
            //else if (date_FormThemSuatChieu_NgayChieu.Value.Date == DateTime.Today)
            //{
            //    if (date_FormThemSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
            //    {
            //        MessageBox.Show("Giờ chiếu phải lớn hơn ngày giờ hiện tại!",
            //        "Lỗi nhập liệu",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (cb_FormThemSuatChieu_TenPhim.SelectedItem == null || cb_FormThemSuatChieu_PhongChieu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cả phim và phòng chiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.Count == 0 ||
                dataGridView_FormThemSuatChieu_BangGioChieu.Rows.Count == 0 ||
                dataGridView_FormThemSuatChieu_BangPhongChieu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một ngày chiếu, giờ chiếu và phòng chiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string id = lbl_FormThemSuatChieu_MaSuatChieu.Text;
            foreach (DataGridViewRow rowDate in dataGridView_FormThemSuatChieu_BangNgayChieu.Rows)
            {
                foreach (DataGridViewRow rowTime in dataGridView_FormThemSuatChieu_BangGioChieu.Rows)
                {
                    foreach (DataGridViewRow rowRoom in dataGridView_FormThemSuatChieu_BangPhongChieu.Rows)
                    {
                        using (SqlConnection conn = Helper.getdbConnection())
                        {
                            string SqlQuery = "INSERT INTO Showtimes VALUES (@MovieID, @RoomID, @StartTime, @Price )";
                            using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                            {
                                DateTime time = DateTime.Parse(rowTime.Cells[1].Value.ToString());
                                DateTime date = DateTime.TryParse(rowDate.Cells[1].Value?.ToString(), out var d) ? d : throw new Exception("Ngày chiếu không hợp lệ");
                                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = date.Date + time.TimeOfDay;

                                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = 55000; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
                                int pc = int.Parse(Helper.SubStringBetween(rowRoom.Cells[1].Value.ToString(), " (ID: ", ")"));
                                cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = pc;
                                int mp = int.Parse(Helper.SubStringBetween(cb_FormThemSuatChieu_TenPhim.SelectedItem.ToString(), " (ID: ", ")"));
                                cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = mp;
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
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
                            }
                        }
                    }
                }
            }
            MessageBox.Show(
                "Thêm các suất chiếu thành công",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void date_FormThemSuatChieu_BangNgayChieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView_FormThemSuatChieu_BangNgayChieu.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                int iconSize = 24;
                int padding = 8;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                int editX = e.CellBounds.X + padding;
                int deleteX = editX + iconSize + padding;

                // Vẽ icon sửa
                e.Graphics.DrawImage(Properties.Resources.icons8_edit_32, new Rectangle(editX, iconY, iconSize, iconSize));

                // Vẽ icon xóa
                e.Graphics.DrawImage(Properties.Resources.icons8_delete_32, new Rectangle(deleteX, iconY, iconSize, iconSize));
            }
        }

        private void date_FormThemSuatChieu_BangGioChieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView_FormThemSuatChieu_BangGioChieu.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                int iconSize = 24;
                int padding = 8;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                int editX = e.CellBounds.X + padding;
                int deleteX = editX + iconSize + padding;

                // Vẽ icon sửa
                e.Graphics.DrawImage(Properties.Resources.icons8_edit_32, new Rectangle(editX, iconY, iconSize, iconSize));

                // Vẽ icon xóa
                e.Graphics.DrawImage(Properties.Resources.icons8_delete_32, new Rectangle(deleteX, iconY, iconSize, iconSize));
            }
        }

        private void date_FormThemSuatChieu_BangNgayChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_FormThemSuatChieu_BangNgayChieu.Columns[e.ColumnIndex].Name == "Actions")
            {
                int iconSize = 24;
                int padding = 8;

                var mousePos = dataGridView_FormThemSuatChieu_BangNgayChieu.PointToClient(Cursor.Position);
                var cellRect = dataGridView_FormThemSuatChieu_BangNgayChieu.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int clickX = mousePos.X - cellRect.X;

                int editX = padding;
                int deleteX = editX + iconSize + padding;

                if (clickX >= editX && clickX <= editX + iconSize)
                {
                    // Sửa
                    string thoigianStr = dataGridView_FormThemSuatChieu_BangNgayChieu.Rows[e.RowIndex].Cells["Time"].Value.ToString();

                    try
                    {
                        DateTime thoigian = DateTime.ParseExact(thoigianStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        // Trong CellClick ở form cha:
                        List<DateTime> danhSachNgayKhac = new List<DateTime>();
                        for (int i = 0; i < dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.Count; i++)
                        {
                            if (i == e.RowIndex) continue; // bỏ qua dòng đang sửa
                            var val = dataGridView_FormThemSuatChieu_BangNgayChieu.Rows[i].Cells["Time"].Value;
                            if (val != null && DateTime.TryParseExact(val.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                            {
                                danhSachNgayKhac.Add(dt.Date);
                            }
                        }

                        form_SuaNgayChieu f = new form_SuaNgayChieu(thoigian, danhSachNgayKhac);
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            DateTime thoiGianMoi = f.KetQuaThoiGian;
                            dataGridView_FormThemSuatChieu_BangNgayChieu.Rows[e.RowIndex].Cells["Time"].Value = thoiGianMoi.ToString("dd/MM/yyyy");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Định dạng ngày không hợp lệ.");
                    }
                }
                else if (clickX >= deleteX && clickX <= deleteX + iconSize)
                {
                    // Xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.RemoveAt(e.RowIndex);
                        CapNhatSTT(dataGridView_FormThemSuatChieu_BangNgayChieu);
                    }
                }
            }
        }


        private void date_FormThemSuatChieu_BangGioChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_FormThemSuatChieu_BangGioChieu.Columns[e.ColumnIndex].Name == "Actions")
            {
                int iconSize = 24;
                int padding = 8;

                var mousePos = dataGridView_FormThemSuatChieu_BangGioChieu.PointToClient(Cursor.Position);
                var cellRect = dataGridView_FormThemSuatChieu_BangGioChieu.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int clickX = mousePos.X - cellRect.X;
                int editX = padding;
                int deleteX = editX + iconSize + padding;

                if (clickX >= editX && clickX <= editX + iconSize)
                {
                    // Sửa
                    string thoigianStr = dataGridView_FormThemSuatChieu_BangGioChieu.Rows[e.RowIndex].Cells["Time"].Value.ToString();

                    try
                    {
                        DateTime thoigian = DateTime.ParseExact(thoigianStr, "hh:mm tt", CultureInfo.InvariantCulture);

                        // Trong CellClick ở form cha:
                        List<DateTime> danhSachGioKhac = new List<DateTime>();

                        for (int i = 0; i < dataGridView_FormThemSuatChieu_BangGioChieu.Rows.Count; i++)
                        {
                            if (i == e.RowIndex) continue; // bỏ qua dòng đang sửa

                            var val = dataGridView_FormThemSuatChieu_BangGioChieu.Rows[i].Cells["Time"].Value;
                            if (val != null && DateTime.TryParseExact(val.ToString(), "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                            {
                                danhSachGioKhac.Add(dt);
                            }
                        }

                        // Gửi vào form sửa
                        form_SuaGioChieu f = new form_SuaGioChieu(thoigian, danhSachGioKhac, duration);
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            DateTime thoiGianMoi = f.KetQuaThoiGian;
                            dataGridView_FormThemSuatChieu_BangGioChieu.Rows[e.RowIndex].Cells["Time"].Value = thoiGianMoi.ToString("hh:mm tt");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Định dạng ngày không hợp lệ.");
                    }
                }
                else if (clickX >= deleteX && clickX <= deleteX + iconSize)
                {
                    // Xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dataGridView_FormThemSuatChieu_BangGioChieu.Rows.RemoveAt(e.RowIndex);
                        CapNhatSTT(dataGridView_FormThemSuatChieu_BangGioChieu);
                    }
                }
            }
        }



        private void btn_FormThemSuatChieu_ThemNgayChieu_Click(object sender, EventArgs e)
        {
            DateTime ngayChon = date_FormThemSuatChieu_NgayChieu.Value.Date;

            // Chỉ cho phép chọn ngày từ hôm nay trở đi
            if (ngayChon < DateTime.Today)
            {
                MessageBox.Show("Chỉ được chọn ngày chiếu từ hôm nay trở đi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ngay = ngayChon.ToString("dd/MM/yyyy");

            // Kiểm tra xem ngày đã tồn tại trong DataGridView chưa
            foreach (DataGridViewRow row in dataGridView_FormThemSuatChieu_BangNgayChieu.Rows)
            {
                if (row.Cells["Time"].Value != null && row.Cells["Time"].Value.ToString() == ngay)
                {
                    MessageBox.Show("Ngày chiếu này đã được thêm rồi.", "Trùng ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string id = (dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.Count + 1).ToString();
            dataGridView_FormThemSuatChieu_BangNgayChieu.Rows.Add(id, ngay, "");
        }

        private void btn_FormThemSuatChieu_ThemGioChieu_Click(object sender, EventArgs e)
        {
            DateTime selectedTime = date_FormThemSuatChieu_GioChieu.Value;
            selectedTime = new DateTime(selectedTime.Year, selectedTime.Month, selectedTime.Day, selectedTime.Hour, selectedTime.Minute, 0);

            DateTime startTime = selectedTime.Date.AddHours(9);
            DateTime endTime = selectedTime.Date.AddHours(23);

            //if (selectedTime < DateTime.Now.AddMinutes(30))
            //{
            //    MessageBox.Show("Giờ chiếu chỉ được thêm sau 30 phút kể từ hiện tại.", "Thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (selectedTime < startTime || selectedTime > endTime)
            {
                MessageBox.Show("Giờ chiếu chỉ được phép trong khoảng từ 9:00 sáng đến 11:00 tối.", "Thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridView_FormThemSuatChieu_BangGioChieu.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    DateTime existingTime;
                    if (DateTime.TryParse(row.Cells[1].Value.ToString().Trim(), out existingTime))
                    {
                        existingTime = new DateTime(existingTime.Year, existingTime.Month, existingTime.Day, existingTime.Hour, existingTime.Minute, 0);

                        // ❌ Trùng giờ
                        if (existingTime.TimeOfDay == selectedTime.TimeOfDay)
                        {
                            MessageBox.Show("Giờ chiếu đã tồn tại!", "Trùng giờ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // ❌ Quá gần giờ đã có (dưới 30 phút + duration)
                        double minutesDiff = Math.Abs((selectedTime - existingTime).TotalMinutes);
                        if (minutesDiff < (30 + duration))
                        {
                            MessageBox.Show($"Giờ chiếu phải cách suất chiếu khác ít nhất {30 + duration} phút!", "Giờ chiếu quá gần", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            string id = (dataGridView_FormThemSuatChieu_BangGioChieu.Rows.Count + 1).ToString();
            string gio = selectedTime.ToString("hh:mm tt");

            dataGridView_FormThemSuatChieu_BangGioChieu.Rows.Add(id, gio, "");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cb_FormThemSuatChieu_PhongChieu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roomName = cb_FormThemSuatChieu_PhongChieu.SelectedItem.ToString();
            var dgv = dataGridView_FormThemSuatChieu_BangPhongChieu;

            // Kiểm tra phòng đã tồn tại trong DataGridView chưa
            bool exists = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Room"].Value != null && row.Cells["Room"].Value.ToString() == roomName)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                MessageBox.Show("Phòng chiếu này đã được thêm.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int stt = dgv.Rows.Count + 1;
                dgv.Rows.Add(stt.ToString(), roomName, "");
            }
        }

        private void dataGridView_FormThemSuatChieu_BangPhongChieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView_FormThemSuatChieu_BangPhongChieu.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                int iconSize = 24;
                int padding = 8;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                int deleteX = e.CellBounds.X + padding;

                // Chỉ vẽ icon XÓA
                e.Graphics.DrawImage(Properties.Resources.icons8_delete_32, new Rectangle(deleteX, iconY, iconSize, iconSize));
            }
        }

        private void dataGridView_FormThemSuatChieu_BangPhongChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_FormThemSuatChieu_BangPhongChieu.Columns[e.ColumnIndex].Name == "Actions")
            {
                int iconSize = 24;
                int padding = 8;

                var mousePos = dataGridView_FormThemSuatChieu_BangPhongChieu.PointToClient(Cursor.Position);
                var cellRect = dataGridView_FormThemSuatChieu_BangPhongChieu.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int clickX = mousePos.X - cellRect.X;

                // Chỉ xử lý XÓA
                int deleteX = padding;

                if (clickX >= deleteX && clickX <= deleteX + iconSize)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dataGridView_FormThemSuatChieu_BangPhongChieu.Rows.RemoveAt(e.RowIndex);
                        CapNhatSTT(dataGridView_FormThemSuatChieu_BangPhongChieu);
                    }
                }
            }
        }

        private void CapNhatSTT(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }

        private void cb_FormThemSuatChieu_TenPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy chuỗi từ ComboBox (ví dụ: "Avengers (ID: 12)")
            string selected = cb_FormThemSuatChieu_TenPhim.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selected))
            {
                // Tách MovieID từ cuối chuỗi bằng Regex
                var match = Regex.Match(selected, @"\(ID:\s*(\d+)\)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int movieId))
                {
                    duration = GetMovieDuration(movieId);

                    // ✅ Dùng duration tại đây
                    // Ví dụ: lbl_Duration.Text = $"{duration} phút";
                }
            }
        }

        private int GetMovieDuration(int movieId)
        {
            if (movieId < 1) return 0;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT Duration FROM Movies " +
                    "WHERE MovieID = @movieId";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                {
                    cmd.Parameters.Add("@movieId", SqlDbType.Int).Value = movieId;
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
