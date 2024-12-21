using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    public partial class Qlynhansu : UserControl
    {
        public Qlynhansu()
        {
            InitializeComponent();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(manv.Text) ||
                string.IsNullOrWhiteSpace(hoten.Text) ||
                string.IsNullOrWhiteSpace(sodienthoai.Text) ||
                string.IsNullOrWhiteSpace(email.Text) )
                
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime birthDate = ngaysinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), manv.Text, hoten.Text, sodienthoai.Text, email.Text,ngaysinh.Text,trangthai.Text);

            manv.Clear();
            hoten.Clear();
            sodienthoai.Clear();
            email.Clear();
            trangthai.SelectedIndex = 1;
            ngaysinh.Value = DateTime.Now;
            dataGridView1.ClearSelection();


        }

        private void Qlynhansu_Load(object sender, EventArgs e)
        {
            trangthai.SelectedIndex = 1;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox5.Text = "Tìm kiếm theo tên";
            guna2TextBox5.ForeColor = Color.Gray;
            ngaysinh.Value = DateTime.Now;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(manv.Text) ||
                   string.IsNullOrWhiteSpace(hoten.Text) ||
                   string.IsNullOrWhiteSpace(sodienthoai.Text) ||
                   string.IsNullOrWhiteSpace(email.Text) )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DateTime birthDate = ngaysinh.Value;

            // Tính tuổi hiện tại
            int age = DateTime.Now.Year - birthDate.Year;

            // Nếu chưa đủ 18 tuổi hoặc ngày sinh lớn hơn ngày hiện tại
            if (age < 18 || birthDate > DateTime.Now)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          

            // Get selected row index
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = manv.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = hoten.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = sodienthoai.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = email.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = ngaysinh.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[6].Value = trangthai.Text;

            // Clear textboxes (optional)
            manv.Clear();
            hoten.Clear();
            sodienthoai.Clear();
            email.Clear();
            trangthai.SelectedIndex = 1;
            ngaysinh.Value=DateTime.Now;
            dataGridView1.ClearSelection();


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
            manv.Clear();
            hoten.Clear();
            sodienthoai.Clear();
            email.Clear();
            trangthai.SelectedIndex = 1;
            ngaysinh.Value = DateTime.Now;
            dataGridView1.ClearSelection();

        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                manv.Text = row.Cells[1].Value.ToString();
                hoten.Text = row.Cells[2].Value.ToString();
                sodienthoai.Text = row.Cells[3].Value.ToString();
                email.Text = row.Cells[4].Value.ToString();
                ngaysinh.Text = row.Cells[5].Value.ToString();
                trangthai.Text= row.Cells[6].Value.ToString();
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox5.Text.ToLower();
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

        private void guna2TextBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox5.Text))
            {
                guna2TextBox5.Text = "Tìm kiếm theo tên";
                guna2TextBox5.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox5_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox5.Text = "";

                guna2TextBox5.ForeColor = Color.Black;
            }
        }
    }
}
