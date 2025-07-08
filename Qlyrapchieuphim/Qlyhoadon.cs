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

namespace Qlyrapchieuphim
{
    public partial class Qlyhoadon : UserControl
    {
        public Qlyhoadon()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT BookingID, FullName, Phone, CreatedAt " +
                    "FROM Bookings bks JOIN Customers cts ON (bks.CustomerID = cts.CustomerID)";
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
            }
        }

        private void Qlyhoadon_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
