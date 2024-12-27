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
    public partial class Sanpham : UserControl
    {
        public Label Ten { get { return name; } }
        public Label Gia { get { return price; } }
        public Guna2PictureBox img { get { return image; } }
        public Sanpham()
        {
            InitializeComponent();
            img.SizeMode= PictureBoxSizeMode.Zoom;
        }
    }
}
