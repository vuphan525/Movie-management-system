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
    public partial class FormThemNhanVien : Form
    {
        public FormThemNhanVien()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        SqlConnection conn = null;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            date_FormThemNV_NgaySinh.Format = DateTimePickerFormat.Custom;
            date_FormThemNV_NgaySinh.CustomFormat = "dd/MM/yyyy";
            date_FormThemNV_NgaySinh.Value = DateTime.Today.AddYears(-19);
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


        private void them_Click(object sender, EventArgs e)
        {
            if (//string.IsNullOrWhiteSpace(manv.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemNV_HoTen.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemNV_SDT.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormThemNV_Email.Text))

            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DateTime birthDate = date_FormThemNV_NgaySinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Test email format
            try
            {
                MailAddress test_mail = new MailAddress(lbl_FormThemNV_Email.Text);
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
            //SQL section - Users
            string SqlQuery = "INSERT INTO Users OUTPUT INSERTED.UserID VALUES (@Username, @Password, @Role, @Email)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = lbl_FormThemNV_Username.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = lbl_FormThemNV_Password.Text.Trim();
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = cb_FormThemNV_ChucVu.SelectedItem;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = lbl_FormThemNV_Email.Text;

            //cmd.Parameters.Add("@manv", SqlDbType.Char).Value = manv.Text;
            //cmd.Parameters.Add("@trthai", SqlDbType.NVarChar).Value = trangthai.Text;
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
                            "Số điện thoại và email không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    default:
                        throw;
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            //SQL section - Staffs
            SqlQuery = "INSERT INTO Staffs VALUES (@FullName, @Phone, @UserID, @DateOfBirth)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = lbl_FormThemNV_HoTen.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = lbl_FormThemNV_SDT.Text;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = date_FormThemNV_NgaySinh.Value.Date;

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
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemNV_Email.Clear();
            lbl_FormThemNV_HoTen.Clear();
            lbl_FormThemNV_SDT.Clear();
            date_FormThemNV_NgaySinh.Value = DateTime.Today.AddYears(-19);
            cb_FormThemNV_ChucVu.SelectedIndex = 0;
            lbl_FormThemNV_Username.Clear();
            lbl_FormThemNV_Password.Clear();
            this.Refresh();
        }

        private void lbl_FormThemNV_Email_TextChanged(object sender, EventArgs e)
        {
            string email = lbl_FormThemNV_Email.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider1.SetError(lbl_FormThemNV_Email, "Vui lòng nhập email");
            }
            else
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);
                    errorProvider1.SetError(lbl_FormThemNV_Email, ""); 
                }
                catch
                {
                    errorProvider1.SetError(lbl_FormThemNV_Email, "Email không hợp lệ");
                }
            }
        }

    }
}
