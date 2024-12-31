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
        TextBox idBox = new TextBox();
        
        public Sanpham()
        {
            InitializeComponent();
            this.BackColor = SystemColors.ControlLight;
            img.SizeMode= PictureBoxSizeMode.Zoom;
            idBox.Visible = false;
            this.Controls.Add(idBox);
            foreach (Control c in this.Controls)
            {
                c.Click += Sanpham_Click;
                c.MouseMove += Sanpham_MouseMove;
            }
        }
        int storage = 0;
        string type = string.Empty;
        public string Type 
        {
            get { return type; } 
            set { type = value; }
        }
        public int Count 
        { 
            get { return storage; } 
            set {  storage = value; }
        }
        public Label Ten { get { return name; } }
        public Label Gia { get { return price; } }
        public Guna2PictureBox img { get { return image; } }
        public Guna2ShadowPanel panel { get { return guna2ShadowPanel1; } }
        public TextBox ID { get { return idBox; } }
        public void Sanpham_Click(object sender, EventArgs e)
        {
            
        }

        private void Sanpham_MouseLeave(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Sanpham_MouseMove(object sender, MouseEventArgs e) // code for hover border (scrapped)
        {
            //int thickness = 4;
            //Rectangle rec = this.Bounds;
            //rec.X -= 4;
            //rec.Y -= 4;
            //rec.Inflate(1, 1);
            //Graphics g = CreateGraphics();
            ////using (Pen p = new Pen(Color.Purple, thickness))
            ////{
            ////    ControlPaint.DrawBorder(g, rec, p, );
            ////}
            //ControlPaint.DrawBorder(g, rec, Color.Purple, thickness, ButtonBorderStyle.Solid
            //                              , Color.Purple, thickness, ButtonBorderStyle.Solid
            //                              , Color.Purple, thickness, ButtonBorderStyle.Solid
            //                              , Color.Purple, thickness, ButtonBorderStyle.Solid);
        }
    }
}
