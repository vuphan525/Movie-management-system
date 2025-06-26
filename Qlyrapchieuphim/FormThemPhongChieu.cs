using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    public partial class FormThemPhongChieu : Form
    {
        public FormThemPhongChieu()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        private SqlConnection conn = null;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhongChieu_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
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
            lbl_FormThemPhongChieu_MaPhong.Clear();
            lbl_FormThemPhongChieu_TenPhong.Clear();
            lbl_FormThemPhongChieu_SoGhe.Clear();
            cb_FormThemPhongChieu_DinhDang.SelectedIndex = -1;
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_FormThemPhongChieu_TenPhong.Text) ||
        string.IsNullOrWhiteSpace(lbl_FormThemPhongChieu_SoGhe.Text) ||
        cb_FormThemPhongChieu_DinhDang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số ghế có phải là số nguyên dương không
            if (!int.TryParse(lbl_FormThemPhongChieu_SoGhe.Text.Trim(), out int soGhe) || soGhe <= 0)
            {
                MessageBox.Show("Số ghế phải là một số nguyên dương.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu sau khi đã kiểm tra
            string tenPhong = lbl_FormThemPhongChieu_TenPhong.Text.Trim();
            string dinhDang = cb_FormThemPhongChieu_DinhDang.SelectedItem.ToString();
            int roomID;

            // TODO: Thêm logic lưu vào CSDL ở đây nếu cần
            // Ví dụ (giả sử có SqlConnection conn):

            string SqlQuery = "INSERT INTO Rooms (RoomName, SeatCount, RoomType) OUTPUT Inserted.RoomID VALUES (@TenPhong, @SoGhe, @DinhDang)";
            using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@SoGhe", soGhe);
                cmd.Parameters.AddWithValue("@DinhDang", dinhDang);

                conn.Open();
                roomID = (int)cmd.ExecuteScalar();
                conn.Close();
            }

            //Thêm các ghế vào bảng Seats
            using (SqlCommand cmd = conn.CreateCommand())
            {
                SqlQuery = "INSERT INTO Seats (RoomID, SeatNumber, SeatType) VALUES ";
                for (char c = 'A'; c <= 'J'; c++)
                {
                    for (int i = 1; i <= 14; i++)
                    {
                        string SeatType;
                        string SeatNumber = c.ToString() + i.ToString();

                        if ((3 <= i && i <= 12) && ('E' <= c && c <= 'I'))
                            SeatType = "VIP";
                        else
                            SeatType = "Standard";
                        SqlQuery += "(@RoomID"+ SeatNumber+ ", @SeatNumber" + SeatNumber + ", @SeatType" + SeatNumber + ")";
                        if (i != 14 || c != 'J')
                            SqlQuery += ", ";
                        cmd.Parameters.Add("@RoomID" + SeatNumber, SqlDbType.Int).Value = roomID;
                        cmd.Parameters.Add("@SeatNumber" + SeatNumber, SqlDbType.NVarChar).Value = SeatNumber;
                        cmd.Parameters.Add("@SeatType" + SeatNumber, SqlDbType.NVarChar).Value = SeatType;
                    }
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SqlQuery;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            

            MessageBox.Show("Thêm phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
