﻿using System;
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
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace Qlyrapchieuphim
{
    public partial class Hoadon : Form
    {
        public Hoadon()
        {
            InitializeComponent();
        }
        public Hoadon(int billCode)
        {
            InitializeComponent();
            this.billCode = billCode;
        }
        private int customerId = -1;
        int masc = -1;
        int food_total = 0;
        int drinks_total = 0;
        int total;
        int discount;
        int student_discount;
        int child_discount;
        private int billCode = -1;
        private int priceAtCheckOut;
        private bool allowExport = true;
        private DataTable MainDataTable;
        private DataTable bookingDetails;
        private DataTable bookingProducts;
        private bool showCurrentPoints = true;
        public int BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }
        public int CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public bool AllowExport
        {
            get { return allowExport; }
            set { allowExport = value; }
        }
        public int PriceAtCheckOut
        {
            get { return priceAtCheckOut; }
            set { priceAtCheckOut = value; }
        }
        public bool ShowCurrentPoints
        {
            get { return showCurrentPoints; }
            set { showCurrentPoints = value; }
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
            string SqlQuery = "SELECT ShowtimeID, CustomerID, TotalPrice, VoucherID, CreatedAt, StudentCount, ChildrenCount, LoyaltyPointsUsed, PriceAtCheckOut FROM  Bookings " +
                "WHERE BookingID = @BookingID";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
                DataSet mainDataSet = new DataSet();
                conn.Open();
                adapter.Fill(mainDataSet, "Bookings");
                conn.Close();
                MainDataTable = mainDataSet.Tables["Bookings"];
            }
            masc = (int)MainDataTable.Rows[0]["ShowtimeID"];
            customerId = (int)MainDataTable.Rows[0]["CustomerID"];
            total = Convert.ToInt32((decimal)MainDataTable.Rows[0]["TotalPrice"]);
            tongtienve.Text = total.ToString() + " VND";
            student_discount = (int)MainDataTable.Rows[0]["StudentCount"] * 15000;
            child_discount = (int)MainDataTable.Rows[0]["ChildrenCount"] * 15000;
            priceAtCheckOut = Convert.ToInt32((decimal)MainDataTable.Rows[0]["PriceAtCheckOut"]);
            customerId = (int)MainDataTable.Rows[0]["CustomerID"];


            //BookingDetails
            SqlQuery = "SELECT Count(bds.SeatID) AS NumberOfSeats, SeatType " +
                "FROM Seats sts JOIN BookingDetails bds ON (sts.SeatID = bds.SeatID) " +
                "WHERE bds.BookingID = @BookingID " +
                "GROUP BY SeatType";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
                bookingDetails = new DataTable();
                conn.Open();
                adapter.Fill(bookingDetails);
                conn.Close();
            }
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
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@BookingID", SqlDbType.Int).Value = billCode;
                bookingProducts = new DataTable();
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
            }
            spFood.Text = food_total.ToString("N0") + " VND";
            spDrinks.Text = drinks_total.ToString("N0") + " VND";
            sp_total_lbl.Text = (food_total + drinks_total).ToString("N0") + " VND";


            int need_to_pay_without_food = total;
            //Hadling Discounts
            float voucherDiscountPercent = getVoucherDiscountPercent((MainDataTable.Rows[0]["VoucherID"] == DBNull.Value) ? -1 : (int)MainDataTable.Rows[0]["VoucherID"]);
            discount = (int)(need_to_pay_without_food * voucherDiscountPercent);
            discount += (int)MainDataTable.Rows[0]["LoyaltyPointsUsed"] * 2000;

            lblDiscount.Text = (discount + student_discount + child_discount).ToString() + " VND";
            int need_to_pay = need_to_pay_without_food + food_total + drinks_total;
            need_to_pay -= (discount + student_discount + child_discount);

            cantra.Text = need_to_pay.ToString() + " VND";
            LoadMovie();
            LoadCus();
        }
        private float getVoucherDiscountPercent(float voucherId)
        {
            float result = 0;
            if (voucherId == -1)
                return result;
            using (SqlConnection conn = Helper.getdbConnection())
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


        private void LoadMovie()
        {
            if (masc == -1)
                return;
            DataTable dt;
            string SqlQuery = "SELECT Title, StartTime, RoomName " +
                "FROM Movies mv JOIN Showtimes st ON (mv.MovieID = st.MovieID) " +
                "JOIN Rooms rms ON (rms.RoomID = st.RoomID)" +
                "WHERE (st.ShowtimeID = @masc) ";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@masc", SqlDbType.Int).Value = masc;
                DataSet ds = new DataSet();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                adapter.Fill(ds, "Movies");
                conn.Close();
                dt = ds.Tables["Movies"];
            }
            movName.Text = dt.Rows[0]["Title"].ToString();
            DateTime date = (DateTime)dt.Rows[0]["StartTime"];
            movDate.Text = date.Date.ToString("dd/MM/yyyy");
            TimeSpan time = date.TimeOfDay.StripSeconds();
            movTime.Text = time.ToString();
            movRoom.Text = dt.Rows[0]["RoomName"].ToString();
        }
        private void LoadCus()
        {
            if (customerId == -1 || customerId == 1)
            {
                cusName.Text = "N/A";
                cusPhone.Text = "N/A";
                cusEmail.Text = "N/A";
                cusPoints.Text = "N/A";
                cusDeducted.Text = "N/A";
                return;
            }
            DataTable dt;
            string SqlQuery = "SELECT FullName, Phone, Email, LoyaltyPoints " +
                "FROM Customers cs JOIN Users usr ON (usr.UserID = cs.UserID) " +
                "WHERE CustomerID = @CustomerID";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerId;
                DataSet ds = new DataSet();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                adapter.Fill(ds, "Customers");
                conn.Close();
                dt = ds.Tables["Customers"];
            }
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
            cusPoints.Text = MainDataTable.Rows[0]["LoyaltyPointsUsed"].ToString();
            cusDeducted.Text = dt.Rows[0]["LoyaltyPoints"].ToString();

        }
        private void Hoadon_Load(object sender, EventArgs e)
        {
            btn_Print_Bill.Enabled = allowExport;
            label31.Visible = showCurrentPoints;
            cusDeducted.Visible = showCurrentPoints;
            LoadBill();
        }
        private DataTable BuildDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(string));

            if (!lbl_NormalSeatNum.Text.IsNullOrEmpty())
            {
                DataRow stdSeats = dt.NewRow();
                stdSeats["ProductName"] = "Ghế thường";
                stdSeats["Price"] = priceAtCheckOut.ToString();
                stdSeats["Quantity"] = lbl_NormalSeatNum.Text;
                stdSeats["TotalPrice"] = (priceAtCheckOut * int.Parse(lbl_NormalSeatNum.Text)).ToString();
                dt.Rows.Add(stdSeats);
            }

            if (!lbl_VIPSeatNum.Text.IsNullOrEmpty())
            {
                DataRow vipSeats = dt.NewRow();
                vipSeats["ProductName"] = "Ghế VIP";
                vipSeats["Price"] = (priceAtCheckOut + 15000).ToString();
                vipSeats["Quantity"] = lbl_VIPSeatNum.Text;
                vipSeats["TotalPrice"] = ((priceAtCheckOut + 15000) * int.Parse(lbl_VIPSeatNum.Text)).ToString();
                dt.Rows.Add(vipSeats);
            }

            foreach (DataRow dr in bookingProducts.Rows)
            {
                DataRow product = dt.NewRow();
                product["ProductName"] = dr["ProductName"].ToString();
                product["Price"] = dr["Price"].ToString();
                product["Quantity"] = dr["Quantity"].ToString();
                product["TotalPrice"] = (Convert.ToDecimal(dr["Price"]) * Convert.ToInt32(dr["Quantity"])).ToString();
                dt.Rows.Add(product);
            }

            return dt;
        }
        private void btn_Print_Bill_Click(object sender, EventArgs e)
        {
            try
            {
                string folder_path = Environment.CurrentDirectory + @"\receipts";
                string receipt_path = folder_path + "\\receipt_" + billCode.ToString() + ".html";

                //Tạo thư mục nếu chưa có
                if (!Directory.Exists(folder_path))
                    Directory.CreateDirectory(folder_path);

                //Tạo file nếu chưa có , xoá và tạo lại nếu đã có
                if (File.Exists(receipt_path))
                    File.Delete(receipt_path);
                else
                    File.Create(receipt_path).Dispose();
                ReceiptTemplate receipt = new ReceiptTemplate();

                receipt.BillCode = billCode;
                receipt.CreatedAt = (DateTime)MainDataTable.Rows[0]["CreatedAt"];
                receipt.BillData = BuildDataTable();
                receipt.TotalDiscount = discount;
                receipt.TotalTickets = total;
                receipt.TotalProducts = food_total + drinks_total;
                receipt.PriceAtCheckout = priceAtCheckOut;
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    string SqlQuery = "SELECT mv.Title, StartTime " +
                    "FROM Showtimes sht JOIN Movies mv ON (sht.MovieID = mv.MovieID) " +
                    "WHERE (ShowtimeID = @masc)";
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
                        cmd.Parameters.Add("@masc", SqlDbType.Int).Value = masc;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                receipt.Title = reader.GetString(0);
                                receipt.StartTime = reader.GetDateTime(1);
                            }
                        }
                    }
                }
                receipt.StudentDiscount = student_discount;
                receipt.ChildrenDiscount = child_discount;


                string receipt_content = receipt.TransformText();
                File.WriteAllText(receipt_path, receipt_content);

                System.Diagnostics.Process.Start(receipt_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi trong quá trình xuất hoá đơn \n Details: " + ex.Message,
                    "Lỗi mở file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public int GetTienCanTra()
        {
            int need_to_pay_without_food = total;
            int totalFoodAndDrink = food_total + drinks_total;
            int totalDiscount = discount + student_discount + child_discount;

            int need_to_pay = need_to_pay_without_food + totalFoodAndDrink - totalDiscount;

            return need_to_pay;
        }

    }
}
