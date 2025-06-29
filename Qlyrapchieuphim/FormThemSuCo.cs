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
    public partial class FormThemSuCo : Form
    {


        SqlConnection conn;
        public FormThemSuCo()
        {
            InitializeComponent();
            Guna2ShadowForm shadow = new Guna2ShadowForm();
            shadow.TargetForm = this;
            this.Paint += FormThemPhim_Paint;
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
        }
        private bool CheckUsr()
        {
            int count;
            conn.Open();
            string SqlQuery = "SELECT COUNT(*) FROM Users";
            SqlCommand countCmd = new SqlCommand(SqlQuery, conn);
            count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                manv.Enabled = true;
               
                SqlQuery = "SELECT UserID, Username FROM Users";
                string[] employees = new string[count];
                SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    employees[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
                    i++;
                }
                manv.DataSource = employees;
            }
            else
            {
                manv.Enabled = false;
                
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemSuCo_Load(object sender, EventArgs e)
        {
            date_FormThemSuCo_NgayTiepNhan.Format = DateTimePickerFormat.Custom;
            date_FormThemSuCo_NgayTiepNhan.CustomFormat = "dd/MM/yyyy";
            if (CheckUsr()) // <- GỌI Ở ĐÂY
                manv.SelectedIndex = 0;

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
            lbl_FormThemSuCo_MaSuCo.Clear();
            lbl_FormThemSuCo_TenSuCo.Clear();
            cb_FormThemSuCo_TinhTrang.SelectedIndex = -1;
            lbl_FormThemSuCo_HuongGiaiQuyet.Clear();
            date_FormThemSuCo_NgayTiepNhan.Value = DateTime.Now;
            lbl_FormThemSuCo_MoTa.Clear();
            this.Refresh();
        }

        private void bcButton_Click(object sender, EventArgs e)
        {
            if (manv.SelectedItem == null ||
                string.IsNullOrWhiteSpace(lbl_FormThemSuCo_TenSuCo.Text) ||
                string.IsNullOrWhiteSpace(lbl_FormThemSuCo_MoTa.Text) 
              )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //SQL section
            string SqlQuery = "INSERT INTO IncidentReports VALUES (@IncidentName, @ReportedByUserID, @RelatedObjectType, @RelatedObjectID, @Description, @ReportedAt, @Status, @Resolution)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@IncidentName", SqlDbType.NVarChar).Value = lbl_FormThemSuCo_TenSuCo.Text;
            int usrID = int.Parse(Helper.SubStringBetween(manv.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@ReportedByUserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@RelatedObjectType", SqlDbType.NVarChar).Value = "None";
            cmd.Parameters.Add("@RelatedObjectID", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ReportedAt", SqlDbType.Date).Value = date_FormThemSuCo_NgayTiepNhan.Value.Date;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cb_FormThemSuCo_TinhTrang.SelectedItem;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormThemSuCo_MoTa.Text;
            cmd.Parameters.Add("@Resolution", SqlDbType.NVarChar).Value = lbl_FormThemSuCo_HuongGiaiQuyet.Text;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
               this.Close();
                MessageBox.Show("Thêm sự cố thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
    }
}
