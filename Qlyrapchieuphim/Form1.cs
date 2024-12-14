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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2TextBox1.UseSystemPasswordChar = true;
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox1.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))

            {
                Application.Exit();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Adform aForm = new Adform();
            aForm.Show();

=======
            if (guna2TextBox4.Text == string.Empty) 
            {
                staffForm aForm = new staffForm();
                aForm.Show();
            }
            else
            {
                Adform adform = new Adform();
                adform.Show();
            }
>>>>>>> test_database
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
