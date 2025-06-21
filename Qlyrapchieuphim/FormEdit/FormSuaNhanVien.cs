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
    public partial class FormSuaNhanVien : Form
    {
        public FormSuaNhanVien()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        private string Id;

        public FormSuaNhanVien(string id)
        {
            InitializeComponent();
            Id = id;
        }
        SqlConnection conn = null;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaNhanVien_Load(object sender, EventArgs e)
        {
            date_FormSuaNV_NgaySinh.Format = DateTimePickerFormat.Custom;
            date_FormSuaNV_NgaySinh.CustomFormat = "dd/MM/yyyy";
            LoadDataById();
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

        private void LoadDataById()
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);

            string query = @"
        SELECT s.FullName, s.Phone, s.DateOfBirth, u.Username, u.Password, u.Email, u.Role 
        FROM Staffs s 
        JOIN Users u ON s.UserID = u.UserID 
        WHERE s.StaffID = @StaffID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = int.Parse(Id);

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbl_FormSuaNV_HoTen.Text = reader["FullName"].ToString();
                        lbl_FormSuaNV_SDT.Text = reader["Phone"].ToString();
                        lbl_FormSuaNV_Email.Text = reader["Email"].ToString();
                        lbl_FormSuaNV_Username.Text = reader["Username"].ToString();
                        lbl_FormSuaNV_Password.Text = reader["Password"].ToString();
                        cb_FormSuaNV_ChucVu.SelectedItem = reader["Role"].ToString();

                        if (DateTime.TryParse(reader["DateOfBirth"].ToString(), out DateTime dob))
                        {
                            date_FormSuaNV_NgaySinh.Value = dob;
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsPhoneNumberValid(string phone)
        {
            return phone.All(char.IsDigit);
        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaNV_Email.Clear();
            lbl_FormSuaNV_HoTen.Clear();
            lbl_FormSuaNV_SDT.Clear();
            date_FormSuaNV_NgaySinh.Value = DateTime.Now;
            lbl_FormSuaNV_MaNV.Clear();
            cb_FormSuaNV_ChucVu.SelectedIndex = -1;
            lbl_FormSuaNV_Username.Clear();
            lbl_FormSuaNV_Password.Clear();

        }

        private void them_Click(object sender, EventArgs e)
        {

           
            if (
                   string.IsNullOrWhiteSpace(lbl_FormSuaNV_HoTen.Text) ||
                   string.IsNullOrWhiteSpace(lbl_FormSuaNV_SDT.Text) ||
                   string.IsNullOrWhiteSpace(lbl_FormSuaNV_Email.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsPhoneNumberValid(lbl_FormSuaNV_SDT.Text))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cb_FormSuaNV_ChucVu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            DateTime birthDate = date_FormSuaNV_NgaySinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                MailAddress test_mail = new MailAddress(lbl_FormSuaNV_Email.Text);
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

            //SQL Section - Staffs
            string SqlQuery = "UPDATE Staffs SET " +
                "FullName = @FullName, " +
                "Phone = @Phone, " +
                "DateOfBirth = @DateOfBirth " +
                "OUTPUT INSERTED.UserID " +
                "WHERE StaffID = @StaffID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = int.Parse(Id);
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = lbl_FormSuaNV_HoTen.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = lbl_FormSuaNV_SDT.Text;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = date_FormSuaNV_NgaySinh.Value;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = cb_FormSuaNV_ChucVu.Text;
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
                            "Mã nhân viên không được trùng nhau!",
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
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = lbl_FormSuaNV_Email.Text;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = lbl_FormSuaNV_Username.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = lbl_FormSuaNV_Password.Text.Trim();
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = cb_FormSuaNV_ChucVu.SelectedItem;
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

            //ToDo: Xử lý sửa nhân viên trong database

        }

        private void FormSuaNhanVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}
