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
        SqlConnection conn = null;
        bool cus_exists = false;
        int customer_code = -1;
        public int cus_code
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
            string SqlQuery = "SELECT COUNT(*) FROM Customers WHERE Phone = @sdt";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtCustomerID.Text;
            if (conn.State != ConnectionState.Open)
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
            SqlQuery = "SELECT CustomerID, FullName FROM Customers WHERE Phone = @sdt";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@sdt", SqlDbType.VarChar).Value = txtCustomerID.Text;
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Customers");
            conn.Close();
            DataTable dt = ds.Tables["Customers"];
            textBox1.Text = dt.Rows[0]["FullName"].ToString();
            cus_code = (int)dt.Rows[0]["CustomerID"];
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
            customer_code = -1;
            cus_exists = false;
        }

        private void khachhang_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
        }
    }
}
