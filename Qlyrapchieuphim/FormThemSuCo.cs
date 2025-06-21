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
    public partial class FormThemSuCo : Form
    {
        public FormThemSuCo()
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

        private void FormThemSuCo_Load(object sender, EventArgs e)
        {
            date_FormThemSuCo_NgayTiepNhan.Format = DateTimePickerFormat.Custom;
            date_FormThemSuCo_NgayTiepNhan.CustomFormat = "dd/MM/yyyy";
            //ToDo: Load id của nhân viên đang đăng nhập vào hệ thống để cho vào lbl_FormThemSuCo_MaNhanVien
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
            lbl_FormThemSuCo_MaSuCo.Clear();
            lbl_FormThemSuCo_TenSuCo.Clear();
            cb_FormThemSuCo_TinhTrang.SelectedIndex = -1;
            lbl_FormThemSuCo_HuongGiaiQuyet.Clear();
            date_FormThemSuCo_NgayTiepNhan.Value = DateTime.Now;
            lbl_FormThemSuCo_MoTa.Clear();
        }

        private void bcButton_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý thêm sự cố
        }
    }
}
