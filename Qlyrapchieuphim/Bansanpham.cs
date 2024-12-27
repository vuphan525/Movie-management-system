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
    public partial class Bansanpham : Form
    {
        public Bansanpham()
        {
            InitializeComponent();
        }

        private void thanhtoan_Click(object sender, EventArgs e)
        {
            Hoadon hd = new Hoadon();   
            hd.Show();
            this.Hide();
        }
    }
}
