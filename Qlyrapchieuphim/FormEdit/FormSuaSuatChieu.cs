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
namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaSuatChieu : Form
    {
        public FormSuaSuatChieu()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        string id = null;
        public FormSuaSuatChieu(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaSuatChieu_Load(object sender, EventArgs e)
        {
            date_FormSuaSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormSuaSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";

            date_FormSuaSuatChieu_GioChieu.ShowUpDown = true;
            date_FormSuaSuatChieu_GioChieu.Format = DateTimePickerFormat.Custom;
            date_FormSuaSuatChieu_GioChieu.CustomFormat = "hh:mm";

            if (CheckRoom())
                cb_FormSuaSuatChieu_PhongChieu.SelectedIndex = 0;
            if (CheckMovie())
                cb_FormSuaSuatChieu_TenPhim.SelectedIndex = 0;

            date_FormSuaSuatChieu_NgayChieu.Value = DateTime.Today.AddDays(1);
            date_FormSuaSuatChieu_GioChieu.Value = DateTime.Now.AddHours(1);

            LoadThongTinSuatChieu();

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private bool CheckRoom()
        {
            int count;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                conn.Open();
                string SqlQuery = "SELECT COUNT(*) FROM Rooms";
                using (SqlCommand countCmd = new SqlCommand(SqlQuery, conn))
                    count = (int)countCmd.ExecuteScalar();

                if (count > 0)
                {
                    cb_FormSuaSuatChieu_PhongChieu.Enabled = true;

                    SqlQuery = "SELECT RoomID, RoomName FROM Rooms";
                    string[] rooms = new string[count];
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
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
                    cb_FormSuaSuatChieu_PhongChieu.DataSource = rooms;
                }
                else
                {
                    cb_FormSuaSuatChieu_PhongChieu.Enabled = false;

                }
                conn.Close();
            }
            return count > 0;
        }

        private bool CheckMovie()
        {
            int count = 0;

            try
            {
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
                    using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                    {
                        count = (int)countCmd.ExecuteScalar();
                    }
                }

                if (cb_FormSuaSuatChieu_TenPhim == null)
                {
                    MessageBox.Show("ComboBox 'cb_FormThemSuatChieu_TenPhim' chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (count > 0)
                {
                    cb_FormSuaSuatChieu_TenPhim.Enabled = true;

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

                            cb_FormSuaSuatChieu_TenPhim.DataSource = movies;
                        }
                    }
                }
                else
                {
                    cb_FormSuaSuatChieu_TenPhim.Enabled = false;
                    cb_FormSuaSuatChieu_TenPhim.DataSource = null;
                }

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phim đang chiếu: " + ex.Message);
                return false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void date_FormSuaSuatChieu_GioChieu_ValueChanged(object sender, EventArgs e)
        {

        }


        private void cb_FormSuaSuatChieu_PhongChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaSuatChieu_MaSuatChieu.Clear();
            cb_FormSuaSuatChieu_PhongChieu.SelectedIndex = -1;
            cb_FormSuaSuatChieu_TenPhim.SelectedIndex = -1;
            date_FormSuaSuatChieu_NgayChieu.Value = DateTime.Today.AddDays(1);
            date_FormSuaSuatChieu_GioChieu.Value = DateTime.Now.AddHours(1);
            this.Refresh();
        }

        private void LoadThongTinSuatChieu()
        {
            if (string.IsNullOrEmpty(id)) return;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                conn.Open();
                try
                {
                    string sql = @"SELECT s.ShowtimeID, s.MovieID, m.Title, s.RoomID, r.RoomName, s.StartTime, s.Price
                       FROM Showtimes s
                       JOIN Movies m ON s.MovieID = m.MovieID
                       JOIN Rooms r ON s.RoomID = r.RoomID
                       WHERE s.ShowtimeID = @ShowtimeID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ShowtimeID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                lbl_FormSuaSuatChieu_MaSuatChieu.Text = reader["ShowtimeID"].ToString();

                                int movieID = (int)reader["MovieID"];
                                string title = reader["Title"].ToString();
                                string movieDisplay = $"{title} (ID: {movieID})";
                                cb_FormSuaSuatChieu_TenPhim.SelectedItem = movieDisplay;

                                int roomID = (int)reader["RoomID"];
                                string roomName = reader["RoomName"].ToString();
                                string roomDisplay = $"{roomName} (ID: {roomID})";
                                cb_FormSuaSuatChieu_PhongChieu.SelectedItem = roomDisplay;

                                DateTime startTime = (DateTime)reader["StartTime"];
                                date_FormSuaSuatChieu_NgayChieu.Value = startTime.Date;
                                date_FormSuaSuatChieu_GioChieu.Value = DateTime.Today.Add(startTime.TimeOfDay);
                            }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin suất chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void them_Click(object sender, EventArgs e)
        {



            if (date_FormSuaSuatChieu_NgayChieu.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;

            }
            else if (date_FormSuaSuatChieu_NgayChieu.Value.Date == DateTime.Today)
            {
                if (date_FormSuaSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
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
            //Get Price from movieId
            decimal price;
            int movieId = int.Parse(Helper.SubStringBetween(cb_FormSuaSuatChieu_TenPhim.SelectedItem.ToString(), " (ID: ", ")"));
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                string SqlQuery = "SELECT Price FROM Movies WHERE MovieID = @MovieID";
                cmd.CommandText = SqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = movieId;
                conn.Open();
                price = (decimal)cmd.ExecuteScalar();
            }


            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "UPDATE Showtimes SET " +
                    "MovieID = @MovieID, " +
                    "RoomID = @RoomID, " +
                    "StartTime = @StartTime, " +
                    "Price = @Price " +
                    "WHERE ShowtimeID = @ShowtimeID";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                {
                    cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = movieId;
                    int roomID = int.Parse(Helper.SubStringBetween(cb_FormSuaSuatChieu_PhongChieu.SelectedItem.ToString(), " (ID: ", ")"));
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = date_FormSuaSuatChieu_NgayChieu.Value + date_FormSuaSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds();
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.Add("@ShowtimeID", SqlDbType.Int).Value = id;
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Cập nhật thông tin suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
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
