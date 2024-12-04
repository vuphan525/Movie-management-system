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
    public partial class Frombanve : Form
    {
        List<Button> sold = new List<Button>();
        List<Button> selected = new List<Button>();
        public Frombanve()
        {
            InitializeComponent();
            InitializeSeats();
        }
        private void InitializeSeats()
        {
            foreach (var control in this.Controls)
            {
                if (control is Button seatButton && seatButton.Name.StartsWith("button"))
                {
                    seatButton.BackColor = Color.White;
                    seatButton.Click += SeatClick;
                }
            }
        }
        private void SeatClick(object sender, EventArgs e)
        {
            Button a = (Button)sender;
            if (selected.Contains(a))
            {
                a.BackColor = Color.White;
                selected.Remove(a);
            }
            else
            {
                a.BackColor = Color.Yellow;
                selected.Add(a);
            }
        }

        private void Frombanve_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void seat1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
