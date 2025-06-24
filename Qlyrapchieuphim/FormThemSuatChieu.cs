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

namespace Qlyrapchieuphim
{
    public partial class FormThemSuatChieu : Form
    {
        public FormThemSuatChieu()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            this.Load += FormThemSuatChieu_Load;


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemSuatChieu_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            date_FormThemSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";
            if (CheckMovie())
                cb_FormThemSuatChieu_TenPhim.SelectedIndex = 0;
            if (CheckRoom())
                cb_FormThemSuatChieu_PhongChieu.SelectedIndex = 0;
            date_FormThemSuatChieu_NgayChieu.Value = DateTime.Now;
            date_FormThemSuatChieu_GioChieu.Value = DateTime.Now + TimeSpan.FromHours(1);
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
                cb_FormThemSuatChieu_PhongChieu.Enabled = true;
                
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
                cb_FormThemSuatChieu_PhongChieu.DataSource = rooms;
            }
            else
            {
                cb_FormThemSuatChieu_PhongChieu.Enabled = false;
                
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }

        private bool CheckMovie()
        {
            int count = 0;

            try
            {
                if (conn == null)
                {
                    conn = Helper.getdbConnection();
                    conn = Helper.CheckDbConnection(conn);
                }

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string countQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
                using (SqlCommand countCmd = new SqlCommand(countQuery, conn))
                {
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
                    using (SqlCommand cmd = new SqlCommand(movieQuery, conn))
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
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
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
        SqlConnection conn = null;
        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemSuatChieu_MaSuatChieu.Clear();
            cb_FormThemSuatChieu_PhongChieu.SelectedIndex = -1;
            cb_FormThemSuatChieu_TenPhim.SelectedIndex = -1;
            date_FormThemSuatChieu_NgayChieu.Value = DateTime.Now;
            date_FormThemSuatChieu_GioChieu.Value = DateTime.Now;
        }
         
        private void them_Click(object sender, EventArgs e)
        {
            if (date_FormThemSuatChieu_NgayChieu.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;

            }
            else if (date_FormThemSuatChieu_NgayChieu.Value.Date == DateTime.Today)
            {
                if (date_FormThemSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds() <= DateTime.Now.TimeOfDay.StripMilliseconds())
                {
                    MessageBox.Show("Giờ chiếu phải lớn hơn ngày giờ hiện tại!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
            }
            if (cb_FormThemSuatChieu_TenPhim.SelectedItem == null || cb_FormThemSuatChieu_PhongChieu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cả phim và phòng chiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            string id = lbl_FormThemSuatChieu_MaSuatChieu.Text;

            string SqlQuery = "INSERT INTO Showtimes VALUES (@MovieID, @RoomID, @StartTime, @Price )";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            //cmd.Parameters.Add("@ShowtimeID", SqlDbType.Char).Value = idTextBox.Text;
            cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = date_FormThemSuatChieu_NgayChieu.Value +date_FormThemSuatChieu_GioChieu.Value.TimeOfDay.StripMilliseconds();
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = 65000; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            int pc = int.Parse(Helper.SubStringBetween(cb_FormThemSuatChieu_PhongChieu.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = pc; //VẪN ĐANG SỬ DỤNG CÁC SỐ CÓ SẴN, ĐIỀU CHỈNH KHI CÓ QUẢN LÝ PHÒNG CHIẾU
            int mp = int.Parse(Helper.SubStringBetween(cb_FormThemSuatChieu_TenPhim.SelectedItem.ToString(), " (ID: ", ")"));
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


        }
    }
}
