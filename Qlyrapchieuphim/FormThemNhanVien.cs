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
    public partial class FormThemNhanVien : Form
    {
        public FormThemNhanVien()
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

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            date_FormThemNV_NgaySinh.Format = DateTimePickerFormat.Custom;
            date_FormThemNV_NgaySinh.CustomFormat = "dd/MM/yyyy";
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
            lbl_FormThemNV_Email.Clear();
            lbl_FormThemNV_HoTen.Clear();
            lbl_FormThemNV_SDT.Clear();
            date_FormThemNV_NgaySinh.Value = DateTime.Now;
            lbl_FormThemNV_MaNV.Clear();
            cb_FormThemNV_ChucVu.SelectedIndex = -1;
            lbl_FormThemNV_Username.Clear();
            lbl_FormThemNV_Password.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            //Todo: Xử lý thêm nhân viên vào database
        }
    }
}
