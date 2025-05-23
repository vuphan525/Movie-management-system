﻿using System;
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
using System.IO;
using System.Threading;

namespace Qlyrapchieuphim
{
    public partial class Bansanpham : Form
    {
        public Bansanpham()
        {
            InitializeComponent();
            MakeSpList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = sp_list;
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        DataTable dt;
        DataTable sp_list = new DataTable();
        private void MakeSpList()
        {
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "id";
            sp_list.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "num";
            sp_list.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            sp_list.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "price";
            sp_list.Columns.Add(column);
        }
        

        int total_price = 0;
        public int Total
        {
            get { return total_price; }
        }
        public DataTable List
        {
            get { return sp_list; }
        }
        private void LoadData()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MASP, TENSP, LOAI, GIA, SOLUONG, PICTUREPATH FROM SANPHAM";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SANPHAM");
            dt = ds.Tables["SANPHAM"];
            foreach(DataRow dr in dt.Rows)
            {
                Sanpham newsp = new Sanpham();
                newsp.Ten.Text = dr.Field<string>("TENSP");
                newsp.Gia.Text = dr.Field<double>("GIA").ToString();
                newsp.ID.Text = dr.Field<string>("MASP").ToString();
                newsp.Type = dr.Field<string>("LOAI").ToString();
                newsp.Count = dr.Field<int>("SOLUONG");
                if (newsp.Count <= 0)
                    newsp.Enabled = false;
                
                string relative_picture_path = dr.Field<string>("PICTUREPATH");
                picture_url = Path.Combine(projectFolder, relative_picture_path);
                try
                {
                    using (FileStream stream = new FileStream(picture_url, FileMode.Open))
                    {
                        newsp.img.Image = Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(relative_picture_path))
                    {
                        if (ex is FileNotFoundException)
                        {
                            MessageBox.Show(
                            "Không tìm thấy file ảnh cho sản phẩm: " + newsp.Ten.Text,
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        if (ex is DirectoryNotFoundException)
                        {
                            MessageBox.Show(
                            "Không tìm thấy folder ảnh cho sản phẩm: " + newsp.Ten.Text,
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        newsp.img.Image = null;
                    }
                }
                newsp.Click += (s, e) => Sp_Click(newsp, e);
                foreach (Control c in newsp.Controls)
                {
                    c.Click += (s, e) => Sp_Click(newsp, e);
                }
                flowLayoutPanel1.Controls.Add(newsp);
            }
            conn.Close();
        }

        private void thanhtoan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bansanpham_Enter(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Bansanpham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool CheckInventory (string msp, int selected)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT SOLUONG FROM SANPHAM WHERE MASP = @msp";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@msp", SqlDbType.Char).Value = msp;
            conn.Open();
            int inv = (int)cmd.ExecuteScalar();
            conn.Close();
            if (selected > inv)
                return false;
            return true;
        }
        private void Sp_Click (object sender, EventArgs e)
        {
            Sanpham sp = sender as Sanpham;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                int index = r.Index;
                if (sp_list.Rows[index]["id"].ToString() == sp.ID.Text)
                {
                    int num_select = int.Parse(sp_list.Rows[index]["num"].ToString()) + 1;
                    bool still_left = CheckInventory(sp_list.Rows[index]["id"].ToString(), num_select);
                    if (!still_left)
                    {
                        MessageBox.Show(
                            "Đã chọn số sản phẩm tối đa!",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    sp_list.Rows[index]["num"] = num_select;
                    dataGridView1.DataSource = sp_list;
                    CalculateTotal();
                    return;
                }
            }
            DataRow row = sp_list.NewRow();
            
            row["id"] = sp.ID.Text;
            row["name"] = sp.Ten.Text;
            row["price"] = double.Parse(sp.Gia.Text);
            row["num"] = 1;
            sp_list.Rows.Add(row);
            dataGridView1.DataSource = sp_list;
            CalculateTotal();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "Column6" && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    sp_list.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.DataSource = sp_list;
            }
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int index = row.Index;
                    int sl = 0;
                    double pr = 0;
                    if (!(sp_list.Rows[index]["num"] == null))
                        sl = int.Parse(sp_list.Rows[index]["num"].ToString());
                    if (!(sp_list.Rows[index]["price"] == null))
                        pr = double.Parse(sp_list.Rows[index]["price"].ToString());
                    total += sl * pr;
                }
            }
            total_price = (int)(Math.Truncate(total * 100) / 100);
            label5.Text = total_price.ToString();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }
        private void Bansanpham_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
