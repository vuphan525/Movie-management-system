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
    public partial class Voucher : UserControl
    {
        public Voucher()
        {
            
            InitializeComponent();
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            trangthai.SelectedIndex = 1;
            hieuluctu.Value = DateTime.Now;
            denngay.Value = DateTime.Now;
            guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
            guna2TextBox6.ForeColor = Color.Gray;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(menhgia.Text, out int so))
            {

                MessageBox.Show("Mệnh giá phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), maphathanh.Text, menhgia.Text+" VND", hieuluctu.Text, denngay.Text, trangthai.Text);

            Updatea();
        }
        void Updatea()
        {
            trangthai.SelectedIndex = 1;
            maphathanh.Clear();

            menhgia.Clear();
            hieuluctu.Value = DateTime.Now;
            denngay.Value = DateTime.Now;
            dataGridView1.ClearSelection();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(menhgia.Text, out int so))
            {

                MessageBox.Show("Mệnh giá phải được nhập dươi dạng một số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = maphathanh.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = menhgia.Text+" VND";
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = hieuluctu.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = denngay.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[5].Value = trangthai.Text;

            Updatea();
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
                maphathanh.Text = row.Cells[1].Value.ToString();
                menhgia.Text = RemoveVND(row.Cells[2].Value.ToString());
                hieuluctu.Text = row.Cells[3].Value.ToString();
                denngay.Text = row.Cells[4].Value.ToString();
                trangthai.Text = row.Cells[5].Value.ToString();

            }
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

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo mã voucher")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
                guna2TextBox6.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "Tìm kiếm theo mã voucher")
            {
                string tenCanTim = guna2TextBox6.Text.ToLower();
                string tenSV = " ";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            tenSV = row.Cells[1].Value.ToString().ToLower();

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            Updatea();
        }
    }
}
