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
    public partial class FormThemVoucher : Form
    {
        public FormThemVoucher()
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

        private void FormThemVoucher_Load(object sender, EventArgs e)
        {
            date_FormThemVoucher_NgayHetHan.Format = DateTimePickerFormat.Custom;
            date_FormThemVoucher_NgayHetHan.CustomFormat = "dd/MM/yyyy";
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemVoucher_MaPhatHanh.Clear();
            lbl_FormThemVoucher_DiscountAmount.Clear();
            lbl_FormThemVoucher_DiscountPercent.Clear();
            date_FormThemVoucher_NgayHetHan.Value = DateTime.Now;
            lbl_FormThemVoucher_SoLuong.Clear();
            lbl_FormThemVoucher_HoaDonToiThieu.Clear();
            cb_FormThemVoucher_TrangThai.SelectedIndex = -1;
            lbl_FormThemVoucher_MoTa.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm voucher
        }

        private void lbl_FormThemVoucher_DiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbl_FormThemVoucher_DiscountPercent.Text))
            {
                lbl_FormThemVoucher_DiscountAmount.ReadOnly = true;
                lbl_FormThemVoucher_DiscountAmount.Enabled = false;
            }
            else
            {
                lbl_FormThemVoucher_DiscountAmount.ReadOnly = false;
                lbl_FormThemVoucher_DiscountAmount.Enabled = true;
            }
        }

        private void lbl_FormThemVoucher_DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbl_FormThemVoucher_DiscountAmount.Text))
            {
                lbl_FormThemVoucher_DiscountPercent.ReadOnly = true;
                lbl_FormThemVoucher_DiscountPercent.Enabled = false;
            }
            else
            {
                lbl_FormThemVoucher_DiscountPercent.ReadOnly = false;
                lbl_FormThemVoucher_DiscountPercent.Enabled = true;
            }
        }
    }
}
