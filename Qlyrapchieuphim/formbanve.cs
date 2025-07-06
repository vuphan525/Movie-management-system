using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
namespace Qlyrapchieuphim
{
    public partial class formbanve : Form
    {
        public List<Guna2Button> sold = new List<Guna2Button>();
        public List<Guna2Button> selected = new List<Guna2Button>();
        public List<Guna2Button> vip = new List<Guna2Button>();
        public List<Guna2Button> vipcount = new List<Guna2Button>();
        public List<Guna2Button> soldThisSession = new List<Guna2Button>();
        public int ShowtimeID;
        SqlConnection conn = null;
        string picture_url = string.Empty;
        public int total = 0;
        public int need_to_pay_no_discount = 0;
        public int need_to_pay = 0;
        public float discountPercent = 0;
        private int CustomerID = 1;
        private int UserID = -1;
        private int BookingID = -1;
        int cus_point = 0;
        int food_total = 0;
        int drinks_total = 0;
        int cus_discount = 0;
        int student_count = 0;
        int children_count = 0;
        DataTable sp_list = new DataTable();
        Bansanpham spForm = new Bansanpham();
        readonly string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        //public formbanve()
        //{
        //    InitializeComponent();
        //    sinhvien.Text = "0";
        //    treem.Text = "0";
        //    tongtien.Text = "0 VND";
        //    cantra.Text = "0 VND";
        //    ToggleCusPointButton(false);
        //}
        public formbanve(int showtimeID)
        {
            InitializeComponent();
            ShowtimeID = showtimeID;
            sinhvien.Text = "0";
            treem.Text = "0";
            tongtien.Text = "0 VND";
            cantra.Text = "0 VND";
            ToggleCusPointButton(false);
        }
        public int BookingId
        {
            get { return BookingID; }
        }
        public int CustomerId
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }
        public int UserId
        {
            get { return UserID; }
            set { UserID = value; }
        }
        private bool isStaff()
        {
            string role = getUserRole();
            if (role == "customer" || role.IsNullOrEmpty())
                return false;
            else
                return true;
        }
        private List<int> getSoldSeatsThisSession()
        {
            string SqlQuery = "SELECT DISTINCT SeatID FROM Seats WHERE ";
            int count = 0;
            SqlCommand cmd = conn.CreateCommand();
            foreach (Guna2Button button in soldThisSession)
            {
                if (count != 0)
                    SqlQuery += " OR ";
                SqlQuery += " (SeatNumber = @SeatNumber" + count.ToString() + ") ";
                cmd.Parameters.Add("@SeatNumber" + count.ToString(), SqlDbType.NVarChar).Value = button.Text;
                count++;
            }
            List<int> SeatIds = new List<int>();
            if (sold.Count == 0)
                return SeatIds;
            cmd.CommandText = SqlQuery;
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SeatIds.Add(reader.GetInt32(0));
                }
            }
            conn.Close();
            return SeatIds;
        }
        private int getVoucherId()
        {
            int voucherId = -1;
            if (voucher.SelectedItem.ToString() != "NONE")
            {
                voucherId = int.Parse(Helper.SubStringBetween(voucher.SelectedItem.ToString(), " (ID: ", ") (Tối thiểu"));
            }
            return voucherId;
        }

        private string getUserRole()
        {
            string role = null;
            if (UserID != -1)
            {
                string SqlQuery = "SELECT Role FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    role = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
                return role;
            }
            return null;
        }
        private Nullable<int> getStaffID()
        {
            Nullable<int> val = null;
            if (!isStaff())
                return val;
            return UserID;
        }
        private void checkDate() //Kiểm tra hạn dùng của các voucher
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string SqlQuery = "SELECT VoucherId, ExpiryDate FROM Vouchers";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vouchers");
            DataTable dt = ds.Tables["Vouchers"];
            foreach (DataRow dr in dt.Rows)
            {
                bool isActive;
                DateTime denngay = (DateTime)dr["ExpiryDate"];
                denngay = denngay.Date;
                if (denngay.Date < DateTime.Today)
                    isActive = false; //hết hiệu lực
                else
                    isActive = true; //đang áp dụng
                SqlQuery = "UPDATE Vouchers SET IsActive = @state WHERE VoucherID = @maph";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@state", SqlDbType.Bit).Value = isActive;
                cmd.Parameters.Add("@maph", SqlDbType.Int).Value = dr["VoucherID"];
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        private bool CheckVoucher()
        {
            checkDate();
            int count;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM Vouchers WHERE (IsActive = 1) AND (Quantity > 0)";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar() + 1;


            SqlQuery = "SELECT VoucherID, Code, MinOrderValue FROM Vouchers";
            string[] vouchers = new string[count];
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            vouchers[0] = "NONE";
            int i = 1;
            while (reader.Read())
            {
                string code = reader.GetString(1);
                string id = reader.GetInt32(0).ToString();
                string minOrder = reader.GetDecimal(2).ToString("N2");
                vouchers[i] = $"{code} (ID: {id}) (Tối thiểu {minOrder})";
                i++;
            }
            reader.Close();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            voucher.DataSource = vouchers;
            voucher.SelectedIndex = 0;
            return count > 0;
        }
        private void InitializeSeats()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button seatButton)
                {
                    if (seatButton.Name.StartsWith("guna"))
                    {
                        seatButton.FillColor = Color.FromArgb(115, 46, 213); // Màu ghế thường
                    }
                    else if (seatButton.Name.StartsWith("vip"))
                    {
                        seatButton.FillColor = Color.FromArgb(238, 38, 40); // Màu ghế VIP
                        vip.Add(seatButton);
                    }
                    if (sold.Contains(seatButton))
                        seatButton.FillColor = Color.DimGray; //Màu ghế đã bán
                    seatButton.Click += SeatClick;
                    seatButton.ShadowDecoration.Enabled = true;
                    seatButton.ShadowDecoration.Depth = 10; // Độ sâu bóng
                    seatButton.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0);
                }
            }
        }

        private void LoadData()
        {
            string SqlQuery;
            SqlCommand cmd;
            //Lấy dữ liệu xem các ghế nào đã được book
            SqlQuery = "SELECT DISTINCT st.SeatNumber " +
                "FROM BookingDetails bdt JOIN Bookings bk ON (bdt.BookingID = bk.BookingID) " +
                "JOIN Seats st ON (bdt.SeatID = st.SeatID) " +
                "WHERE ShowtimeID = @ShowtimeID ";
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                adapter.SelectCommand.Parameters.Add("@ShowtimeID", SqlDbType.Int).Value = ShowtimeID;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                adapter.Fill(dt);
                conn.Close();
            }
            foreach (Guna2Button button in flowLayoutPanel1.Controls)
            {
                bool isBought = dt.AsEnumerable().Any(row => button.Text == row.Field<String>("SeatNumber"));
                if (isBought)
                    sold.Add(button);
            }


            SqlQuery = "SELECT RoomName " +
                "FROM Showtimes sht JOIN Rooms rms ON (rms.RoomID = sht.RoomID) " +
                "WHERE ShowtimeID = @masc";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.Int).Value = ShowtimeID;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            lblRoom.Text = "Phòng chiếu: " + cmd.ExecuteScalar().ToString();
            conn.Close();


            SqlQuery = "SELECT mv.PosterURL " +
                "FROM Showtimes sht JOIN Movies mv ON (sht.MovieID = mv.MovieID) " +
                "WHERE (ShowtimeID = @masc)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.Int).Value = ShowtimeID;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string relative_picture_path = cmd.ExecuteScalar().ToString();
            conn.Close();
            picture_url = Path.Combine(projectFolder, relative_picture_path);
            try
            {
                using (FileStream stream = new FileStream(picture_url, FileMode.Open))
                {
                    picFilm.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(relative_picture_path))
                {
                    if (ex is FileNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy file ảnh cho phim",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    if (ex is DirectoryNotFoundException)
                    {
                        MessageBox.Show(
                        "Không tìm thấy folder ảnh cho phim",
                        "Lỗi dữ liệu!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    picFilm.Image = null;
                }
            }
            CheckVoucher();
        }
        public void SeatClick(object sender, EventArgs e)
        {
            Guna2Button a = (Guna2Button)sender;
            if (sold.Contains(a))
            {
                MessageBox.Show(
                    "Ghế đã có người mua!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (selected.Contains(a))
            {
                if (a.Name.StartsWith("guna"))
                {
                    a.FillColor = Color.FromArgb(115, 46, 213); // Màu ghế thường
                    selected.Remove(a);
                }
                else if (a.Name.StartsWith("vip"))
                {
                    a.FillColor = Color.FromArgb(238, 38, 40); // Màu ghế VIP
                    selected.Remove(a);
                    vipcount.Remove(a);
                }
                update();
            }
            else
            {
                if (a.Name.StartsWith("vip"))
                {
                    vipcount.Add(a);
                }
                a.FillColor = Color.FromArgb(201, 54, 136); // Màu ghế được chọn
                selected.Add(a);
                update();
            }
        }

        private void update()
        {
            if (selected.Count > 0)
            {
                try
                {
                    student_count = string.IsNullOrWhiteSpace(sinhvien.Text) ? 0 : int.Parse(sinhvien.Text);
                    children_count = string.IsNullOrWhiteSpace(treem.Text) ? 0 : int.Parse(treem.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int normalCount = selected.Count - vipcount.Count;

                // 1. Tổng tiền vé gốc (chưa giảm)
                total = normalCount * 55000 + vipcount.Count * 70000;
            }
            else
            {
                total = 0;
            }

            // 2. ÁP DỤNG VOUCHER & TÍCH ĐIỂM (CHỈ TRÊN TIỀN VÉ)
            int voucherDiscount = (int)(total * discountPercent);
            int pointDiscount = chkAccumulate.Checked ? 0 : cus_point * 2000;
            int afterVoucher = total - voucherDiscount - pointDiscount;

            // 3. GIẢM GIÁ CHO HSSV & TRẺ EM
            int hssvDiscount = 0;
            int studentLeft = student_count;
            int childrenLeft = children_count;

            for (int i = 0; i < selected.Count - vipcount.Count; i++)
            {
                if (studentLeft > 0) { hssvDiscount += 15000; studentLeft--; }
                else if (childrenLeft > 0) { hssvDiscount += 15000; childrenLeft--; }
                else break;
            }

            for (int i = 0; i < vipcount.Count; i++)
            {
                if (studentLeft > 0) { hssvDiscount += 15000; studentLeft--; }
                else if (childrenLeft > 0) { hssvDiscount += 15000; childrenLeft--; }
                else break;
            }

            // 4. TỔNG SỐ TIỀN PHẢI TRẢ = sau khi giảm vé + tiền sản phẩm
            need_to_pay_no_discount = total + food_total + drinks_total;
            int totalDiscount = voucherDiscount + pointDiscount + hssvDiscount;
            need_to_pay = afterVoucher - hssvDiscount + food_total + drinks_total;

            if (need_to_pay < 0) need_to_pay = 0;

            // 5. CẬP NHẬT GIAO DIỆN
            tongtien.Text = need_to_pay_no_discount.ToString("N0") + " VND";
            lblDiscount.Text = totalDiscount.ToString("N0") + " VND";
            cantra.Text = need_to_pay.ToString("N0") + " VND";
            thanhtoan.Enabled = need_to_pay > 0;
        }




        private void formbanve_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            LoadData();
            InitializeSeats();
            update();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button68_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e) //thanh toan
        {
            if (selected.Count == 0)
            {
                MessageBox.Show(
                    "Vẫn chưa chọn ghế",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            string SqlQuery;
            SqlCommand cmd;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button seatButton)
                {
                    if (selected.Contains(seatButton))
                    {
                        sold.Add(seatButton);
                        soldThisSession.Add(seatButton);
                        seatButton.FillColor = Color.DimGray;
                        seatButton.Enabled = false;
                        selected.Remove(seatButton);
                        vipcount.Remove(seatButton);
                        //SqlQuery = "UPDATE S_" + ShowtimeID + " SET CellValue = @bought  WHERE SeatName = @seatname";
                        //cmd = new SqlCommand(SqlQuery, conn);
                        //cmd.Parameters.Add("@seatname", SqlDbType.VarChar).Value = seatButton.Text;
                        //cmd.Parameters.Add("@bought", SqlDbType.Bit).Value = true;
                        //if (conn.State == ConnectionState.Closed)
                        //    conn.Open();
                        //cmd.ExecuteNonQuery();
                        //conn.Close();
                    }
                }
            }

            //tongtien.Text = "0 VND";
            //cantra.Text = "0 VND";

            //total = 0;
            //discountPercent  = 0;
            //need_to_pay = 0;
            //cus_point = 0;

            //Bookings
            SqlQuery = "INSERT INTO Bookings OUTPUT INSERTED.BookingID VALUES (@ShowtimeID, @CustomerID, @StaffID, @PlacedByUserID, @TotalPrice, @CreatedAt, @VoucherID, @StudentCount, @ChildrenCount)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@ShowtimeID", SqlDbType.Int).Value = ShowtimeID;
            int cusID = CustomerID;
            if (cusID == -1)
                cusID = 1; //khách hàng mặc định - không đăng ký
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cusID;
            Nullable<int> staffId = getStaffID();
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = (staffId == null) ? (object)DBNull.Value : staffId;
            cmd.Parameters.Add("@StudentCount", SqlDbType.Int).Value = student_count;
            cmd.Parameters.Add("@ChildrenCount", SqlDbType.Int).Value = children_count;
            int plcdID = UserID;
            if (plcdID == -1)
                plcdID = 1;
            cmd.Parameters.Add("@PlacedByUserID", SqlDbType.Int).Value = plcdID;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now;
            int voucherId = getVoucherId();
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = (voucherId == -1) ? (object)DBNull.Value : voucherId;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            BookingID = (int)cmd.ExecuteScalar();
            conn.Close();


            //Deduct voucher quantity if used
            if (voucherId != -1)
            {
                SqlQuery = "UPDATE Vouchers SET " +
                    "Quantity = Quantity - 1 " +
                    "WHERE VoucherID = @VoucherID ";
                cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = voucherId;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            //BookingDetails
            SqlQuery = "INSERT INTO BookingDetails (BookingID, SeatID) VALUES ";
            int count = 0;
            cmd = conn.CreateCommand();
            foreach (int seatId in getSoldSeatsThisSession())
            {
                if (count != 0)
                    SqlQuery += ", ";
                SqlQuery += " (@BookingID" + count.ToString() + ", @SeatID" + count.ToString() + ") ";
                cmd.Parameters.Add("@BookingID" + count.ToString(), SqlDbType.Int).Value = BookingID;
                cmd.Parameters.Add("@SeatID" + count.ToString(), SqlDbType.Int).Value = seatId;
                count++;
            }
            cmd.CommandText = SqlQuery;
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (count > 0)
                cmd.ExecuteNonQuery();
            conn.Close();

            //BookingProducts
            SqlQuery = "INSERT INTO BookingProducts (BookingID, ProductID, Quantity) VALUES ";
            count = 0;
            cmd = conn.CreateCommand();
            foreach (DataRow row in sp_list.Rows)
            {
                if (count != 0)
                    SqlQuery += ", ";
                SqlQuery += " (@BookingID" + count.ToString() + ", @ProductID" + count.ToString() + ", @Quantity" + count.ToString() + ") ";
                cmd.Parameters.Add("@BookingID" + count.ToString(), SqlDbType.Int).Value = BookingID;
                cmd.Parameters.Add("@ProductID" + count.ToString(), SqlDbType.Int).Value = (int)row["id"];
                cmd.Parameters.Add("@Quantity" + count.ToString(), SqlDbType.Int).Value = (int)row["num"];
                count++;
            }
            cmd.CommandText = SqlQuery;
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (sp_list.Rows.Count > 0)
                cmd.ExecuteNonQuery();
            conn.Close();

            //Deduct sold products from inventory


            foreach (DataRow row in sp_list.Rows)
            {
                using (SqlConnection conn1 = Helper.getdbConnection())
                using (SqlCommand cmd1 = conn1.CreateCommand())
                {
                    SqlQuery = "UPDATE Products SET " +
                        "Quantity = Quantity - @Ordered " +
                        "WHERE ProductID = @ProductID";
                    cmd1.Parameters.Add("@ProductID", SqlDbType.Int).Value = (int)row["id"];
                    cmd1.Parameters.Add("@Ordered", SqlDbType.Int).Value = (int)row["num"];
                    cmd1.CommandText = SqlQuery;
                    cmd1.CommandType = CommandType.Text;
                    conn1.Open();
                    cmd1.ExecuteNonQuery();
                }
            }



            int pointsBefore = getLoyaltyPoints(CustomerID);
            UpdateLoyaltyPoints(); //Deduct loyalty points


            Hoadon hd = new Hoadon();
            hd.BillCode = BookingID;
            hd.LoyaltyPointsBefore = pointsBefore;
            hd.UsedPoints = !chkAccumulate.Checked;
            this.Close();
            hd.Show();
        }
        private int getLoyaltyPoints(int customerID)//Getting loyalty points before checkout to pass to bill
        {
            if (customerID == -1) return -1;
            SqlCommand cmd = conn.CreateCommand();
            string SqlQuery = "SELECT LoyaltyPoints FROM Customers WHERE CustomerID = @CustomerID";
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
            cmd.CommandText = SqlQuery;
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int pointsBefore = (int)cmd.ExecuteScalar();
            conn.Close();
            return pointsBefore;
        }
        private void UpdateLoyaltyPoints() //Deduct loyalty points
        {
            int pointsBefore = getLoyaltyPoints(CustomerID);
            string SqlQuery = "UPDATE Customers SET " +
                    "LoyaltyPoints = @LoyaltyPoints " +
                    "WHERE CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
            if (!chkAccumulate.Checked)
                cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = 0;
            else
            {
                cmd.Parameters.Add("@LoyaltyPoints", SqlDbType.Int).Value = pointsBefore + 1;
            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button100_Click(object sender, EventArgs e)
        {

        }
        private void ToggleCusPointButton(bool state)
        {
            chkAccumulate.Enabled = state;
            chkAccumulate.Visible = state;
            chkAccumulate.Checked = true;
        }
        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (!chkCustomer.Checked)
            {
                khachhang frm = new khachhang();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    chkCustomer.Checked = true;
                    CustomerID = frm.cus_code;
                }
                else
                {
                    chkCustomer.Checked = false;
                    CustomerID = -1;
                    cus_point = 0;
                    ToggleCusPointButton(false);
                    return;
                }
                //SQL
                string SqlQuery = "SELECT LoyaltyPoints FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cus_point = (int)cmd.ExecuteScalar();
                conn.Close();
                ToggleCusPointButton(true);
            }
            else
            {
                CustomerID = 1;
                chkCustomer.Checked = false;
                cus_point = 0;
                ToggleCusPointButton(false);
            }
            update();
        }

        private void sinhvien_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(sinhvien.Text))
            {
                if (int.TryParse(sinhvien.Text, out int sinhvienCount))
                {
                    int treemCount = string.IsNullOrWhiteSpace(treem.Text) ? 0 : int.Parse(treem.Text);
                    if (sinhvienCount + treemCount > selected.Count)
                    {
                        MessageBox.Show("Tổng số sinh viên và trẻ em không được vượt quá số ghế đã chọn!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sinhvien.Text = (selected.Count - treemCount).ToString();
                        sinhvien.SelectionStart = sinhvien.Text.Length;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sinhvien.Text = "";
                }
            }
            update();
        }

        private void treem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(treem.Text))
            {
                if (int.TryParse(treem.Text, out int treemCount))
                {
                    int sinhvienCount = string.IsNullOrWhiteSpace(sinhvien.Text) ? 0 : int.Parse(sinhvien.Text);
                    if (sinhvienCount + treemCount > selected.Count)
                    {
                        MessageBox.Show("Tổng số sinh viên và trẻ em không được vượt quá số ghế đã chọn!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        treem.Text = (selected.Count - sinhvienCount).ToString();
                        treem.SelectionStart = treem.Text.Length;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    treem.Text = "";
                }
            }
            update();
        }
        private void sinhvien_Enter(object sender, EventArgs e)
        {
            if (sinhvien.Text == "0")
            {
                sinhvien.Text = "";
            }
        }

        private void treem_Enter(object sender, EventArgs e)
        {
            if (treem.Text == "0")
            {
                treem.Text = "";
            }
        }

        private void voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voucher.SelectedItem.ToString() == "NONE")
            {
                discountPercent = 0;
                update();
                return;
            }
            float _discountPercent = 0;
            decimal minOrderValue = 0;
            string SqlQuery = "SELECT DiscountPercent, MinOrderValue FROM Vouchers WHERE VoucherID = @VoucherID";
            using (SqlConnection conn1 = Helper.getdbConnection())
            {
                using (SqlCommand cmd = new SqlCommand(SqlQuery, conn1))
                {
                    conn1.Open();
                    cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = getVoucherId();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            try
                            {
                                _discountPercent = float.Parse(reader.GetDouble(0).ToString());
                                minOrderValue = reader.GetDecimal(1);
                            }
                            catch (Exception ex)
                            {
                                if (ex is System.NullReferenceException)
                                    discountPercent = 0;
                            }
                    }
                }
            }
            if (minOrderValue > (decimal)need_to_pay_no_discount)
            {
                MessageBox.Show(
                    "Hoá đơn không đủ giá tiền tối thiểu để sử dụng voucher này.",
                    "Thông báo!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                voucher.SelectedIndex = 0;
                return;
            }
            discountPercent = _discountPercent;
            update();
        }

        private void chkAccumulate_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spButton_Click(object sender, EventArgs e)
        {
            spForm.ShowDialog();
            sp_list = spForm.List;
            food_total = 0;
            drinks_total = 0;
            string SqlQuery;
            SqlDataAdapter adapter;
            foreach (DataRow row in sp_list.Rows)
            {
                DataSet ds = new DataSet();
                SqlQuery = "SELECT CategoryName, Price " +
                    "FROM Products prd JOIN ProductCategories prc ON (prd.CategoryID = prc.CategoryID) " +
                    "WHERE ProductID = @ProductID";
                adapter = new SqlDataAdapter(SqlQuery, conn);
                adapter.SelectCommand.Parameters.Add("@ProductID", SqlDbType.Int).Value = (int)row["id"];
                adapter.Fill(ds, "sp");
                DataTable temp_table = ds.Tables["sp"];
                if (temp_table.Rows[0]["CategoryName"].ToString() == "Đồ ăn")
                {
                    food_total += Convert.ToInt32((decimal)(temp_table.Rows[0]["Price"]) * (int)(row["num"]));
                }
                else
                {
                    drinks_total += Convert.ToInt32((decimal)(temp_table.Rows[0]["Price"]) * (int)(row["num"]));
                }
            }
            update();

        }

        private void sinhvien_Leave(object sender, EventArgs e)
        {
            if (sinhvien.Text == "")
            {
                sinhvien.Text = "0";
            }
        }

        private void treem_Leave(object sender, EventArgs e)
        {
            if (treem.Text == "")
            {
                treem.Text = "0";
            }
        }
    }
}
