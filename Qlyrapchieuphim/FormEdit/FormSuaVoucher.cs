using Guna.UI2.WinForms;
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

namespace Qlyrapchieuphim.FormEdit
{
    public partial class FormSuaVoucher : Form
    {
        public FormSuaVoucher(int voucherID)
        {
            InitializeComponent();
            this.voucherID = voucherID;
            cb_FormSuaVoucher_TrangThai.Enabled = false;
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
        }
        SqlConnection conn = null;
        private int voucherID;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaVoucher_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            date_FormSuaVoucher_NgayHetHan.Format = DateTimePickerFormat.Custom;
            date_FormSuaVoucher_NgayHetHan.CustomFormat = "dd/MM/yyyy";
            date_FormSuaVoucher_NgayHetHan.Value = DateTime.Today;
            LoadData();
        }

        private void FormThemPhim_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 2;
            Color borderColor = Color.MediumSlateBlue;

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormSuaVoucher_MaPhatHanh.Clear();

            lbl_FormSuaVoucher_DiscountPercent.Clear();
            date_FormSuaVoucher_NgayHetHan.Value = DateTime.Today;
            lbl_FormSuaVoucher_SoLuong.Clear();
            lbl_FormSuaVoucher_HoaDonToiThieu.Clear();
            cb_FormSuaVoucher_TrangThai.SelectedIndex = -1;
            lbl_FormSuaVoucher_MoTa.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_FormSuaVoucher_MaPhatHanh.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormSuaVoucher_DiscountPercent.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgiam;
            if (!double.TryParse(lbl_FormSuaVoucher_DiscountPercent.Text, out mgiam))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dưới dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //chuyển số được nhập từ dạng 0 - 100 sang 0 - 1
            mgiam /= 100;
            // Update values in selected row
            //SQL section

            string SqlQuery = "UPDATE Vouchers SET " +
                "Code = @Code, " +
                "Description = @Description, " +
                "DiscountPercent = @DiscountPercent, " +
                "ExpiryDate = @ExpiryDate, " +
                "Quantity = @Quantity, " +
                "MinOrderValue = @MinOrderValue, " +
                "IsActive = @IsActive " +
                "WHERE VoucherID = @VoucherID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = lbl_FormSuaVoucher_MaPhatHanh.Text;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormSuaVoucher_MoTa.Text;
            cmd.Parameters.Add("@DiscountPercent", SqlDbType.Float).Value = mgiam;
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = date_FormSuaVoucher_NgayHetHan.Value.Date;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = lbl_FormSuaVoucher_SoLuong.Text;
            cmd.Parameters.Add("@MinOrderValue", SqlDbType.Decimal).Value = int.Parse(lbl_FormSuaVoucher_HoaDonToiThieu.Text);
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Convert.ToBoolean(cb_FormSuaVoucher_TrangThai.SelectedIndex);
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = voucherID;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(
                            "Mã phát hành không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    default:
                        throw;
                }
            }
        }
        private void LoadData()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string SqlQuery = "SELECT Code, Description, DiscountPercent, ExpiryDate, Quantity, MinOrderValue, IsActive FROM Vouchers " +
                "WHERE VoucherID = @voucherID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@voucherID", SqlDbType.Int).Value = voucherID;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Gán thông tin vào các controls
                lbl_FormSuaVoucher_MaPhatHanh.Text = reader["Code"].ToString();
                lbl_FormSuaVoucher_MoTa.Text = reader["Description"].ToString();
                lbl_FormSuaVoucher_DiscountPercent.Text = reader["DiscountPercent"].ToString();
                date_FormSuaVoucher_NgayHetHan.Value = (DateTime)reader["ExpiryDate"];
                lbl_FormSuaVoucher_SoLuong.Text = reader["Quantity"].ToString();
                lbl_FormSuaVoucher_HoaDonToiThieu.Text = reader["Quantity"].ToString();
                bool tempState = (bool)reader["IsActive"];
                cb_FormSuaVoucher_TrangThai.SelectedIndex = Convert.ToInt32(tempState);
            }
            reader.Close();
            conn.Close();
        }
        private bool percentError = false;
        private void lbl_FormSuaVoucher_DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(lbl_FormSuaVoucher_DiscountPercent.Text, out _))
            {
                errorProvider1.SetError(lbl_FormSuaVoucher_DiscountPercent, "Mệnh giá phải được nhập dưới dạng một số!");
                percentError = true;
            }
            else
            {
                errorProvider1.Clear();
                percentError = false;
            }
        }

        private void lbl_FormSuaVoucher_DiscountPercent_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_FormSuaVoucher_DiscountPercent_MouseLeave(object sender, EventArgs e)
        {
            if (percentError)
                return;
            double mgia = double.Parse(lbl_FormSuaVoucher_DiscountPercent.Text);
            if (mgia < 0)
                lbl_FormSuaVoucher_DiscountPercent.Text = "0";
            else if (mgia > 100)
                lbl_FormSuaVoucher_DiscountPercent.Text = "100";
        }

        private void date_FormSuaVoucher_NgayHetHan_ValueChanged(object sender, EventArgs e)
        {
            if (date_FormSuaVoucher_NgayHetHan.Value.Date < DateTime.Today)
                cb_FormSuaVoucher_TrangThai.SelectedIndex = 0; //NOT ACTIVE
            else
                cb_FormSuaVoucher_TrangThai.SelectedIndex = 1; //ACTIVE
        }
    }
}
