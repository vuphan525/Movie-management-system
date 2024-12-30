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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2TextBox1.UseSystemPasswordChar = true;
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int login = 0; //0 - failed; 1 - staff; 2 - admin
            SqlConnection conn = new SqlConnection(ConnString);
            string manv = "admn";
            if (string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox1.Text)) 
            {
                MessageBox.Show(
                    "Vui lòng nhập đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            string SqlQuery = "SELECT MANHANVIEN, USERNAME, PASS, CHUCVU, TENNHANVIEN FROM NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            DataTable dt = ds.Tables["NHANVIEN"];
            bool exists = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["USERNAME"].ToString() == guna2TextBox4.Text.Trim())
                {
                    exists = true;
                    manv = dr["MANHANVIEN"].ToString();
                    if (dr["PASS"].ToString() == guna2TextBox1.Text.Trim())
                    {
                        if (dr["CHUCVU"].ToString() == "ADMIN")
                            login = 2;
                        else
                            login = 1;
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
                        staffForm sf = new staffForm(manv);
                        sf.Show();
                        this.Hide();
                        break;
                    case 2:
                        Adform af = new Adform();
                        af.Show();
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
