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
    public partial class FormThemSuatChieu : Form
    {
        public FormThemSuatChieu()
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

        private void FormThemSuatChieu_Load(object sender, EventArgs e)
        {
            date_FormThemSuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";
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
            lbl_FormThemSuatChieu_MaSuatChieu.Clear();
            cb_FormThemSuatChieu_PhongChieu.SelectedIndex = -1;
            cb_FormThemSuatChieu_TenPhim.SelectedIndex = -1;
            date_FormThemSuatChieu_NgayChieu.Value = DateTime.Now;
            date_FormThemSuatChieu_GioChieu.Value = DateTime.Now;
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm suất chiếu vào CSDL
        }
    }
}
