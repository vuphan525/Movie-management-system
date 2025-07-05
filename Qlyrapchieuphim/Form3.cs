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
    public partial class form_ThemGioChieu : Form
    {
        public form_ThemGioChieu()
        {
            InitializeComponent();
        }

        private void sua_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_ThemGioChieu_Load(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            form_ThemGioChieu_Load(sender, e);
        }
    }
}
