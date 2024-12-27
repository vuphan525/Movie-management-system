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
using Microsoft.Identity.Client;
namespace Qlyrapchieuphim
{
    public partial class formbanve : Form
    {
        public List<Guna2Button> sold = new List<Guna2Button>();
        public List<Guna2Button> selected = new List<Guna2Button>();
        public List<Guna2Button> vip = new List<Guna2Button>();
        public List<Guna2Button> vipcount = new List<Guna2Button>();

        public formbanve()
        {
            InitializeComponent();
            InitializeSeats();
            sinhvien.Text = "0";
            treem.Text = "0";
           tongtien.Text = "0 VND";
            cantra.Text = "0 VND";
        }

        private void InitializeSeats()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button seatButton)
                {
                    if (seatButton.Name.StartsWith("guna"))
                    {
                        seatButton.FillColor = Color.FromArgb(115, 46, 213); // Màu ghế thường
                    }
                    else if (seatButton.Name.StartsWith("vip"))
                    {
                        seatButton.FillColor = Color.FromArgb(238, 38, 40); // Màu ghế VIP
                        vip.Add(seatButton);
                    }

                    seatButton.Click += SeatClick;
                    seatButton.ShadowDecoration.Enabled = true;
                    seatButton.ShadowDecoration.Depth = 10; // Độ sâu bóng
                    seatButton.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0);
                }
            }
        }

        public void SeatClick(object sender, EventArgs e)
        {
            Guna2Button a = (Guna2Button)sender;
            if (selected.Contains(a))
            {
                if (a.Name.StartsWith("guna"))
                {
                    a.FillColor = Color.FromArgb(115, 46, 213); // Màu ghế thường
                    selected.Remove(a);
                }
                else if (a.Name.StartsWith("vip"))
                {
                    a.FillColor = Color.FromArgb(238, 38, 40); // Màu ghế VIP
                    selected.Remove(a);
                    vipcount.Remove(a);
                }
                update();
            }
            else
            {
                if (a.Name.StartsWith("vip"))
                {
                    vipcount.Add(a);
                }
                a.FillColor = Color.FromArgb(201, 54, 136); // Màu ghế được chọn
                selected.Add(a);
                update();
            }
        }

        public int a = 0;
        private void update()
        {
            if (selected.Count > 0)
            {
                try
                {
                    int b = string.IsNullOrWhiteSpace(sinhvien.Text) ? 0 : int.Parse(sinhvien.Text);
                    int c = string.IsNullOrWhiteSpace(treem.Text) ? 0 : int.Parse(treem.Text);

                    if (b + c > selected.Count)
                    {
                        c = selected.Count - b;
                        treem.Text = c.ToString();
                    }

                    int d = selected.Count - b - c;
                    a = d * 55000 + vipcount.Count * 5000 + b * 40000 + c * 40000;
                    tongtien.Text = a.ToString() + " VND";
                    cantra.Text = tongtien.Text;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                tongtien.Text = "0 VND";
                cantra.Text = "0 VND";
            }
        }

        private void formbanve_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button68_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button seatButton)
                {
                    if (selected.Contains(seatButton))
                    {
                        sold.Add(seatButton);
                        seatButton.FillColor = Color.DimGray;
                        seatButton.Enabled = false;
                        selected.Remove(seatButton);
                        vipcount.Remove(seatButton);

                    }
                }
            }
            tongtien.Text = "0 VND";
            cantra.Text = "0 VND";

            a = 0;
            Bansanpham bsp = new Bansanpham();
            bsp.Show();
            this.Hide();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button100_Click(object sender, EventArgs e)
        {

        }

        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                khachhang frm = new khachhang();
                frm.ShowDialog();
            }
        }

        private void sinhvien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(sinhvien.Text))
            {
                if (int.TryParse(sinhvien.Text, out int sinhvienCount))
                {
                    int treemCount = string.IsNullOrWhiteSpace(treem.Text) ? 0 : int.Parse(treem.Text);
                    if (sinhvienCount + treemCount > selected.Count)
                    {
                        MessageBox.Show("Tổng số sinh viên và trẻ em không được vượt quá số ghế đã chọn!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sinhvien.Text = (selected.Count - treemCount).ToString();
                        sinhvien.SelectionStart = sinhvien.Text.Length;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sinhvien.Text = "";
                }
            }
            update();
        }

        private void treem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(treem.Text))
            {
                if (int.TryParse(treem.Text, out int treemCount))
                {
                    int sinhvienCount = string.IsNullOrWhiteSpace(sinhvien.Text) ? 0 : int.Parse(sinhvien.Text);
                    if (sinhvienCount + treemCount > selected.Count)
                    {
                        MessageBox.Show("Tổng số sinh viên và trẻ em không được vượt quá số ghế đã chọn!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        treem.Text = (selected.Count - sinhvienCount).ToString();
                        treem.SelectionStart = treem.Text.Length;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    treem.Text = "";
                }
            }
            update();
        }
        private void sinhvien_Enter(object sender, EventArgs e)
        {
            if(sinhvien.Text == "0")
            {
                sinhvien.Text = "";
            }
        }

        private void treem_Enter(object sender, EventArgs e)
        {
            if (treem.Text == "0")
            {
                treem.Text = "";
            }
        }
    }
}
