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
using System.Windows.Markup.Localizer;

namespace Qlyrapchieuphim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Helper.IsInWinFormsDesignMode())
            {
                Helper.CopyDatabaseForDesign();
            }
            guna2TextBox1.UseSystemPasswordChar = true;
        }
        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox1.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e) //login button
        {
            int login = 0; //0 - failed; 1 - staff; 2 - admin
            int userID = -1;
            if (string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox1.Text)) 
            {
                MessageBox.Show(
                    "Vui lòng nhập đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            string SqlQuery = "SELECT UserID, Username, Password, Role FROM Users";
            DataSet ds;
            DataTable dt;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
                ds = new DataSet();
                conn.Open();
                adapter.Fill(ds, "Users");
                dt = ds.Tables["Users"];
                conn.Close();
            }
            bool exists = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == guna2TextBox4.Text.Trim())
                {
                    exists = true;
                    userID = (int)dr["UserID"];
                    if (dr["Password"].ToString() == guna2TextBox1.Text.Trim())
                    {
                        switch (dr["Role"].ToString())
                        {
                            case "admin":
                                login = 2;
                                break;
                            case "staff":
                                login = 1;
                                break;
                            default:
                                login = 1;// user khách hàng
                                break;
                        }
                        break;
                    }
                }
            }
            if (!exists)
            {
                MessageBox.Show(
                    "Tài khoản không tồn tại",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            else
            {
                switch (login)
                { 
                    case 1:
                        staffForm sf = new staffForm(userID);
                        sf.Show();
                        this.Hide();
                        break;
                    case 2:
                        DialogResult result = MessageBox.Show(
                            "Vào chế độ ADMIN?",
                            "Thông báo",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Adform af = new Adform();
                            af.Show();
                        }
                        else
                        {
                            staffForm sf1 = new staffForm();
                            sf1.Show();
                        }
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show(
                            "Sai mật khẩu!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Quenmk quenmk = new Quenmk();
            quenmk.Show();
            this.Hide();
        }
    }
}
