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
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MASP, TENSP, LOAI, GIA, SOLUONG, PICTUREPATH FROM SANPHAM";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SANPHAM");
            DataTable dt = ds.Tables["SANPHAM"];

            foreach(DataRow dr in dt.Rows)
            {
                Sanpham newsp = new Sanpham();
                newsp.Ten.Text = dr.Field<string>("TENSP");
                newsp.Gia.Text = dr.Field<double>("GIA").ToString();
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
    }
}
