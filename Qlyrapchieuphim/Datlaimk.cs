using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Qlyrapchieuphim
{
    public partial class Datlaimk : Form
    {
        string manv;
        public Datlaimk()
        {
            InitializeComponent();
        }
        public Datlaimk(string mnv)
        {
            InitializeComponent();
            manv = mnv;
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (passBox.Text != pass_repeatBox.Text)
            {
                MessageBox.Show(
                    "Mật khẩu và xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "UPDATE NHANVIEN SET " +
                "PASS = @pass " +
                "WHERE ()";
        }
    }
}
