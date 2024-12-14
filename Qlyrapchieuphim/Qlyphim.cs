using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
<<<<<<< HEAD
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.Data.SqlClient;
=======

>>>>>>> test_database

namespace Qlyrapchieuphim
{
    public partial class Qlyphim : UserControl
    {
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public Qlyphim()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "select MAPHIM, TENPHIM, THELOAI, THOILUONG, MOTA from BOPHIM";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "BOPHIM");
            DataTable dt = ds.Tables["BOPHIM"];
            dataGridView1.DataSource = dt;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(idphim.Text) ||
               string.IsNullOrWhiteSpace(tenphim.Text) ||

               string.IsNullOrWhiteSpace(thoiluong.Text) ||
               string.IsNullOrWhiteSpace(trangthai.Text)||
                string.IsNullOrWhiteSpace(mota.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
                if (!int.TryParse(thoiluong.Text, out int he))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Thời lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), idphim.Text, tenphim.Text, theloai.Text,thoiluong.Text,trangthai.Text,mota.Text );

            Updatea();
        }
        void Updatea()
        {
            idphim.Clear();
            tenphim.Clear();
            theloai.SelectedIndex = 0;
            thoiluong.Clear();
            trangthai.SelectedIndex = 1;
            mota.Clear();
            dataGridView1.ClearSelection();


        }

        private void Qlyphim_Load(object sender, EventArgs e)
        {
            theloai.SelectedIndex = 0;
            
            trangthai.SelectedIndex = 1;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox6.Text = "Tìm kiếm theo tên";
            guna2TextBox6.ForeColor = Color.Gray;
            
        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)


        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(idphim.Text) ||
               string.IsNullOrWhiteSpace(tenphim.Text) ||

               string.IsNullOrWhiteSpace(thoiluong.Text) ||
               string.IsNullOrWhiteSpace(trangthai.Text) ||
                string.IsNullOrWhiteSpace(mota.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(thoiluong.Text, out int he))
            {
                // Hiển thị MessageBox nếu không phải là số
                MessageBox.Show("Thời lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = idphim.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = tenphim.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = theloai.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = thoiluong.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = trangthai.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[6].Value = mota.Text;
            Updatea();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                idphim.Text = row.Cells[1].Value.ToString();
                tenphim.Text = row.Cells[2].Value.ToString();
                theloai.Text = row.Cells[3].Value.ToString();
                thoiluong.Text = row.Cells[4].Value.ToString();
                trangthai.Text = row.Cells[5].Value.ToString();
                mota.Text = row.Cells[6].Value.ToString();
                check = true;
            }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    CapNhatSTT();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                guna2TextBox6.Text = "Tìm kiếm theo tên";
                guna2TextBox6.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox6.Text.ToLower();
                string tenSV = " ";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[2].Value != null)
                        {
                            tenSV = row.Cells[2].Value.ToString().ToLower();

                        }
                        else
                        {

                            MessageBox.Show(" Không có dữ liệu trong bảng!");
                        }

                        if (tenSV.Contains(tenCanTim))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }
       
        private void Qlyphim_Click(object sender, EventArgs e)
        {
           
        }
        public bool check=false;
        private void Qlyphim_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Updatea();
                }
                check = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Updatea();
                }
            }
            check = false;
        }
        
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                
                    dataGridView1.ClearSelection();
                    Updatea();
                     check = false;

            }
        }
        private void Qlyphim_Load(object sender, EventArgs e)
        {
            LoadData();
=======
        
>>>>>>> test_database
        }
    }
}
