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
using static System.Net.WebRequestMethods;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Guna.UI2.WinForms;

namespace Qlyrapchieuphim
{
    public partial class Quenmk : Form
    {
        public Quenmk()
        {
            InitializeComponent();
        }
        int otp;
        int usrID;
        Random Random = new Random();
        private void Quenmk_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (otp.ToString() == "0")
            {
                MessageBox.Show(
                    "Chưa tạo otp",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (otp.ToString() == guna2TextBox1.Text)
            {
                Datlaimk dl = new Datlaimk(usrID);
                dl.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai OTP!");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(guna2TextBox4.Text))
                {
                    MessageBox.Show(
                    "Vui lòng nhập e-mail.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
                guna2TextBox4.Text = guna2TextBox4.Text.Trim();
                string SqlQuery = "SELECT UserID, Email FROM Staffs";
                DataSet ds;
                DataTable dt;
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
                    ds = new DataSet();
                    adapter.Fill(ds, "Staffs");
                    dt = ds.Tables["Staffs"];
                    conn.Close();
                }
                bool exists = false;

                otp = Random.Next(10000, 100000
                 );
                var fromAddress = new MailAddress("movielandcinema123@gmail.com");
                var toAddress = new MailAddress(guna2TextBox4.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Email"].ToString() == guna2TextBox4.Text)
                    {
                        exists = true;
                        usrID = (int)dr["UserID"];
                        break;
                    }
                }
                if (!exists)
                {
                    MessageBox.Show(
                    "Địa chỉ mail không gắn với bất kì tài khoản nào!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
                guna2TextBox4.Enabled = false;
                const string frompass = "kxml dvvp jaiq libr";
                const string subject = "OTP code";
                string body = "Your OTP code is: " + otp.ToString();
                body += "\nThis is for a movielandcinema employee account, if you do not have an account, please ignore this email.";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromAddress.Address, frompass)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show(
                    "Mã OTP đã được gửi qua mail (nếu địa chỉ có tồn tại)",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show(
                        "Địa chỉ mail không đúng định dạng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            guna2TextBox4.Enabled = true;
            guna2TextBox4.Clear();
            guna2TextBox1.Clear();
            otp = new int();
            usrID = -1;
        }
    }
}
