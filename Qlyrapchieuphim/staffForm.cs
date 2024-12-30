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
    public partial class staffForm : Form
    {
        string manv, tennv;
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public staffForm()
        {
            InitializeComponent();
        }
        public staffForm(string mnv)
        {
            InitializeComponent();
            manv = mnv;
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT TENNHANVIEN FROM NHANVIEN " +
                "WHERE MANHANVIEN = @manv";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = manv;
            conn.Open();
            tennv = cmd.ExecuteScalar().ToString();
            conn.Close();
            label3.Text = "Xin chào, " + tennv + " (" + manv + ")";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Application.Exit();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            banve1.Hide();
            bangdieukhien1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            banve1.Show();
            bangdieukhien1.Hide();
        }
    }
}
