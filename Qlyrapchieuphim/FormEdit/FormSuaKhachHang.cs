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
    public partial class FormSuaKhachHang : Form
    {
        public FormSuaKhachHang()
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

        private void FormSuaKhachHang_Load(object sender, EventArgs e)
        {

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
            lbl_FormSuaKH_DiemTichLuy.Clear();
            lbl_FormSuaKH_Email.Clear();
            lbl_FormSuaKH_HoTen.Clear();
            lbl_FormSuaKH_SDT.Clear();
            lbl_FormSuaKH_MaKH.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            //ToDo: Xử lý cập nhật thông tin khách hàng
        }
    }
}
