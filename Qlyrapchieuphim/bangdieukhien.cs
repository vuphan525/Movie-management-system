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
using Microsoft.IdentityModel.Tokens;

namespace Qlyrapchieuphim
{
    public partial class bangdieukhien : UserControl
    {
        public bangdieukhien()
        {
            InitializeComponent();
            if (Helper.IsInWinFormsDesignMode())
            {
                Helper.CopyDatabaseForDesign();
            }
        }
        private SqlConnection conn;
        
        private void LoadMOV()
        {
            string SqlQuery = "select Title, Genre, Duration from Movies " +
                "WHERE Status = @state";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@state", SqlDbType.NVarChar).Value = "Đang chiếu";
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Movies");
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            DataTable dt = ds.Tables["Movies"];
            dataGridView1.DataSource = dt;
        }
        private void LoadNV()
        {
            string SqlQuery = "SELECT COUNT(*) FROM Staffs ";
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            int sonv = (int)cmd.ExecuteScalar();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            label3.Text= sonv.ToString();
            
        }
        private void LoadMovCount()
        {
            string SqlQuery = "SELECT COUNT(*) FROM Movies ";
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            int sophim = (int)cmd.ExecuteScalar();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            label2.Text = sophim.ToString();
           
        }

        private void bangdieukhien_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
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
