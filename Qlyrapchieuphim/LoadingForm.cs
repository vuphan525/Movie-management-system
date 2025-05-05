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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Shown += LoadingForm_Shown;
        }

        private void timerLoadingForm_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value == 100)
            {
                timerLoadingForm.Stop();
                this.DialogResult = DialogResult.OK; // sẽ tự đóng ShowDialog()
                this.Close();
            } else
            {
                guna2CircleProgressBar1.Value += 1;
                label1.Text = "Loading... " + guna2CircleProgressBar1.Value.ToString() + "%";
            }
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            //timerLoadingForm.Start();
        }

        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            this.Opacity = 1;
            timerLoadingForm.Start();
        }
    }
}
