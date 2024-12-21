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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Qlyrapchieuphim
{
    public partial class Qlysanpham : UserControl
    {
        public Qlysanpham()
        {
            InitializeComponent();
        }

        private void Qlysanpham_Load(object sender, EventArgs e)
        {
            loai.SelectedIndex = 0;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox4.Text = "Tìm kiếm theo tên";
            guna2TextBox4.ForeColor = Color.Gray;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void them_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(ten.Text) ||

               string.IsNullOrWhiteSpace(giatien.Text) ||
               string.IsNullOrWhiteSpace(soluong.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((!int.TryParse(soluong.Text, out int so)) && (!double.TryParse(giatien.Text, out double gia)))
            {

                MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (!int.TryParse(soluong.Text, out int he))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Số lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!double.TryParse(giatien.Text, out double hea))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giá tiền  phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int a = ConvertStringToInteger(giatien.Text);
            int b = ConvertStringToInteger(soluong.Text);
            string hj = b.ToString("D2");
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), masp.Text, ten.Text, loai.Text, a+" VND",hj);

            Updatea();
        }

        int ConvertStringToInteger(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                // Xử lý trường hợp không hợp lệ (ví dụ: thông báo lỗi)
                return 0; // Hoặc một giá trị mặc định khác
            }
        }
        string RemoveVND(string input)
        {
            return input.Replace("VND", "");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                masp.Text = row.Cells[1].Value.ToString();
                ten.Text = row.Cells[2].Value.ToString();
                loai.Text = row.Cells[3].Value.ToString();
                giatien.Text = RemoveVND(row.Cells[4].Value.ToString());
                soluong.Text = row.Cells[5].Value.ToString();
                
            }
        }

        private void capnhat_Click(object sender, EventArgs e)
        {

          
            if (string.IsNullOrWhiteSpace(masp.Text) ||
               string.IsNullOrWhiteSpace(ten.Text) ||

               string.IsNullOrWhiteSpace(giatien.Text) ||
               string.IsNullOrWhiteSpace(soluong.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((!int.TryParse(soluong.Text, out int so)) && (!double.TryParse(giatien.Text, out double gia)))
            {
                
                    MessageBox.Show("Giá tiền và số lượng phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                
                
            }
            else
            {
                if (!int.TryParse(soluong.Text, out int he))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Số lượng phải được nhập dươi dạng một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!double.TryParse(giatien.Text, out double hea))
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giá tiền  phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            


               
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row
            int a = ConvertStringToInteger(giatien.Text);
            int b = ConvertStringToInteger(soluong.Text);
            string hj = b.ToString("D2");
          
            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = masp.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = ten.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = loai.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = a+" VND";
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = hj;
            Updatea();
         
           

        }

        private void xoa_Click(object sender, EventArgs e)
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
            Updatea();
            
        }
        void Updatea()
        {
            masp.Clear();
            ten.Clear();
            loai.SelectedIndex = 0;
            giatien.Clear();
            soluong.Clear();
            dataGridView1.ClearSelection();


        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = guna2TextBox4.Text.ToLower();
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

        private void guna2TextBox4_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox4.Text = "";

                guna2TextBox4.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox4.Text))
            {
                guna2TextBox4.Text = "Tìm kiếm theo tên";
                guna2TextBox4.ForeColor = Color.Gray;

            }
        }
    }
}
