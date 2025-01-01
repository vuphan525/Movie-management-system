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
namespace Qlyrapchieuphim
{
    public partial class formbanve : Form
    {
        public List<Guna2Button> sold = new List<Guna2Button>();
        public List<Guna2Button> selected = new List<Guna2Button>();
        public List<Guna2Button> vip = new List<Guna2Button>();
        public List<Guna2Button> vipcount = new List<Guna2Button>();
        public string MASUATCHIEU;
        string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        string picture_url = string.Empty;
        public int total = 0;
        public int need_to_pay = 0;
        public int discount = 0;
        string makh = string.Empty;
        int cus_point = 0;
        int food_total = 0;
        int drinks_total = 0;
        int cus_discount = 0;
        DataTable sp_list = new DataTable();
        Bansanpham spForm = new Bansanpham();
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        public formbanve()
        {
            InitializeComponent();
            sinhvien.Text = "0";
            treem.Text = "0";
           tongtien.Text = "0 VND";
            cantra.Text = "0 VND";
            ToggleCusPointButton(false);
        }
        public formbanve(string masc)
        {
            InitializeComponent();
            MASUATCHIEU = masc;
            sinhvien.Text = "0";
            treem.Text = "0";
            tongtien.Text = "0 VND";
            cantra.Text = "0 VND";
            ToggleCusPointButton(false);
        }
        public string CusCode
        {
            get { return makh; }
            set { makh = value; }
        }
        private void checkDate()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT MAPHATHANH, NGAYPHATHANH, NGAYKETTHUC FROM VOUCHER";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery,conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "VOUCHER");
            DataTable dt = ds.Tables["VOUCHER"];
            foreach (DataRow dr in dt.Rows)
            {
                string state = string.Empty;
                DateTime denngay = (DateTime)dr["NGAYKETTHUC"];
                DateTime hieuluctu = (DateTime)dr["NGAYPHATHANH"];
                if (denngay.Date < DateTime.Today)
                    state = "Đã hêt hiệu lực"; //hết hiệu lực
                else if (hieuluctu.Date <= DateTime.Today)
                    state = "Đang áp dụng"; //đang áp dụng
                else state = "Chưa áp dụng"; //chưa áp dụng
                SqlQuery = "UPDATE VOUCHER SET TINHTRANG = @state WHERE MAPHATHANH = @maph";
                SqlCommand cmd = new SqlCommand(SqlQuery,conn);
                cmd.Parameters.Add("@state",SqlDbType.NVarChar).Value = state;
                cmd.Parameters.Add("@maph", SqlDbType.Char).Value = dr["MAPHATHANH"].ToString();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        private bool CheckVoucher()
        {
            checkDate();
            int count;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM VOUCHER WHERE TINHTRANG = N'Đang áp dụng'";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar() + 1;


            SqlQuery = "SELECT MAPHATHANH FROM VOUCHER";
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
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string SqlQuery;
            SqlCommand cmd;
            foreach (Guna2Button button in flowLayoutPanel1.Controls)
            {
                SqlQuery = "SELECT CellValue From S_" + MASUATCHIEU + " WHERE SeatName = @seatname";
                cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@seatname", SqlDbType.VarChar).Value = button.Text;
                bool bought = (bool)cmd.ExecuteScalar();
                if (bought)
                    sold.Add(button);
            }
            SqlQuery = "SELECT MAPHONG FROM SUATCHIEU WHERE MASUATCHIEU = @masc";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.VarChar).Value = MASUATCHIEU;
            lblRoom.Text = "Phòng chiếu: " + cmd.ExecuteScalar().ToString();
            

            SqlQuery = "SELECT p.POSTER_URL " +
                "FROM SUATCHIEU sc, BOPHIM p " +
                "WHERE (MASUATCHIEU = @masc) AND (sc.MAPHIM = p.MAPHIM)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@masc", SqlDbType.VarChar).Value = MASUATCHIEU;
            string relative_picture_path = cmd.ExecuteScalar().ToString();
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
            conn.Close();
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
            LoadData();
            InitializeSeats();
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
                this.Close();
                return;
            }
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
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
                        SqlQuery = "UPDATE S_" + MASUATCHIEU + " SET CellValue = @bought  WHERE SeatName = @seatname";
                        cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@seatname", SqlDbType.VarChar).Value = seatButton.Text;
                        cmd.Parameters.Add("@bought", SqlDbType.Bit).Value = true;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
            //tongtien.Text = "0 VND";
            //cantra.Text = "0 VND";

            //total = 0;
            //discount = 0;
            //need_to_pay = 0;
            //cus_point = 0;
            SqlQuery = "SELECT COUNT(*) FROM HOADON";
            cmd = new SqlCommand(SqlQuery, conn);
            conn.Open();
            int existing_bills = (int)cmd.ExecuteScalar();
            conn.Close();

            SqlQuery = "INSERT INTO HOADON VALUES (@mahd, @masc, @soghe, @makh, @total, @food, @drinks, @discount)";
            cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@mahd", SqlDbType.Char).Value = existing_bills.ToString("D16");
            cmd.Parameters.Add("@masc", SqlDbType.Char).Value = MASUATCHIEU;
            cmd.Parameters.Add("@soghe", SqlDbType.Int).Value = selected.Count;
            cmd.Parameters.Add("@makh", SqlDbType.Char).Value = makh;
            cmd.Parameters.Add("@total", SqlDbType.Int).Value = total;
            cmd.Parameters.Add("@food", SqlDbType.Int).Value = food_total;
            cmd.Parameters.Add("@drinks", SqlDbType.Int).Value = drinks_total;
            cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount + cus_discount;
            conn.Open ();
            cmd.ExecuteNonQuery();
            conn.Close ();
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
                    makh = frm.cus_code;
                }
                else
                {
                    chkCustomer.Checked = false;
                    makh = string.Empty;
                    cus_point = 0;
                    ToggleCusPointButton(false);
                    return;
                }
                //SQL
                SqlConnection conn = new SqlConnection(ConnString);
                string SqlQuery = "SELECT DIEMTICHLUY FROM KHACHHANG WHERE MAKHACHHANG = @mkh";
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                cmd.Parameters.Add("@mkh",SqlDbType.Char).Value = makh;
                conn.Open();
                cus_point = (int)cmd.ExecuteScalar();
                conn.Close();
                ToggleCusPointButton(true);
            }
            else
            {
                makh = string.Empty;
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
            if(sinhvien.Text == "0")
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
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery = "SELECT MENHGIA FROM VOUCHER WHERE MAPHATHANH = @mph";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@mph",SqlDbType.Char).Value = voucher.SelectedItem;
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
            sp_list = spForm.List;
            food_total = 0;
            drinks_total = 0;
            SqlConnection conn = new SqlConnection(ConnString);
            string SqlQuery;
            SqlDataAdapter adapter;
            foreach (DataRow row in sp_list.Rows)
            {
                DataSet ds = new DataSet();
                SqlQuery = "SELECT LOAI, GIA FROM SANPHAM WHERE MASP = @masp";
                adapter = new SqlDataAdapter(SqlQuery, conn);
                adapter.SelectCommand.Parameters.Add("@masp",SqlDbType.Char).Value = row["id"].ToString();
                adapter.Fill(ds, "sp");
                DataTable temp_table = ds.Tables["sp"];
                if (temp_table.Rows[0]["LOAI"].ToString() == "Đồ ăn")
                {
                    food_total = int.Parse(temp_table.Rows[0]["GIA"].ToString()) * int.Parse(row["num"].ToString());
                }
                else
                {
                    drinks_total = int.Parse(temp_table.Rows[0]["GIA"].ToString()) * int.Parse(row["num"].ToString());
                }
            }
            update();
        }
    }
}
