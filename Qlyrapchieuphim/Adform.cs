using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Qlyrapchieuphim
{
    public partial class Adform : Form
    {
        
        public Adform()
        {
            InitializeComponent();
            guna2Button6.Enabled = false;
            guna2Button6.Visible = false;
        }
        
        private void voucher1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }
     

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Hide();
            qlykhachhang1.Hide();
            doanhthu1.Hide();
            voucher1.Hide();
            suco1.Hide();
            bangdieukhien1.ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            bangdieukhien1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            qlyphim1.Show();
            bangdieukhien1.Hide();
            doanhthu1.Hide();
            qlykhachhang1.Hide();
            qlynhansu1.Hide();
            qlysanpham1.Hide();
            qlysuatchieu1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Show();
            bangdieukhien1.Hide();
            doanhthu1.Hide();
            qlykhachhang1.Hide();
            qlynhansu1.Hide();
            qlysanpham1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Show();
            bangdieukhien1.Hide();
            doanhthu1.Hide();
            qlykhachhang1.Hide();
            qlynhansu1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Show();
            bangdieukhien1.Hide();
            doanhthu1.Hide();
            qlykhachhang1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Hide();
            qlykhachhang1.Show();
            bangdieukhien1.Hide();
            doanhthu1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Hide();
            qlykhachhang1.Hide();
            doanhthu1.Show();
            bangdieukhien1.Hide();
            suco1.Hide();
            voucher1.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Hide();
            qlykhachhang1.Hide();
            doanhthu1.Hide();
            voucher1.Show();
            bangdieukhien1.Hide();
            suco1.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            qlyphim1.Hide();
            qlysuatchieu1.Hide();
            qlysanpham1.Hide();
            qlynhansu1.Hide();
            qlykhachhang1.Hide();
            doanhthu1.Hide();
            voucher1.Hide();
            suco1.Show();
            bangdieukhien1.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            //{
            //    Form1 loginForm = new Form1();
            //    loginForm.Show();
            //    guna2Button9.Enabled = false;
            //    this.Hide();
            //}
            // Đặt trạng thái Checked để giữ màu pressed

            guna2Button9.Checked = true;

            // Hiện message box
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sau khi đóng MessageBox, reset lại trạng thái nếu cần
            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide(); // hoặc this.Close();
            }
            else
            {
                // Nếu không đăng xuất, reset lại trạng thái của nút
                guna2Button9.Checked = false;
                this.ActiveControl = null; // gỡ focus
            }
        }

        private void guna2Button9_MouseLeave(object sender, EventArgs e)
        {
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            //{
            //    Application.Exit();
            //}
            Application.Exit();
        }

        private void Adform_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // hủy sự kiện đóng form
            }
        }
    }
}
