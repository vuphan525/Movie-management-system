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
    public partial class FormSuaVoucher : Form
    {
        public FormSuaVoucher()
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

        private void FormSuaVoucher_Load(object sender, EventArgs e)
        {
            date_FormSuaVoucher_NgayHetHan.Format = DateTimePickerFormat.Custom;
            date_FormSuaVoucher_NgayHetHan.CustomFormat = "dd/MM/yyyy";
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
            lbl_FormSuaVoucher_MaPhatHanh.Clear();
            lbl_FormSuaVoucher_DiscountAmount.Clear();
            lbl_FormSuaVoucher_DiscountPercent.Clear();
            date_FormSuaVoucher_NgayHetHan.Value = DateTime.Now;
            lbl_FormSuaVoucher_SoLuong.Clear();
            lbl_FormSuaVoucher_HoaDonToiThieu.Clear();
            cb_FormSuaVoucher_TrangThai.SelectedIndex = -1;
            lbl_FormSuaVoucher_MoTa.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_FormSuaVoucher_DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbl_FormSuaVoucher_DiscountAmount.Text))
            {
                lbl_FormSuaVoucher_DiscountPercent.ReadOnly = true;
                lbl_FormSuaVoucher_DiscountPercent.Enabled = false;
            }
            else
            {
                lbl_FormSuaVoucher_DiscountPercent.ReadOnly = false;
                lbl_FormSuaVoucher_DiscountPercent.Enabled = true;
            }
        }

        private void lbl_FormSuaVoucher_DiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbl_FormSuaVoucher_DiscountPercent.Text))
            {
                lbl_FormSuaVoucher_DiscountAmount.ReadOnly = true;
                lbl_FormSuaVoucher_DiscountAmount.Enabled = false;
            }
            else
            {
                lbl_FormSuaVoucher_DiscountAmount.ReadOnly = false;
                lbl_FormSuaVoucher_DiscountAmount.Enabled = true;
            }
        }
    }
}
