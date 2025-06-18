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
    public partial class FormThemSanPham : Form
    {
        public FormThemSanPham()
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

        private void FormThemSanPham_Load(object sender, EventArgs e)
        {
            date_ThemSanPham_NgayNhap.Format = DateTimePickerFormat.Custom;
            date_ThemSanPham_NgayNhap.CustomFormat = "dd/MM/yyyy";
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
            lbl_ThemSanPham_MaSP.Clear();
            lbl_ThemSanPham_TenSP.Clear();
            cb_ThemSanPham_LoaiSP.SelectedIndex = -1;
            lbl_ThemSanPham_GiaTien.Clear();
            lbl_ThemSanPham_SoLuong.Clear();
            lbl_ThemSanPham_NhaCungCap.Clear();
            date_ThemSanPham_NgayNhap.Value = DateTime.Now;
            lbl_ThemSanPham_MoTa.Clear();
            pictureBox_ThemSanPham_Poster.Image = null;
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm sản phẩm
        }

        private void btn_ThemSanPham_Poster_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý chọn hình ảnh cho sản phẩm
        }
    }
}
