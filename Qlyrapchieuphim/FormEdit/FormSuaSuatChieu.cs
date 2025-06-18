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
    public partial class FormSuaSuatChieu : Form
    {
        public FormSuaSuatChieu()
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

        private void FormSuaSuatChieu_Load(object sender, EventArgs e)
        {
            date_FormSuaSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormSuaSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void date_FormSuaSuatChieu_GioChieu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaSuatChieu_MaSuatChieu.Clear();
            cb_FormSuaSuatChieu_PhongChieu.SelectedIndex = -1;
            cb_FormSuaSuatChieu_TenPhim.SelectedIndex = -1;
            date_FormSuaSuatChieu_NgayChieu.Value = DateTime.Now;
            date_FormSuaSuatChieu_GioChieu.Value = DateTime.Now;
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý sửa suất chiếu vào CSDL
        }
    }
}
