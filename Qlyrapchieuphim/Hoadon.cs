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
    public partial class Hoadon : Form
    {
        public Hoadon()
        {
            InitializeComponent();
        }
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        string makh = string.Empty;
        bool used_points = false;
        string masc = string.Empty;
        int food_total;
        int drinks_total;
        int total;
        int discount;
        string billCode = string.Empty;
        public string BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }
        private void LoadBill()
        {
            if (string.IsNullOrEmpty(billCode))
            {
                MessageBox.Show(
                    "NO BILL CODE",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT MASUATCHIEU, SOGHE, MAKHACHHANG, TONGTIENVE, FOODTOTAL, " +
                "DRINKSTOTAL, DISCOUNT FROM  HOADON " +
                "WHERE MAHD = @mahd";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@mahd",SqlDbType.Char).Value = billCode;
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "BILL");
            conn.Close();
            DataTable dt = ds.Tables["BILL"];
            masc = dt.Rows[0]["MASUATCHIEU"].ToString();
            movSeatNum.Text = dt.Rows[0]["SOGHE"].ToString();
            makh = dt.Rows[0]["MAKHACHHANG"].ToString();

            food_total = int.Parse(dt.Rows[0]["FOODTOTAL"].ToString());
            spFood.Text = food_total.ToString() + " VND";
            drinks_total = int.Parse(dt.Rows[0]["DRINKSTOTAL"].ToString());
            spDrinks.Text = drinks_total.ToString() + " VND";

            total = int.Parse(dt.Rows[0]["TONGTIENVE"].ToString());
            tongtien.Text = total.ToString() + " VND";
            sp_total_lbl.Text = (food_total + drinks_total).ToString() + " VND";

            discount = int.Parse(dt.Rows[0]["DISCOUNT"].ToString());
            lblDiscount.Text = discount.ToString() + " VND";

            cantra.Text = (total - discount + food_total + drinks_total).ToString() + " VND";
            LoadMovie();
            LoadCus();
        }
        //public string CusCode
        //{
        //    get { return makh; }
        //    set { makh = value; }
        //}
        public bool UsedPoints
        {
            get { return used_points; }
            set { used_points = value; }
        }
        //public string SlotCode
        //{
        //    get { return masc; }
        //    set { masc = value; }
        //}
        //public int FoodTotal
        //{
        //    get { return food_total; }
        //    set { food_total = value; }
        //}
        //public int DrinksTotal
        //{
        //    get { return drinks_total; }
        //    set { drinks_total = value; }
        //}
        //public int Total
        //{
        //    get { return total; }
        //    set { total = value; }
        //}
        //public int Discount
        //{
        //    get { return discount; }
        //    set { discount = value; }
        //}
        private void LoadMovie()
        {
            if (string.IsNullOrEmpty(masc))
                return;
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "select TENPHIM, THOIGIANBATDAU, NGAYCHIEU  " +
                "from BOPHIM f, SUATCHIEU sc " +
                "WHERE (f.MAPHIM = sc.MAPHIM) AND (sc.MASUATCHIEU = @masc) ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@masc", SqlDbType.Char).Value = masc;
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "BOPHIM");
            conn.Close();
            DataTable dt = ds.Tables["BOPHIM"];
            movName.Text = dt.Rows[0]["TENPHIM"].ToString();
            DateTime date = (DateTime)dt.Rows[0]["NGAYCHIEU"];
            movDate.Text = date.ToString("dd/MM/yyyy");
            TimeSpan time = (TimeSpan)dt.Rows[0]["THOIGIANBATDAU"];
            movTime.Text = new DateTime(time.Ticks + date.Ticks).ToString("HH:mm:ss");
        }
        private void LoadCus()
        {
            if (string.IsNullOrEmpty(makh))
            {
                cusName.Text = "N/A";
                cusPhone.Text = "N/A";
                cusEmail.Text = "N/A";
                cusPoints.Text = "N/A";
                cusDeducted.Text = "N/A";
                return;
            }
                
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT TENKHACHHANG, SODIENTHOAI, EMAIL, DIEMTICHLUY FROM KHACHHANG " +
                "WHERE MAKHACHHANG = @makh";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@makh", SqlDbType.Char).Value = makh;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");
            DataTable dt = ds.Tables["KHACHHANG"];
            if (dt.Rows.Count <=0)
            {
                cusName.Text = "N/A";
                cusPhone.Text = "N/A";
                cusEmail.Text = "N/A";
                cusPoints.Text = "N/A";
                cusDeducted.Text = "N/A";
                return;
            }
            cusName.Text = dt.Rows[0]["TENKHACHHANG"].ToString();
            cusPhone.Text = dt.Rows[0]["SODIENTHOAI"].ToString();
            cusEmail.Text = dt.Rows[0]["EMAIL"].ToString();
            int temp_dtl = (int)dt.Rows[0]["DIEMTICHLUY"];
            cusPoints.Text = dt.Rows[0]["DIEMTICHLUY"].ToString();
            SqlQuery = "UPDATE KHACHHANG SET " +
                    "DIEMTICHLUY = @dtl " +
                    "WHERE MAKHACHHANG = @makh";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@makh", SqlDbType.Char).Value = makh;
            if (UsedPoints)
            {
                temp_dtl = 0;
                cmd.Parameters.Add("@dtl", SqlDbType.Int).Value = temp_dtl;
                cusDeducted.Text = temp_dtl.ToString();
            }
            else
            {
                temp_dtl++;
                cmd.Parameters.Add("@dtl", SqlDbType.Int).Value = temp_dtl;
                cusDeducted.Text = temp_dtl.ToString();
            }
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void Hoadon_Load(object sender, EventArgs e)
        {
            LoadBill();
        }
    }
}
