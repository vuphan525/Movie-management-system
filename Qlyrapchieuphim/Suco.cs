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
using System.Configuration;
using Qlyrapchieuphim.FormEdit;

namespace Qlyrapchieuphim
{
    public partial class Suco : UserControl
    {
        SqlConnection conn;
        public Suco()
        {
            InitializeComponent();
            dataGridView1.AutoSize = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            tinhtrang.SelectedIndex = 2;
            ngaytiepnhan.Value=DateTime.Today;
            //masuco.MaxLength = 16;
            masuco.Enabled = false;
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
                errorProvider1.Clear();
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
                errorProvider1.SetError(manv, "Không có tài khoản trong hệ thống!");
            }
            conn.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        private void LoadData()
        {
            conn.Open();
            string SqlQuery = "SELECT IncidentID, IncidentName, ReportedByUserID, Status, Resolution, ReportedAt, Description, Username " +
                "FROM IncidentReports ir , Users usr " +
                "WHERE (ir.ReportedByUserID = usr.UserID)";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "IncidentReports");
            DataTable dt = ds.Tables["IncidentReports"];
            dataGridView1.DataSource = dt;
            if (!dataGridView1.Columns.Contains("Actions"))
            {
                DataGridViewTextBoxColumn actionCol = new DataGridViewTextBoxColumn();
                actionCol.Name = "Actions";
                actionCol.HeaderText = "Actions";
                actionCol.Width = 60;
                dataGridView1.Columns.Add(actionCol);
            }

            dataGridView1.Columns["Actions"].DisplayIndex = dataGridView1.Columns.Count - 1;
            conn.Close();
            this.Refresh();
        }
        private void guna2Button1_Click(object sender, EventArgs e) //bcButton
        {
            if (manv.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tensuco.Text) ||
                string.IsNullOrWhiteSpace(mota.Text) /*||
                string.IsNullOrEmpty(masuco.Text)*/)
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
            cmd.Parameters.Add("@IncidentName", SqlDbType.NVarChar).Value = tensuco.Text;
            int usrID = int.Parse(Helper.SubStringBetween(manv.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@ReportedByUserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@RelatedObjectType", SqlDbType.NVarChar).Value = "None";
            cmd.Parameters.Add("@RelatedObjectID", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@ReportedAt", SqlDbType.Date).Value = ngaytiepnhan.Value.Date;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = tinhtrang.SelectedItem;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = mota.Text;
            cmd.Parameters.Add("@Resolution", SqlDbType.NVarChar).Value = "placeholder";//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                Updatea();
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
            Updatea();

        }
        void Updatea()
        {
            masuco.Clear();
            masuco.Enabled =false;
            tinhtrang.SelectedIndex = 2;
            tensuco.Clear();
            if (CheckUsr())
                manv.SelectedIndex = 0;
            ngaytiepnhan.Value = DateTime.Today;
            mota.Clear();
            dataGridView1.ClearSelection();
        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (manv.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tensuco.Text) ||
                string.IsNullOrWhiteSpace(mota.Text) /*||
                string.IsNullOrEmpty(masuco.Text)*/)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

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
            cmd.Parameters.Add("@IncidentID", SqlDbType.Int).Value = int.Parse(masuco.Text);
            cmd.Parameters.Add("@IncidentName", SqlDbType.NVarChar).Value = tensuco.Text;
            int usrID = int.Parse(Helper.SubStringBetween(manv.SelectedItem.ToString(), " (ID: ", ")"));
            cmd.Parameters.Add("@ReportedByUserID", SqlDbType.Int).Value = usrID;
            cmd.Parameters.Add("@ReportedAt", SqlDbType.Date).Value = ngaytiepnhan.Value.Date;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = tinhtrang.SelectedItem;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = mota.Text;
            cmd.Parameters.Add("@Resolution", SqlDbType.NVarChar).Value = "placeholder";//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                Updatea();
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

        private void xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dòng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    conn.Open();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["IncidentID"].ToString();
                        string SqlQuery = "DELETE FROM IncidentReports WHERE IncidentID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Updatea();
        }
        private void PrintToTextBoxes(int row)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            masuco.Text = dt.Rows[row]["IncidentID"].ToString();
            masuco.Enabled = false;
            DateTime date = (DateTime)dt.Rows[row]["ReportedAt"];
            ngaytiepnhan.Value = date;
            manv.SelectedItem = dt.Rows[row]["Username"] + " (ID: " + dt.Rows[row]["ReportedByUserID"] + ")";
            tinhtrang.SelectedItem = dt.Rows[row]["Status"];
            tensuco.Text = dt.Rows[row]["IncidentName"].ToString();
            mota.Text = dt.Rows[row]["Description"].ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PrintToTextBoxes((int)e.RowIndex);
            }

            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                // Tính vị trí click so với ô
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dataGridView1.PointToClient(Cursor.Position).X - cellRect.X;

                int iconSize = 32;
                int padding = 8;
                int editLeft = padding;
                int deleteLeft = editLeft + iconSize + padding;

                if (clickX >= editLeft && clickX < editLeft + iconSize)
                {
                    string id;
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    id = dt.Rows[e.RowIndex]["IncidentID"].ToString();

                    // 👉 Click icon Edit
                    using (FormSuaSuCo popup = new FormSuaSuCo(id))
                    {
                        popup.StartPosition = FormStartPosition.CenterParent;
                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData(); // Chỉ gọi nếu form kia trả về OK
                        }
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    // 👉 Click icon Delete
                    MessageBox.Show("Bạn vừa click nút xóa (tạm thời chưa có hành động).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Helper.DrawNumbering(sender, e, this);
        }

        private void Suco_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            conn = Helper.CheckDbConnection(conn);
            Updatea();
            LoadData();
            dataGridView1.RowTemplate.Height = 45;
        }

        private void Suco_Paint(object sender, PaintEventArgs e)
        {
            CheckUsr();
            if (!manv.Enabled)
            {
                bcButton.Enabled = false;
                xoa.Enabled = false;
                capnhat.Enabled = false;
            }
            else
            {
                bcButton.Enabled = true;
                xoa.Enabled = true;
                capnhat.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemSuCo popup = new FormThemSuCo())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData(); // Chỉ gọi nếu form kia trả về OK
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;

                // Tọa độ vẽ
                int iconSize = 32;
                int padding = 8;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                int editX = e.CellBounds.X + padding;
                int deleteX = editX + iconSize + padding;

                // Vẽ icon Sửa
                e.Graphics.DrawImage(Properties.Resources.icons8_edit_32, new Rectangle(editX, iconY, iconSize, iconSize));
                // Vẽ icon Xóa
                e.Graphics.DrawImage(Properties.Resources.icons8_delete_32, new Rectangle(deleteX, iconY, iconSize, iconSize));
            }
        }
    }
}
