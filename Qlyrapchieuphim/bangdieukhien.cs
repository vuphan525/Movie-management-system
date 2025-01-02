using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Qlyrapchieuphim
{
    public partial class bangdieukhien : UserControl
    {
        public bangdieukhien()
        {
            InitializeComponent();
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void LoadMOV()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "select TENPHIM, THELOAI, THOILUONG from BOPHIM " +
                "WHERE DANGCHIEU = @state";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@state", SqlDbType.NVarChar).Value = "Đang chiếu";
            DataSet ds = new DataSet();
            adapter.Fill(ds, "BOPHIM");
            DataTable dt = ds.Tables["BOPHIM"];
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void LoadNV()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT COUNT(*) FROM NHANVIEN ";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            conn.Open();
            int sonv = (int)cmd.ExecuteScalar();
            conn.Close();
            label3.Text= sonv.ToString();
            
        }
        private void LoadMovCount()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT COUNT(*) FROM BOPHIM ";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            conn.Open();
            int sophim = (int)cmd.ExecuteScalar();
            conn.Close();
            label2.Text = sophim.ToString();
           
        }

        private void bangdieukhien_Load(object sender, EventArgs e)
        {
            LoadMOV();
            LoadNV();
            LoadMovCount();
        }

        private void bangdieukhien_Paint(object sender, PaintEventArgs e)
        {
            LoadMOV();
            LoadNV();
            LoadMovCount();
        }
    }
}
