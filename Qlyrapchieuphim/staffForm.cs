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
using Guna.UI2.WinForms;

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
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            banve1.Hide();
            bangdieukhien1.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            //{
            //    Form1 loginForm = new Form1();
            //    loginForm.Show();

            //    this.Hide();
            //}

            guna2Button2.Checked = true;

            // Hiện message box
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sau khi đóng MessageBox, reset lại trạng thái nếu cần
            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide(); // hoặc this.Close();
            }
            else
            {
                // Nếu không đăng xuất, reset lại trạng thái của nút
                guna2Button2.Checked = false;
                this.ActiveControl = null; // gỡ focus
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            //{
            //    Application.Exit();
            //}
            Application.Exit();
        }

        private void staffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // hủy sự kiện đóng form
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            banve1.Show();
            bangdieukhien1.Hide();
        }
    }
}
