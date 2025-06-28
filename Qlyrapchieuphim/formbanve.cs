using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Identity.Client;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Web.Compilation;
using System.IO;
using Microsoft.IdentityModel.Tokens;
namespace Qlyrapchieuphim
{
    public partial class formbanve : Form
    {
        public List<Guna2Button> sold = new List<Guna2Button>();
        public List<Guna2Button> selected = new List<Guna2Button>();
        public List<Guna2Button> vip = new List<Guna2Button>();
        public List<Guna2Button> vipcount = new List<Guna2Button>();
        public int ShowtimeID;
        SqlConnection conn = null;
        string picture_url = string.Empty;
        public int total = 0;
        public int need_to_pay = 0;
        public int discount = 0;
        private int CustomerID = -1;
        private int UserID = -1;
        int cus_point = 0;
        int food_total = 0;
        int drinks_total = 0;
        int cus_discount = 0;
        DataTable sp_list = new DataTable();
        Bansanpham spForm = new Bansanpham();
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
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
            if ( role == "customer" || role.IsNullOrEmpty())
                return false;
            else
                return true;
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
            string SqlQuery = "SELECT COUNT(*) FROM Vouchers WHERE IsActive = 1";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar() + 1;


            SqlQuery = "SELECT Code FROM Vouchers";
            string[] vouchers = new string[count];
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            vouchers[0] = "NONE";
            int i = 1;
            while (reader.Read())
            {
                vouchers[i] = reader.GetString(0);
                i++;
            }
            reader.Close();
            voucher.DataSource = vouchers;
            voucher.SelectedIndex = 0;
            if (count > 0)
                return true;
            else
                return false;
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
                "FROM Showtimes sht JOIN Movies mv ON (sht.MovieID = Movies.MovieID) " +
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
                    int b = string.IsNullOrWhiteSpace(sinhvien.Text) ? 0 : int.Parse(sinhvien.Text);
                    int c = string.IsNullOrWhiteSpace(treem.Text) ? 0 : int.Parse(treem.Text);

                    if (b + c > selected.Count)
                    {
                        c = selected.Count - b;
                        treem.Text = c.ToString();
                    }

                    int d = selected.Count - b - c;
                    total = d * 55000 + vipcount.Count * 5000 + b * 40000 + c * 40000;
                    //need_to_pay = total - discount + food_total + drinks_total;

                    //tongtien.Text = total.ToString() + " VND";
                    //cantra.Text = need_to_pay.ToString() + " VND";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (!chkAccumulate.Checked)
                cus_discount = cus_point * 2000;
            else
                cus_discount = 0;
            need_to_pay = total - discount + food_total + drinks_total - cus_discount;

            if (need_to_pay < 0)
                need_to_pay = 0;
            tongtien.Text = total.ToString() + " VND";
            cantra.Text = need_to_pay.ToString() + " VND";
            int to_print = discount + cus_discount;
            lblDiscount.Text = to_print.ToString() + " VND";
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
                        seatButton.FillColor = Color.DimGray;
                        seatButton.Enabled = false;
                        selected.Remove(seatButton);
                        vipcount.Remove(seatButton);
                        SqlQuery = "UPDATE S_" + ShowtimeID + " SET CellValue = @bought  WHERE SeatName = @seatname";
                        cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@seatname", SqlDbType.VarChar).Value = seatButton.Text;
                        cmd.Parameters.Add("@bought", SqlDbType.Bit).Value = true;
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            
            //tongtien.Text = "0 VND";
            //cantra.Text = "0 VND";

            //total = 0;
            //discount = 0;
            //need_to_pay = 0;
            //cus_point = 0;

            //Bookings
            SqlQuery = "INSERT INTO Bookings OUTPUT INSERTED.BookingID VALUES (@ShowtimeID, @CustomerID, @StaffID, @PlacedByUserID, @TotalPrice, @CreatedAt, @VoucherID)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@ShowtimeID", SqlDbType.Int).Value = ShowtimeID;
            int cusID = CustomerID;
            if (cusID == -1)
                cusID = 1; //khách hàng mặc định - không đăng ký
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cusID;
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = getStaffID();
            int plcdID = UserID;
            if (plcdID == -1)
                plcdID = 1;
            cmd.Parameters.Add("@PlacedByUserID", SqlDbType.Int).Value = plcdID;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = total;
            cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now;

            cmd.Parameters.Add("@soghe", SqlDbType.Int).Value = selected.Count;
            cmd.Parameters.Add("@food", SqlDbType.Int).Value = food_total;
            cmd.Parameters.Add("@drinks", SqlDbType.Int).Value = drinks_total;
            cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount + cus_discount;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Hoadon hd = new Hoadon();
            hd.BillCode = existing_bills.ToString("D16");
            hd.UsedPoints = !chkAccumulate.Checked;
            this.Close();
            hd.Show();
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
                string SqlQuery = "SELECT DIEMTICHLUY FROM KHACHHANG WHERE MAKHACHHANG = @mkh";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@mkh", SqlDbType.Char).Value = CustomerID;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cus_point = (int)cmd.ExecuteScalar();
                conn.Close();
                ToggleCusPointButton(true);
            }
            else
            {
                CustomerID = -1;
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
            if ((string)voucher.SelectedItem == "NONE")
            {
                discount = 0;
                update();
                return;
            }
            string SqlQuery = "SELECT MENHGIA FROM VOUCHER WHERE MAPHATHANH = @mph";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@mph", SqlDbType.Char).Value = voucher.SelectedItem;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try
            {
                discount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (ex is System.NullReferenceException)
                    discount = 0;
            }
            conn.Close();
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
                SqlQuery = "SELECT LOAI, GIA FROM SANPHAM WHERE MASP = @masp";
                adapter = new SqlDataAdapter(SqlQuery, conn);
                adapter.SelectCommand.Parameters.Add("@masp", SqlDbType.Char).Value = row["id"].ToString();
                adapter.Fill(ds, "sp");
                DataTable temp_table = ds.Tables["sp"];
                if (temp_table.Rows[0]["LOAI"].ToString() == "Đồ ăn")
                {
                    food_total += int.Parse(temp_table.Rows[0]["GIA"].ToString()) * int.Parse(row["num"].ToString());
                }
                else
                {
                    drinks_total += int.Parse(temp_table.Rows[0]["GIA"].ToString()) * int.Parse(row["num"].ToString());
                }
            }
            update();
        }
    }
}
