using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Qlyrapchieuphim
{
    public partial class Qlykhachhang : UserControl
    {
        public Qlykhachhang()
        {
            InitializeComponent();
        }


        private void them_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(makh.Text) ||
                string.IsNullOrWhiteSpace(hotenkh.Text) ||
                string.IsNullOrWhiteSpace(sdt.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(diemtichluy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), makh.Text, hotenkh.Text, sdt.Text, email.Text, diemtichluy.Text);

            makh.Clear();
            hotenkh.Clear();
            sdt.Clear();
            email.Clear();
            diemtichluy.Clear();
            dataGridView1.ClearSelection();

        }

        

        private void Qlykhachhang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            guna2TextBox6.Text = "Tìm kiếm theo tên";
            guna2TextBox6.ForeColor = Color.Gray;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                makh.Text = row.Cells[1].Value.ToString();
                hotenkh.Text = row.Cells[2].Value.ToString();
                sdt.Text = row.Cells[3].Value.ToString();
                email.Text = row.Cells[4].Value.ToString();
                diemtichluy.Text = row.Cells[5].Value.ToString();
            }

        }


        private void capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(makh.Text) ||
                    string.IsNullOrWhiteSpace(hotenkh.Text) ||
                    string.IsNullOrWhiteSpace(sdt.Text) ||
                    string.IsNullOrWhiteSpace(email.Text) ||
                    string.IsNullOrWhiteSpace(diemtichluy.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get selected row index
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = makh.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = hotenkh.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = sdt.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = email.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = diemtichluy.Text;

            // Clear textboxes (optional)
            makh.Clear();
            hotenkh.Clear();
            sdt.Clear();
            email.Clear();
            diemtichluy.Clear();
            dataGridView1.ClearSelection();
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
            makh.Clear();
            hotenkh.Clear();
            sdt.Clear();
            email.Clear();
            diemtichluy.Clear();
            dataGridView1.ClearSelection();
        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
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

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo tên")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
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
    }
}
