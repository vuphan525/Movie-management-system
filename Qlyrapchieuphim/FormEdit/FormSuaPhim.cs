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

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaPhim : Form
    {
        public FormSuaPhim()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaPhim_Load(object sender, EventArgs e)
        {
            date_FormSuaPhim_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayNhap.CustomFormat = "dd/MM/yyyy";
            date_FormSuaPhim_NgayPhatHanh.Format = DateTimePickerFormat.Custom;
            date_FormSuaPhim_NgayPhatHanh.CustomFormat = "dd/MM/yyyy";
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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaPhim_MovieID.Clear();
            lbl_FormSuaPhim_TenPhim.Clear();
            cb_FormSuaPhim_TheLoai.SelectedIndex = -1;
            lbl_FormSuaPhim_ThoiLuong.Clear();
            cb_FormSuaPhim_TinhTrang.SelectedIndex = -1;
            date_FormSuaPhim_NgayNhap.Value = DateTime.Now;
            date_FormSuaPhim_NgayPhatHanh.Value = DateTime.Now;
            lbl_FormSuaPhim_NhaPhatHanh.Clear();
            lbl_FormSuaPhim_MoTa.Clear();
            pictureBox_FormSuaPhim_Poster.Image = null; // Assuming guna2PictureBox1 is the picture box for the poster
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý sửa phim
        }

        private void btn_FormSuaPhim_ThemPoster_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm poster
        }
    }
}
