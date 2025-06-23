using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaPhongChieu : Form
    {
        public FormSuaPhongChieu()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            lbl_FormSuaPhongChieu_MaPhong.Enabled = false;
        }
        public string id = null;
        public SqlConnection conn = null;
        public FormSuaPhongChieu(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormSuaPhongChieu_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            LoadRoomData(id);
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
            lbl_FormSuaPhongChieu_MaPhong.Clear();
            lbl_FormSuaPhongChieu_TenPhong.Clear();
            lbl_FormSuaPhongChieu_SoGhe.Clear();
            cb_FormSuaPhongChieu_DinhDang.SelectedIndex = -1;
        }

        private void CapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_FormSuaPhongChieu_TenPhong.Text) ||
        string.IsNullOrWhiteSpace(lbl_FormSuaPhongChieu_SoGhe.Text) ||
        cb_FormSuaPhongChieu_DinhDang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số ghế có phải là số nguyên dương không
            if (!int.TryParse(lbl_FormSuaPhongChieu_SoGhe.Text.Trim(), out int soGhe) || soGhe <= 0)
            {
                MessageBox.Show("Số ghế phải là một số nguyên dương.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu sau khi đã kiểm tra
            string tenPhong = lbl_FormSuaPhongChieu_TenPhong.Text.Trim();
            string dinhDang = cb_FormSuaPhongChieu_DinhDang.SelectedItem.ToString();

            // TODO: Thêm logic lưu vào CSDL ở đây nếu cần
            
            string sql = "UPDATE Rooms SET " +
                "RoomName = @TenPhong, " +
                "SeatCount = @SoGhe, " +
                "RoomType = @DinhDang " +
                "WHERE RoomID = @RoomID";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@SoGhe", soGhe);
                cmd.Parameters.AddWithValue("@DinhDang", dinhDang);
                cmd.Parameters.AddWithValue("@RoomID", int.Parse(id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            MessageBox.Show("Cập nhật thông tin phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadRoomData(string roomId)
        {
            if (roomId.IsNullOrEmpty())
                return;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = int.Parse(roomId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbl_FormSuaPhongChieu_MaPhong.Text = reader["RoomID"].ToString();
                        lbl_FormSuaPhongChieu_TenPhong.Text = reader["RoomName"].ToString();
                        cb_FormSuaPhongChieu_DinhDang.SelectedItem = reader["RoomType"].ToString();
                        lbl_FormSuaPhongChieu_SoGhe.Text = reader["SeatCount"].ToString();
                    }
                }
            }
        }

    }
}
