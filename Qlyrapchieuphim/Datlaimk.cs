using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Qlyrapchieuphim
{
    public partial class Datlaimk : Form
    {
        int manv;
        public Datlaimk()
        {
            InitializeComponent();
            passBox.UseSystemPasswordChar = true;
            pass_repeatBox.UseSystemPasswordChar = true;
        }
        public Datlaimk(int mnv)
        {
            InitializeComponent();
            passBox.UseSystemPasswordChar = true;
            pass_repeatBox.UseSystemPasswordChar = true;
            manv = mnv;
        }
        SqlConnection conn = null;

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            passBox.Text = passBox.Text.Trim();
            pass_repeatBox.Text = pass_repeatBox.Text.Trim();
            if (passBox.Text != pass_repeatBox.Text)
            {
                MessageBox.Show(
                    "Mật khẩu và xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            string SqlQuery = "UPDATE Users SET " +
                "Password = @Password " +
                "WHERE (UserID = @UserID)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Password",SqlDbType.NVarChar).Value = passBox.Text.Trim();
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = manv;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            DialogResult result = MessageBox.Show(
                "Mật khẩu đã được đổi thành công!",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                passBox.UseSystemPasswordChar = false;
                pass_repeatBox.UseSystemPasswordChar = false;
            }
            else
            {
                passBox.UseSystemPasswordChar = true;
                pass_repeatBox.UseSystemPasswordChar = true;
            }
        }

        private void Datlaimk_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
        }
    }
}
