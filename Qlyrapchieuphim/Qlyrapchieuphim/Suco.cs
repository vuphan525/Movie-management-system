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
    public partial class Suco : UserControl
    {
        public Suco()
        {
            InitializeComponent();
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            tinhtrang.SelectedIndex = 2;
            ngaytiepnhan.Value=DateTime.Now;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(manhanvien.Text)||
                string.IsNullOrWhiteSpace(tensuco.Text)||
                string.IsNullOrWhiteSpace(mota.Text))




            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), manhanvien.Text, tensuco.Text, tinhtrang.Text, ngaytiepnhan.Text, mota.Text);

            Updatea();

        }
        void Updatea()
        {
            tinhtrang.SelectedIndex = 2;
            tensuco.Clear();
          
            manhanvien.Clear();
            ngaytiepnhan.Value = DateTime.Now;
            mota.Clear();
            dataGridView1.ClearSelection();


        }

        private void capnhat_Click(object sender, EventArgs e)


        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(manhanvien.Text) ||
               string.IsNullOrWhiteSpace(tensuco.Text) ||
               string.IsNullOrWhiteSpace(mota.Text))




            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = manhanvien.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = tensuco.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = tinhtrang.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = ngaytiepnhan.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = mota.Text;

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
                manhanvien.Text = row.Cells[1].Value.ToString();
                tensuco.Text = row.Cells[2].Value.ToString();
                tinhtrang.Text = row.Cells[3].Value.ToString();
                ngaytiepnhan.Text = row.Cells[4].Value.ToString();
                mota.Text = row.Cells[5].Value.ToString();

            }
        }
    }
}
