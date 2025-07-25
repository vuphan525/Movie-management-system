﻿using Microsoft.Data.SqlClient;
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
        public staffForm()
        {
            InitializeComponent();
            if (Helper.IsInWinFormsDesignMode())
            {
                Helper.CopyDatabaseForDesign();
            }
        }
        public staffForm(int usrid)
        {
            InitializeComponent();
            if (Helper.IsInWinFormsDesignMode())
            {
                Helper.CopyDatabaseForDesign();
            }
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
            qlykhachhang1.Hide();
            suco1.Hide();
            banve1.Hide();
            bangdieukhien1.Show();
        }

        private void staffForm_Load(object sender, EventArgs e)
        {
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
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = manv;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        role = cmd.ExecuteScalar().ToString();
                        conn.Close();
                    }
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
            using (SqlConnection conn = Helper.getdbConnection())
            {
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@UserID", SqlDbType.Char).Value = manv;
                conn.Open();
                try
                {
                    tennv = cmd.ExecuteScalar()?.ToString();
                }
                catch (NullReferenceException)
                {
                    return;
                }
                if (tennv.IsNullOrEmpty())
                    return;
                conn.Close();
            }
            label3.Text = "Xin chào, " + tennv + " (" + manv + ")";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            HideAllUserControls();  
            banve1.Show();
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            qlykhachhang1.Show();
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            HideAllUserControls();
            suco1.Show();
           
        }
        private void HideAllUserControls()
        {
            banve1.Hide();
            bangdieukhien1.Hide();
            qlykhachhang1.Hide();
            suco1.Hide();
            qlyhoadon1.Hide();
        }

        private void suco1_Load(object sender, EventArgs e)
        {

        }

        private void qlykhachhang1_Load(object sender, EventArgs e)
        {

        }

        private void banve1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            qlyhoadon1.Show();
        }
    }
}
