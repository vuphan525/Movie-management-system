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
    public partial class FormSuaSanPham : Form
    {
        public FormSuaSanPham()
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

        private void FormSuaSanPham_Load(object sender, EventArgs e)
        {
            date_FormSuaSanPham_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_FormSuaSanPham_NgayNhap.CustomFormat = "dd/MM/yyyy";
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

        private void btn_FormSuaSanPham_CapNhat_Click(object sender, EventArgs e)
        {
            lbl_FormSuaSanPham_MaSP.Clear();
            lbl_FormSuaSanPham_TenSP.Clear();
            cb_FormSuaSanPham_LoaiSP.SelectedIndex = -1;
            lbl_FormSuaSanPham_GiaTien.Clear();
            lbl_FormSuaSanPham_SoLuong.Clear();
            lbl_FormSuaSanPham_NhaCungCap.Clear();
            date_FormSuaSanPham_NgayNhap.Value = DateTime.Now;
            lbl_FormSuaSanPham_MoTa.Clear();
            pictureBox_FormSuaSanPham_Poster.Image = null;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý cập nhật sản phẩm
        }

        private void btn_FormSuaSanPham_ThemPoster_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm poster cho sản phẩm
        }
    }
}
