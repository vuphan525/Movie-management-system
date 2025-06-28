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

namespace Qlyrapchieuphim
{
    public partial class FormThemVoucher : Form
    {
        public FormThemVoucher()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            cb_FormThemVoucher_TrangThai.Enabled = false;
            this.Paint += FormThemPhim_Paint;
        }
        SqlConnection conn;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemVoucher_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            date_FormThemVoucher_NgayHetHan.Format = DateTimePickerFormat.Custom;
            date_FormThemVoucher_NgayHetHan.CustomFormat = "dd/MM/yyyy";
            date_FormThemVoucher_NgayHetHan.Value = DateTime.Today;
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
            lbl_FormThemVoucher_MaPhatHanh.Clear();

            lbl_FormThemVoucher_DiscountPercent.Clear();
            date_FormThemVoucher_NgayHetHan.Value = DateTime.Today;
            lbl_FormThemVoucher_SoLuong.Clear();
            lbl_FormThemVoucher_HoaDonToiThieu.Clear();
            cb_FormThemVoucher_TrangThai.SelectedIndex = -1;
            lbl_FormThemVoucher_MoTa.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_FormThemVoucher_MaPhatHanh.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormThemVoucher_DiscountPercent.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgia;
            if (!double.TryParse(lbl_FormThemVoucher_DiscountPercent.Text, out mgia))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //chuyển số được nhập từ dạng 0 - 100 sang 0 - 1
            mgia /= 100;
            //SQL section

            string SqlQuery = "INSERT INTO Vouchers VALUES (@Code, @Description, @DiscountAmount, @DiscountPercent, @ExpiryDate, @Quantity, @MinOrderValue, @IsActive)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = lbl_FormThemVoucher_MaPhatHanh.Text;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormThemVoucher_MoTa.Text;
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.Decimal).Value = 0; //Không còn sử dụng mệnh giá cứng
            cmd.Parameters.Add("@DiscountPercent", SqlDbType.Float).Value = mgia;
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = date_FormThemVoucher_NgayHetHan.Value.Date;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = lbl_FormThemVoucher_SoLuong.Text;
            cmd.Parameters.Add("@MinOrderValue", SqlDbType.Decimal).Value = int.Parse(lbl_FormThemVoucher_HoaDonToiThieu.Text);
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Convert.ToBoolean(cb_FormThemVoucher_TrangThai.SelectedIndex);
            try
            {
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
                            "Mã suất chiếu không được trùng nhau!",
                            "Lỗi nhập liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    default:
                        throw;
                }
            }
        }
        private bool percentError = false;
        private void lbl_FormThemVoucher_DiscountPercent_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(lbl_FormThemVoucher_DiscountPercent.Text, out _))
            {
                errorProvider1.SetError(lbl_FormThemVoucher_DiscountPercent, "Mệnh giá phải được nhập dưới dạng một số!");
                percentError = true;
            }
            else
            {
                errorProvider1.Clear();
                percentError = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbl_FormThemVoucher_DiscountPercent_Leave(object sender, EventArgs e)
        {
            if (percentError)
                return;
            double mgia = double.Parse(lbl_FormThemVoucher_DiscountPercent.Text);
            if (mgia < 0)
                lbl_FormThemVoucher_DiscountPercent.Text = "0";
            else if (mgia > 100)
                lbl_FormThemVoucher_DiscountPercent.Text = "100";
        }

        private void date_FormThemVoucher_NgayHetHan_ValueChanged(object sender, EventArgs e)
        {
            if (date_FormThemVoucher_NgayHetHan.Value.Date < DateTime.Today)
                cb_FormThemVoucher_TrangThai.SelectedIndex = 0; //NOT ACTIVE
            else
                cb_FormThemVoucher_TrangThai.SelectedIndex = 1; //ACTIVE
        }
    }
}
