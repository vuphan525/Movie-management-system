using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Qlyrapchieuphim
{
    public partial class Qlysuatchieu : UserControl
    {
        public Qlysuatchieu()
        {
            InitializeComponent();

            giochieu.ShowUpDown = true;

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            if (giochieu.Value < DateTime.Now && ngaychieu.Value < DateTime.Now.Date)
            {

                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (giochieu.Value < DateTime.Now)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaychieu.Value.Date < DateTime.Now.Date)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

            // Update values in selected row

            dataGridView1.Rows[selectedRowIndex].Cells[1].Value = tenphim.Text;
           
            dataGridView1.Rows[selectedRowIndex].Cells[2].Value = phongchieu.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[3].Value = ngaychieu.Text;
            dataGridView1.Rows[selectedRowIndex].Cells[4].Value = giochieu.Text;

            Updatea();
        }

        private void them_Click(object sender, EventArgs e)
        {
          

            if (giochieu.Value < DateTime.Now && ngaychieu.Value < DateTime.Now.Date)
            {

                MessageBox.Show("Ngày chiếu và giờ chiếu phải lớn hơn ngày giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;



            }
            else
            {
                if (giochieu.Value < DateTime.Now)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Giờ chiếu phải lớn hơn hoặc bằng giờ hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ngaychieu.Value < DateTime.Now.Date)
                {
                    // Hiển thị MessageBox nếu không phải là số
                    MessageBox.Show("Ngày chiếu phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int stt = dataGridView1.RowCount + 1;
            dataGridView1.Rows.Add(stt.ToString("D2"), tenphim.Text,  phongchieu.Text, ngaychieu.Text, giochieu.Text);

            Updatea();
        }
        void Updatea()
        {
            tenphim.SelectedIndex = 0;
           
            phongchieu.SelectedIndex = 0;
            
            ngaychieu.Value = DateTime.Now;
            giochieu.Value = DateTime.Now;
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
            Updatea();
        }
        private void CapNhatSTT()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString("D2"); // Giả sử cột STT là cột đầu tiên
            }
        }

        private void Qlysuatchieu_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            giochieu.Value = DateTime.Now;
            ngaychieu.Value = DateTime.Now;
            tenphim.SelectedIndex = 0;

            phongchieu.SelectedIndex = 0;
            timkiem.Visible = false;
            timkiem.Value = DateTime.Now;
        }
        public bool issearch = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị cho các TextBox
                tenphim.Text = row.Cells[1].Value.ToString();
                
                phongchieu.Text = row.Cells[2].Value.ToString();
                ngaychieu.Text = row.Cells[3].Value.ToString();
                giochieu.Text = row.Cells[4].Value.ToString();

            }
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (!issearch)
            {
                timkiem.Visible = true;

                guna2Button1.Text = "Hủy tìm kiếm";
                issearch = true;
                DateTime a = timkiem.Value.Date;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
                        }

                        if (dateFromRow.Date == a)
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
            else
            {
                timkiem.Visible = false;
                guna2Button1.Text = "Tìm kiếm suất chiếu";
                issearch = false;
                timkiem.Value = DateTime.Now;

            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void timkiem_ValueChanged(object sender, EventArgs e)
        {

            if (issearch)
            {
                DateTime a = timkiem.Value.Date;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (DateTime.TryParse(row.Cells[3].Value.ToString(), out DateTime dateFromRow))
                        {
                            // Do something with dateFromRow
                        }

                        if (dateFromRow.Date == a)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void giochieu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ngaychieu_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
