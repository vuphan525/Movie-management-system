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
    public partial class FormSuaSuCo : Form
    {
        public FormSuaSuCo()
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
        public string id;
        public FormSuaSuCo(string id)
        {
            InitializeComponent ();
            this.id = id;
        }

        private void FormSuaSuCo_Load(object sender, EventArgs e)
        {
            date_FormSuaSuCo_NgayTiepNhan.Format = DateTimePickerFormat.Custom;
            date_FormSuaSuCo_NgayTiepNhan.CustomFormat = "dd/MM/yyyy";
            LoadThongTinSuCo();
            if (CheckUsr()) 
                manv.SelectedIndex = 0;

            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
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
            lbl_FormSuaSuCo_MaSuCo.Clear();
            lbl_FormSuaSuCo_TenSuCo.Clear();
            cb_FormSuaSuCo_TinhTrang.SelectedIndex = -1;
            lbl_FormSuaSuCo_HuongGiaiQuyet.Clear();
            date_FormSuaSuCo_NgayTiepNhan.Value = DateTime.Now;
            lbl_FormSuaSuCo_MoTa.Clear();

            if (CheckUsr()) // <- GỌI Ở ĐÂY
                manv.SelectedIndex = 0;
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
        private void LoadThongTinSuCo()
        {
            conn = Helper.getdbConnection();

            string query = "SELECT IncidentName, ReportedByUserID, ReportedAt, Status, Description, Resolution " +
                           "FROM IncidentReports WHERE IncidentID = @id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(id); // biến `id` là từ constructor truyền vào

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Gán thông tin vào các controls
                lbl_FormSuaSuCo_MaSuCo.Text = id;
                lbl_FormSuaSuCo_TenSuCo.Text = reader["IncidentName"].ToString();
                lbl_FormSuaSuCo_MoTa.Text = reader["Description"].ToString();
                lbl_FormSuaSuCo_HuongGiaiQuyet.Text = reader["Resolution"].ToString();

                date_FormSuaSuCo_NgayTiepNhan.Value = Convert.ToDateTime(reader["ReportedAt"]);

                cb_FormSuaSuCo_TinhTrang.SelectedItem = reader["Status"].ToString();

                // Load người dùng (userID) vào combobox manv và chọn đúng dòng
                int reportedByUserID = Convert.ToInt32(reader["ReportedByUserID"]);
                for (int i = 0; i < manv.Items.Count; i++)
                {
                    string itemText = manv.Items[i].ToString();
                    if (itemText.Contains("(ID: " + reportedByUserID.ToString() + ")"))
                    {
                        manv.SelectedIndex = i;
                        break;
                    }
                }
            }
            reader.Close();
            conn.Close();
        }



        private void bcButton_Click(object sender, EventArgs e)
        {

            if (manv.SelectedItem == null ||
               string.IsNullOrWhiteSpace(lbl_FormSuaSuCo_TenSuCo.Text) ||
               string.IsNullOrWhiteSpace(lbl_FormSuaSuCo_MoTa.Text) 
               )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
           
            // Update values in selected row

            string SqlQuery = "UPDATE IncidentReports SET " +
                "IncidentName = @IncidentName, " +
                "ReportedByUserID = @ReportedByUserID, " +
                "ReportedAt = @ReportedAt, " +
                "Status = @Status, " +
                "Description = @Description," +
                "Resolution = @Resolution " +
                "WHERE IncidentID = @IncidentID";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@IncidentID", SqlDbType.Int).Value = int.Parse(lbl_FormSuaSuCo_MaSuCo.Text);
            cmd.Parameters.Add("@IncidentName", SqlDbType.NVarChar).Value = lbl_FormSuaSuCo_TenSuCo.Text;
            int usrID = int.Parse(Helper.SubStringBetween(manv.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@ReportedByUserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@ReportedAt", SqlDbType.Date).Value = date_FormSuaSuCo_NgayTiepNhan.Value.Date;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = cb_FormSuaSuCo_TinhTrang.SelectedItem;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = lbl_FormSuaSuCo_MoTa.Text;
            cmd.Parameters.Add("@Resolution", SqlDbType.NVarChar).Value = "placeholder";//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
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
            conn.Close();

        }
    }
}
