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
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemSuatChieu_Load(object sender, EventArgs e)
        {
            date_FormThemSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";
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
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = int.Parse(cb_FormThemSuatChieu_PhongChieu.SelectedItem.ToString()); //VẪN ĐANG SỬ DỤNG CÁC SỐ CÓ SẴN, ĐIỀU CHỈNH KHI CÓ QUẢN LÝ PHÒNG CHIẾU
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
