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
    public partial class formbanve : Form
    {
        List<Button> sold = new List<Button>();
        List<Button> selected = new List<Button>();
        public formbanve()
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

        private void formbanve_Load(object sender, EventArgs e)
        {

        }
    }
}
