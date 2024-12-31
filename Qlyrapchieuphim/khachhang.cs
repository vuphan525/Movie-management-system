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
    public partial class khachhang : Form
    {

        public khachhang()
        {
            InitializeComponent();
            btnCofirm.Enabled = false;
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        bool cus_exists = false;
        string customer_code = string.Empty;
        public string cus_code
        {
            get { return customer_code; }
            set { customer_code = value; }
        }
        private void btnCofirm_Click(object sender, EventArgs e)
        {
            if (cus_exists)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void khachhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void khachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text.Replace(" ", "");
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE SODIENTHOAI = @sdt";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = txtCustomerID.Text;
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            if (count <= 0)
            {
                MessageBox.Show(
                    "Số điện thoại không gắn với tài khoản khách hàng nào.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            cus_exists = true;
            SqlQuery = "SELECT MAKHACHHANG, TENKHACHHANG FROM KHACHHANG WHERE SODIENTHOAI = @sdt";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@sdt", SqlDbType.VarChar).Value = txtCustomerID.Text;
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "KHACHHANG");
            conn.Close();
            DataTable dt = ds.Tables["KHACHHANG"];
            textBox1.Text = dt.Rows[0]["TENKHACHHANG"].ToString();
            cus_code = dt.Rows[0]["MAKHACHHANG"].ToString();
            btnCofirm.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            btnCofirm.Enabled = false;
            textBox1.Clear();
            customer_code = string.Empty;
            cus_exists = false;
        }
    }
}
