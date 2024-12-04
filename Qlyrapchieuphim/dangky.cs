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
    public partial class dangky : Form
    {
        public dangky()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Application.Exit();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();
        }
    }
}
