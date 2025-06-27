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
            this.Paint += FormThemPhim_Paint;
        }
        SqlConnection conn;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemVoucher_Load(object sender, EventArgs e)
        {
            date_FormThemVoucher_NgayHetHan.Format = DateTimePickerFormat.Custom;
            date_FormThemVoucher_NgayHetHan.CustomFormat = "dd/MM/yyyy";
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_FormThemVoucher_MaPhatHanh.Clear();
            
            lbl_FormThemVoucher_DiscountPercent.Clear();
            date_FormThemVoucher_NgayHetHan.Value = DateTime.Now;
            lbl_FormThemVoucher_SoLuong.Clear();
            lbl_FormThemVoucher_HoaDonToiThieu.Clear();
            cb_FormThemVoucher_TrangThai.SelectedIndex = -1;
            lbl_FormThemVoucher_MoTa.Clear();
        }

        private void them_Click(object sender, EventArgs e)
        {
           
            double mgia;
            
            if (date_FormThemVoucher_NgayHetHan.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //SQL section

            string SqlQuery = "INSERT INTO Vouchers VALUES (@Code, @Description, @DiscountAmount, @DiscountPercent, @ExpiryDate, @Quantity, @MinOrderValue, @IsActive)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = lbl_FormThemVoucher_MaPhatHanh.Text;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value =lbl_FormThemVoucher_MoTa.Text; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.Decimal).Value = 0;
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.Float).Value = 10; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = date_FormThemVoucher_NgayHetHan.Value.Date;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = lbl_FormThemVoucher_SoLuong.Text;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@MinOrderValue", SqlDbType.Decimal).Value = int.Parse(lbl_FormThemVoucher_HoaDonToiThieu.Text);//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
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

        private void lbl_FormThemVoucher_DiscountPercent_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lbl_FormThemVoucher_DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
