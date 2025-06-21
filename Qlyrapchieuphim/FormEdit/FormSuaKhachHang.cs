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

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaKhachHang : Form
    {
        SqlConnection conn = null;
        public FormSuaKhachHang()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        private string KHId;

        public FormSuaKhachHang(string id)
        {
            InitializeComponent();
            KHId = id;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
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
        private void LoadKhachHang()
        {
            try
            {
                conn = Helper.getdbConnection();
                conn = Helper.CheckDbConnection(conn);

                // Lấy dữ liệu từ bảng Customers và Users bằng CustomerID
                string sql = @"
            SELECT c.FullName, c.Phone, c.LoyaltyPoints, u.Email 
            FROM Customers c 
            JOIN Users u ON c.UserID = u.UserID 
            WHERE c.CustomerID = @CustomerID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = KHId;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbl_FormSuaKH_HoTen.Text = reader["FullName"].ToString();
                    lbl_FormSuaKH_SDT.Text = reader["Phone"].ToString();
                    lbl_FormSuaKH_DiemTichLuy.Text = reader["LoyaltyPoints"].ToString();
                    lbl_FormSuaKH_Email.Text = reader["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (
                    string.IsNullOrWhiteSpace(lbl_FormSuaKH_HoTen.Text) ||
                    string.IsNullOrWhiteSpace(lbl_FormSuaKH_SDT.Text) ||
                    string.IsNullOrWhiteSpace(lbl_FormSuaKH_Email.Text) ||
                    string.IsNullOrWhiteSpace(lbl_FormSuaKH_DiemTichLuy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            int dtl;
            if (!int.TryParse(lbl_FormSuaKH_DiemTichLuy.Text, out dtl))
            {
                MessageBox.Show(
                    "Điểm tích lũy phải là số nguyên.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (lbl_FormSuaKH_SDT.Text.Length < 6)
            {
                MessageBox.Show("Số điện thoại quá ngắn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MailAddress test_mail = new MailAddress(lbl_FormSuaKH_Email.Text);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show(
                    "Địa chỉ mail không đúng định dạng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                    "Lỗi địa chỉ mail.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                return;
            }
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            // Update values in selected row

            //SQL Section - Customers
            string SqlQuery = "UPDATE Customers SET " +
                "FullName = @FullName, " +
                "Phone = @Phone, " +
                "LoyaltyPoints = @LoyaltyPoints " +
                "OUTPUT INSERTED.UserID " +
                "WHERE CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);

            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = int.Parse(KHId);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = lbl_FormSuaKH_HoTen.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lbl_FormSuaKH_SDT.Text;
            cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = dtl;
            int usrID;

            try
            {
                conn.Open();
                usrID = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Mã khách hàng không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }

            //SQL Section - Users
            SqlQuery = "UPDATE Users SET " +
                "Username = @Username, " +
                "Password = @Password, " +
                "Role = @Role, " +
                "Email = @Email " +
                "WHERE UserID = @UserID";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = lbl_FormSuaKH_Email.Text;
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = lbl_FormSuaKH_HoTen.Text.Trim() + lbl_FormSuaKH_SDT.Text.Substring(0, 4);//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = lbl_FormSuaKH_SDT.Text.Trim();//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = "customer";
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;

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
                switch (ex.Number)
                {
                    case 2627: // Unique key violation
                        MessageBox.Show(
                            "Username không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }

        }
    }
}
