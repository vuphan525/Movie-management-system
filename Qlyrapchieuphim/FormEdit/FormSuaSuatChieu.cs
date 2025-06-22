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
        SqlConnection conn = null;
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
            LoadSuatChieuFromDatabase();
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
            date_FormSuaSuatChieu_NgayChieu.Value = DateTime.Now;
            date_FormSuaSuatChieu_GioChieu.Value = DateTime.Now;
        }
        private void LoadSuatChieuFromDatabase()
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);

            string sql = @"
        SELECT s.ShowtimeID, s.MovieID, s.RoomID, s.StartTime, s.Price, m.MovieName
        FROM Showtimes s
        JOIN Movies m ON s.MovieID = m.MovieID
        WHERE s.ShowtimeID = @ShowtimeID";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ShowtimeID", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Lấy các giá trị từ reader
                        lbl_FormSuaSuatChieu_MaSuatChieu.Text = reader["ShowtimeID"].ToString();

                        int roomId = Convert.ToInt32(reader["RoomID"]);
                        DateTime startTime = Convert.ToDateTime(reader["StartTime"]);

                        // Phân tách ngày và giờ
                        date_FormSuaSuatChieu_NgayChieu.Value = startTime.Date;
                        date_FormSuaSuatChieu_GioChieu.Value = DateTime.Today + startTime.TimeOfDay;

                        cb_FormSuaSuatChieu_PhongChieu.SelectedItem = roomId.ToString();

                        // Cập nhật tên phim theo định dạng giống như combobox đang dùng
                        string movieName = reader["MovieName"].ToString();
                        int movieId = Convert.ToInt32(reader["MovieID"]);
                        string formattedMovie = $"{movieName} (ID: {movieId})";
                        cb_FormSuaSuatChieu_TenPhim.SelectedItem = formattedMovie;
                    }
                }
                conn.Close();
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
                conn = Helper.getdbConnection();
                conn = Helper.CheckDbConnection(conn);
                string id = lbl_FormSuaSuatChieu_MaSuatChieu.Text;

                string SqlQuery = "INSERT INTO Showtimes VALUES (@MovieID, @RoomID, @StartTime, @Price )";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                //cmd.Parameters.Add("@ShowtimeID", SqlDbType.Char).Value = idTextBox.Text;
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = date_FormSuaSuatChieu_NgayChieu.Value + date_FormSuaSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds();
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = 65000; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
                cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = int.Parse(cb_FormSuaSuatChieu_PhongChieu.SelectedItem.ToString()); //VẪN ĐANG SỬ DỤNG CÁC SỐ CÓ SẴN, ĐIỀU CHỈNH KHI CÓ QUẢN LÝ PHÒNG CHIẾU
                int mp = int.Parse(Helper.SubStringBetween(cb_FormSuaSuatChieu_TenPhim.SelectedItem.ToString(), " (ID: ", ")"));
                cmd.Parameters.Add("@MovieID", SqlDbType.Int).Value = mp;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
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
                //add table for logging seats -- XOÁ PHẦN NÀY KHI ĐÃ CÓ QUẢN LÝ PHÒNG CHIẾU

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
                conn.Open();
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
    }
}
