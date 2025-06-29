using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Qlyrapchieuphim
{
    public partial class staffForm : Form
    {
        int manv = -1;
        string tennv = string.Empty;
        private bool isStaff = true;
        SqlConnection conn = null;
        public staffForm()
        {
            InitializeComponent();
        }
        public staffForm(int usrid)
        {
            InitializeComponent();
            manv = usrid;
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

        private void staffForm_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            getUserFullName();
            if (manv != -1)
                banve1.UserID = manv;
        }
        private string getUserRole()
        {
            string role = null;
            if (manv != -1)
            {
                string SqlQuery = "SELECT Role FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = manv;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    role = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }

            }
            return null;
        }
        private void getUserFullName()
        {
            string SqlQuery;
            string tableToSearch = null;
            switch (getUserRole())
            {
                case "staff":
                    tableToSearch = "Staffs";
                    break;
                case "customer":
                    tableToSearch = "Customers";
                    break;
                default:
                    tableToSearch = "Staffs";
                    break;
            }

            SqlQuery = "SELECT FullName FROM " + tableToSearch +
                " WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.Char).Value = manv;
            conn.Open();
            try
            {
                tennv = cmd.ExecuteScalar()?.ToString();
            }
            catch (NullReferenceException)
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                return;
            }
            if (tennv.IsNullOrEmpty())
                return;
            conn.Close();
            label3.Text = "Xin chào, " + tennv + " (" + manv + ")";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            banve1.Show();
            bangdieukhien1.Hide();
        }
    }
}
