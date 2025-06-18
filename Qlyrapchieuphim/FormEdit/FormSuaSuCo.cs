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
    public partial class FormSuaSuCo : Form
    {
        public FormSuaSuCo()
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

        private void FormSuaSuCo_Load(object sender, EventArgs e)
        {
            date_FormSuaSuCo_NgayTiepNhan.Format = DateTimePickerFormat.Custom;
            date_FormSuaSuCo_NgayTiepNhan.CustomFormat = "dd/MM/yyyy";
            //ToDo: Load id của nhân viên đang đăng nhập vào hệ thống để cho vào lbl_FormSuaSuCo_MaNhanVien
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
            lbl_FormSuaSuCo_MaSuCo.Clear();
            lbl_FormSuaSuCo_TenSuCo.Clear();
            cb_FormSuaSuCo_TinhTrang.SelectedIndex = -1;
            lbl_FormSuaSuCo_HuongGiaiQuyet.Clear();
            date_FormSuaSuCo_NgayTiepNhan.Value = DateTime.Now;
            lbl_FormSuaSuCo_MoTa.Clear();
        }

        private void bcButton_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý sửa sự cố
        }
    }
}
