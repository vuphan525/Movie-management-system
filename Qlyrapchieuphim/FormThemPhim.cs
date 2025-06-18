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
using System.Runtime.InteropServices;


namespace Qlyrapchieuphim
{
    public partial class FormThemPhim : Form
    {
        public FormThemPhim()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;

        }

        private void FormThemPhim_Load(object sender, EventArgs e)
        {
            date_FormThemPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormThemPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormThemPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormThemPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm phim 
        }

        private void AddPosterButton_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm poster
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhim_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2;
            Color borderColor = Color.MediumSlateBlue; 

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemPhim_MovieID.Clear();
            lbl_FormThemPhim_TenPhim.Clear();
            cb_FormThemPhim_TheLoai.SelectedIndex = -1;
            lbl_FormThemPhim_ThoiLuong.Clear();
            cb_FormThemPhim_TinhTrang.SelectedIndex = -1;
            date_FormThemPhim_NgayNhap.Value = DateTime.Now;
            date_FormThemPhim_NgayPhatHanh.Value = DateTime.Now;
            lbl_FormThemPhim_NhaPhatHanh.Clear();
            lbl_FormThemPhim_MoTa.Clear();
            pictureBox_FormThemPhim_Poster.Image = null; // Assuming guna2PictureBox1 is the picture box for the poster
        }
    }
}
