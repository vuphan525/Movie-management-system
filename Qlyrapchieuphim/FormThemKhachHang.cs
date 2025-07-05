using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace Qlyrapchieuphim
{
    public partial class FormThemKhachHang : Form
    {
        public FormThemKhachHang()
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

        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {

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
        private void them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_FormThemKH_HoTen.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormThemKH_SDT.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormThemKH_Email.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormThemKH_DiemTichLuy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (lbl_FormThemKH_SDT.Text.Length < 6)
            {
                MessageBox.Show("Số điện thoại quá ngắn!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lbl_FormThemKH_DiemTichLuy.Text, out int diemTL))
            {
                MessageBox.Show("Điểm tích lũy phải là số nguyên!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MailAddress testEmail = new MailAddress(lbl_FormThemKH_Email.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Email không đúng định dạng!",
                    "Lỗi định dạng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);

            // Tạo username giả lập từ tên và số điện thoại
            string username = lbl_FormThemKH_HoTen.Text.Trim().Replace(" ", "") + lbl_FormThemKH_SDT.Text.Substring(0, 4); //username là tên khách hàng bỏ khoảng trắng, và thêm 4 số đầu của sđt

            string sqlUser = "INSERT INTO Users OUTPUT INSERTED.UserID VALUES (@Username, @Password, @Role, @Email)";
            SqlCommand cmd = new SqlCommand(sqlUser, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = lbl_FormThemKH_SDT.Text.Trim(); // Giả sử mật khẩu là số điện thoại
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = "customer";
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = lbl_FormThemKH_Email.Text;

            int userID;
            try
            {
                conn.Open();
                userID = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!",
                        "Lỗi nhập liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else throw;
            }

            // Thêm vào bảng Customers
            string sqlCustomer = "INSERT INTO Customers (FullName, Phone, LoyaltyPoints, UserID) VALUES (@FullName, @Phone, @LoyaltyPoints, @UserID)";
            cmd = new SqlCommand(sqlCustomer, conn);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = lbl_FormThemKH_HoTen.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lbl_FormThemKH_SDT.Text;
            cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = diemTL;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Khách hàng đã tồn tại!",
                        "Lỗi nhập liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemKH_DiemTichLuy.Clear();
            lbl_FormThemKH_Email.Clear();
            lbl_FormThemKH_HoTen.Clear();
            lbl_FormThemKH_SDT.Clear();
            this.Refresh();
        }

        
    }
}
