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
using System.Windows.Navigation;

namespace Qlyrapchieuphim
{
    public partial class Hoadon : Form
    {
        public Hoadon()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        int makh = -1;
        bool used_points = false;
        int masc = -1;
        int food_total = 0;
        int drinks_total = 0;
        int total;
        int discount;
        private int loyalty_points_before;
        private int billCode = -1;
        public int BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }
        public int LoyaltyPointsBefore
        {
            get { return loyalty_points_before; }
            set { loyalty_points_before = value; }
        }
        private void LoadBill()
        {
            if (billCode == -1)
            {
                MessageBox.Show(
                    "NO BILL CODE",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            //Main Booking
            string SqlQuery = "SELECT ShowtimeID, CustomerID, TotalPrice, VoucherID FROM  Bookings " +
                "WHERE BookingID = @BookingID";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
            DataSet mainDataSet = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(mainDataSet, "Bookings");
            conn.Close();
            DataTable MainDataTable = mainDataSet.Tables["Bookings"];
            masc = (int)MainDataTable.Rows[0]["ShowtimeID"];
            makh = (int)MainDataTable.Rows[0]["CustomerID"];
            total = Convert.ToInt32((decimal)MainDataTable.Rows[0]["TotalPrice"]);
            tongtien.Text = total.ToString() + " VND";


            //BookingDetails
            SqlQuery = "SELECT Count(bds.SeatID) AS NumberOfSeats, SeatType " +
                "FROM Seats sts JOIN BookingDetails bds ON (sts.SeatID = bds.SeatID) " +
                "WHERE bds.BookingID = @BookingID " +
                "GROUP BY SeatType";
            adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
            DataTable bookingDetails = new DataTable();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(bookingDetails);
            conn.Close();
            foreach (DataRow row in bookingDetails.Rows)
            {
                if (row["SeatType"].ToString() == "Standard")
                    lbl_NormalSeatNum.Text = row["NumberOfSeats"].ToString();
                if (row["SeatType"].ToString() == "VIP")
                    lbl_VIPSeatNum.Text = row["NumberOfSeats"].ToString();
            }


            //BookingProducts
            SqlQuery = "SELECT bprd.ProductID, prd.ProductName, prd.Price, bprd.Quantity, prd.CategoryID " +
                "FROM Products prd JOIN BookingProducts bprd ON (prd.ProductID = bprd.ProductID) " +
                "WHERE BookingID = @BookingID";
            adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
            DataTable bookingProducts = new DataTable();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(bookingProducts);
            conn.Close();
            dataGridView1.DataSource = bookingProducts;
            foreach (DataRow row in bookingProducts.Rows)
            {
                if ((int)row["CategoryID"] == 1) //Đồ ăn
                    food_total += Convert.ToInt32((decimal)row["Price"] * (int)row["Quantity"]);

                if ((int)row["CategoryID"] == 2) //Thức uống
                    drinks_total = Convert.ToInt32((decimal)row["Price"] * (int)row["Quantity"]);
            }
            spFood.Text = food_total.ToString() + " VND";
            spDrinks.Text = drinks_total.ToString() + " VND";
            sp_total_lbl.Text = (food_total + drinks_total).ToString() + " VND";


            int need_to_pay = total + food_total + drinks_total;
            //Hadling Discounts
            float voucherDiscountPercent = getVoucherDiscountPercent((MainDataTable.Rows[0]["VoucherID"] == DBNull.Value) ? -1 : (int)MainDataTable.Rows[0]["VoucherID"]);
            discount = (int)(need_to_pay * voucherDiscountPercent);
            if (UsedPoints)
                discount += loyalty_points_before * 2000;

            lblDiscount.Text = discount.ToString() + " VND";
            need_to_pay -= discount;

            cantra.Text = need_to_pay.ToString() + " VND";
            LoadMovie();
            LoadCus();
        }
        private float getVoucherDiscountPercent(float voucherId)
        {
            float result = 0;
            if (voucherId == -1)
                return result;

            using (SqlCommand cmd = conn.CreateCommand())
            {
                string Sqlquery = "SELECT DiscountPercent FROM Vouchers WHERE VoucherID = @VoucherID";
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = voucherId;
                cmd.CommandText = Sqlquery;
                cmd.CommandType = CommandType.Text;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                result = float.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
            }
            return result;
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
            if (masc == -1)
                return;
            string SqlQuery = "SELECT Title, StartTime " +
                "FROM Movies mv JOIN Showtimes st ON (mv.MovieID = st.MovieID)" +
                "WHERE (st.ShowtimeID = @masc) ";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@masc", SqlDbType.Int).Value = masc;
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Movies");
            conn.Close();
            DataTable dt = ds.Tables["Movies"];
            movName.Text = dt.Rows[0]["Title"].ToString();
            DateTime date = (DateTime)dt.Rows[0]["StartTime"];
            movDate.Text = date.Date.ToString("dd/MM/yyyy");
            TimeSpan time = date.TimeOfDay;
            movTime.Text = new DateTime(time.Ticks + date.Ticks).ToString("HH:mm:ss");
        }
        private void LoadCus()
        {
            if (makh == -1 || makh == 1)
            {
                cusName.Text = "N/A";
                cusPhone.Text = "N/A";
                cusEmail.Text = "N/A";
                cusPoints.Text = "N/A";
                cusDeducted.Text = "N/A";
                return;
            }
            
            string SqlQuery = "SELECT FullName, Phone, Email, LoyaltyPoints " +
                "FROM Customers cs JOIN Users usr ON (usr.UserID = cs.UserID) " +
                "WHERE CustomerID = @CustomerID";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            adapter.SelectCommand.Parameters.Add("@CustomerID", SqlDbType.Int).Value = makh;
            DataSet ds = new DataSet();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            adapter.Fill(ds, "Customers");
            conn.Close();
            DataTable dt = ds.Tables["Customers"];
            if (dt.Rows.Count <= 0)
            {
                cusName.Text = "N/A";
                cusPhone.Text = "N/A";
                cusEmail.Text = "N/A";
                cusPoints.Text = "N/A";
                cusDeducted.Text = "N/A";
                return;
            }
            cusName.Text = dt.Rows[0]["FullName"].ToString();
            cusPhone.Text = dt.Rows[0]["Phone"].ToString();
            cusEmail.Text = dt.Rows[0]["Email"].ToString();
            cusPoints.Text = loyalty_points_before.ToString();
            cusDeducted.Text = dt.Rows[0]["LoyaltyPoints"].ToString();
            
        }
        private void Hoadon_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            LoadBill();
        }
    }
}
