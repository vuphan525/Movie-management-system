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
    public partial class FormSuaNhanVien : Form
    {
        public FormSuaNhanVien()
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

        private void FormSuaNhanVien_Load(object sender, EventArgs e)
        {
            date_FormSuaNV_NgaySinh.Format = DateTimePickerFormat.Custom;
            date_FormSuaNV_NgaySinh.CustomFormat = "dd/MM/yyyy";
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
            lbl_FormSuaNV_Email.Clear();
            lbl_FormSuaNV_HoTen.Clear();
            lbl_FormSuaNV_SDT.Clear();
            date_FormSuaNV_NgaySinh.Value = DateTime.Now;
            lbl_FormSuaNV_MaNV.Clear();
            cb_FormSuaNV_ChucVu.SelectedIndex = -1;
            lbl_FormSuaNV_Username.Clear();
            lbl_FormSuaNV_Password.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý sửa nhân viên trong database
        }
    }
}
