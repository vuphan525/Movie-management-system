﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Qlyrapchieuphim
{
    public partial class bangdieukhien : UserControl
    {
        public bangdieukhien()
        {
            InitializeComponent();
            
        }

        private void LoadMOV()
        {
            string SqlQuery = "select Title, Genre, Duration from Movies " +
                "WHERE Status = @state";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@state", SqlDbType.NVarChar).Value = "Đang chiếu";
                DataSet ds = new DataSet();
                conn.Open();
                adapter.Fill(ds, "Movies");
                conn.Close();
                DataTable dt = ds.Tables["Movies"];
                dataGridView1.DataSource = dt;
            }
        }
        private void LoadNV()
        {
            string SqlQuery = "SELECT COUNT(*) FROM Staffs ";
            using (SqlConnection conn = Helper.getdbConnection())
            {
                int sonv;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    sonv = (int)cmd.ExecuteScalar();
                conn.Close();
                label3.Text = sonv.ToString();
            }

        }
        private void LoadMovCount()
        {
            string SqlQuery = "SELECT COUNT(*) FROM Movies ";
            using (SqlConnection conn = Helper.getdbConnection())
            {
                int sophim;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    sophim = (int)cmd.ExecuteScalar();
                conn.Close();
                label2.Text = sophim.ToString();
            }

        }

        private void bangdieukhien_Load(object sender, EventArgs e)
        {
            LoadMOV();
            LoadNV();
            LoadMovCount();
        }

        private void bangdieukhien_Paint(object sender, PaintEventArgs e)
        {
            LoadMOV();
            LoadNV();
            LoadMovCount();
        }
    }
}
