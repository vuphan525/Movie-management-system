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
using System.IO;
using System.Threading;

namespace Qlyrapchieuphim
{
    public partial class Bansanpham : Form
    {
        public Bansanpham()
        {
            InitializeComponent();
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        string picture_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        DataTable dt;
        private void LoadData()
        {
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
            Hoadon hd = new Hoadon();   
            hd.Show();
            this.Hide();
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
                if (r.Cells["idColumn"].Value.ToString() == sp.ID.Text)
                {
                    int num_select = int.Parse(r.Cells["numColumn"].Value.ToString()) + 1;
                    bool still_left = CheckInventory(r.Cells["idColumn"].Value.ToString(), num_select);
                    if (!still_left)
                    {
                        MessageBox.Show(
                            "Đã chọn số sản phẩm tối đa!",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    r.Cells["numColumn"].Value = num_select;
                    return;
                }
            }
            int rowID = dataGridView1.Rows.Add();
            
            DataGridViewRow row = dataGridView1.Rows[rowID];
            row.Cells["idColumn"].Value = sp.ID.Text;
            row.Cells["nameColumn"].Value = sp.Ten.Text;
            row.Cells["priceColumn"].Value = sp.Gia.Text;
            row.Cells["numColumn"].Value = 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double total = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int sl = 0;
                    double pr = 0;
                    if (!(row.Cells["numColumn"].Value == null))
                        sl = int.Parse(row.Cells["numColumn"].Value.ToString());
                    if (!(row.Cells["priceColumn"].Value == null))
                        pr = double.Parse(row.Cells["priceColumn"].Value.ToString());
                    total += sl * pr;
                }
            }
            label5.Text = (Math.Truncate(total * 100) / 100).ToString();
        }
    }
}
