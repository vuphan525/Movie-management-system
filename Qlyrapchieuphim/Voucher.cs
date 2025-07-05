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
using System.Configuration;
using Qlyrapchieuphim.FormEdit;

namespace Qlyrapchieuphim
{
    public partial class Voucher : UserControl
    {
        SqlConnection conn;
        public Voucher()
        {

            InitializeComponent();
            trangthai.Enabled = false;
            trangthai.Visible = false;
            checkBox1.Enabled = false;
            checkBox1.Visible = false;
            maphathanh.Enabled = false;
            label4.Visible = false;
            //maphathanh.MaxLength = 16;
            dataGridView1.AutoSize = false;
            dataGridView1.ClearSelection();
            trangthai.SelectedIndex = 1;
            hieuluctu.Value = DateTime.Today;
            hieuluctu.Enabled = false;
            denngay.Value = DateTime.Today;
            guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
            guna2TextBox6.ForeColor = Color.Gray;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Segoe UI", 8);
        }
        private void LoadData()
        {
            checkDate_database();
            conn.Open();
            string SqlQuery = "SELECT VoucherID, Code, Description, DiscountPercent, ExpiryDate, Quantity, MinOrderValue, IsActive FROM Vouchers";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vouchers");
            DataTable dt = ds.Tables["Vouchers"];
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e) //them
        {

            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgia;
            if (!double.TryParse(menhgia.Text, out mgia))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //SQL section

            string SqlQuery = "INSERT INTO Vouchers VALUES (@Code, @Description, @DiscountAmount, @DiscountPercent, @ExpiryDate, @Quantity, @MinOrderValue, @IsActive)";
            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = maphathanh.Text;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = "PlaceHolder"; //GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.Decimal).Value = 0; //Không còn sử dụng mệnh giá cứng
            cmd.Parameters.Add("@DiscountPercent", SqlDbType.Float).Value = double.Parse(menhgia.Text); //Sử dụng giá trị ô mệnh giá như phần trăm (10 = 10%)
            cmd.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = denngay.Value.Date;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = 0;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@MinOrderValue", SqlDbType.Decimal).Value = 0;//GIÁ TRỊ TẠM DO CHƯA CÓ TEXTBOX, THAY THẾ GIÁ TRỊ NGAY KHI CÓ TEXTBOX
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = Convert.ToBoolean(trangthai.SelectedIndex);
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
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        break;
                    default:
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        throw;
                }
            }

        }
        void Updatea()
        {
            trangthai.SelectedIndex = 1;
            maphathanh.Clear();
            maphathanh.Enabled = false;
            menhgia.Clear();
            hieuluctu.Value = DateTime.Today;
            denngay.Value = DateTime.Now;
            dataGridView1.ClearSelection();
            checkBox1.Checked = false;
            this.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void capnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maphathanh.Text) ||
               string.IsNullOrWhiteSpace(menhgia.Text))


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double mgia;
            if (!double.TryParse(menhgia.Text, out mgia))
            {

                MessageBox.Show(
                    "Mệnh giá phải được nhập dươi dạng một số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (denngay.Value.Date < hieuluctu.Value.Date)
            {
                MessageBox.Show("Ngày hết hạn Voucher phải lớn hơn hoặc bằng ngày Voucher có hiệu lực!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update values in selected row
            //SQL section -> Moved to new form

            //string SqlQuery = "UPDATE VOUCHER SET " +
            //    "MENHGIA = @mg, " +
            //    "NGAYPHATHANH = @ngph, " +
            //    "NGAYKETTHUC = @ngkt, " +
            //    "TINHTRANG = @ttr, " +
            //    "MULTIPLE = @nhieu " +
            //    "WHERE MAPHATHANH = @maph";
            //SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            //cmd.Parameters.Add("@maph", SqlDbType.Char).Value = maphathanh.Text;
            //cmd.Parameters.Add("@mg", SqlDbType.Int).Value = menhgia.Text;
            //cmd.Parameters.Add("@ngph", SqlDbType.Date).Value = hieuluctu.Value.Date;
            //cmd.Parameters.Add("@ngkt", SqlDbType.Date).Value = denngay.Value.Date;
            //cmd.Parameters.Add("@ttr", SqlDbType.NVarChar).Value = trangthai.SelectedItem;
            //cmd.Parameters.Add("@nhieu", SqlDbType.Bit).Value = checkBox1.Checked;
            //try
            //{
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //    LoadData();
            //    Updatea();
            //}
            //catch (SqlException ex)
            //{
            //    switch (ex.Number)
            //    {
            //        case 2627:
            //            MessageBox.Show(
            //                "Mã suất chiếu không được trùng nhau!",
            //                "Lỗi nhập liệu",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Warning);
            //            break;
            //        default:
            //            throw;
            //    }
            //}

        }
        private void PrintToTextBoxes(int row)
        {
            //DataTable dt = dataGridView1.DataSource as DataTable;
            //maphathanh.Text = dt.Rows[row]["MAPHATHANH"].ToString();
            //maphathanh.Enabled = false;
            //DateTime start = (DateTime)dt.Rows[row]["NGAYPHATHANH"];
            //DateTime end = (DateTime)dt.Rows[row]["NGAYKETTHUC"];
            //hieuluctu.Value = start;
            //denngay.Value = end;
            //menhgia.Text = dt.Rows[row]["MENHGIA"].ToString();
            //trangthai.SelectedItem = dt.Rows[row]["TINHTRANG"];
            //checkBox1.Checked = (bool)dt.Rows[row]["MULTIPLE"];
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

                // Lấy ID voucher từ dòng đang click
                DataTable dt = dataGridView1.DataSource as DataTable;
                int voucherID = (int)dt.Rows[e.RowIndex]["VoucherID"];
                if (clickX >= editLeft && clickX < editLeft + iconSize)
                {
                    // 👉 Click icon Edit
                    using (FormSuaVoucher popup = new FormSuaVoucher(voucherID))
                    {
                        //Todo: Lấy dữ liệu từ hàng này trong datagridview để truyền qua formSửa
                        popup.StartPosition = FormStartPosition.CenterParent;
                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData();
                            this.Refresh();
                        }
                    }
                }
                else if (clickX >= deleteLeft && clickX < deleteLeft + iconSize)
                {
                    // 👉 Click icon Delete
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa dòng này?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string temp_id = dt.Rows[voucherID]["VoucherID"].ToString();
                        string SqlQuery = "DELETE FROM Vouchers WHERE VoucherID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        LoadData();
                        this.Refresh();
                    }
                }
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int selected = dr.Index;
                        string temp_id = dt.Rows[selected]["VoucherID"].ToString();
                        string SqlQuery = "DELETE FROM Vouchers WHERE VoucherID = @tempid";
                        SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                        cmd.Parameters.Add("@tempid", SqlDbType.Int).Value = temp_id;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Updatea();
        }

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "Tìm kiếm theo mã voucher")
            {
                guna2TextBox6.Text = "";

                guna2TextBox6.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                guna2TextBox6.Text = "Tìm kiếm theo mã voucher";
                guna2TextBox6.ForeColor = Color.Gray;

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "Tìm kiếm theo mã voucher")
            {
                string tenCanTim = guna2TextBox6.Text.ToLower();
                string tenSV = " ";
                DataTable dt = dataGridView1.DataSource as DataTable;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        tenSV = dt.Rows[index]["Code"].ToString().ToLower();
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                        currencyManager.SuspendBinding();
                        if (tenSV.Contains(tenCanTim))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                        currencyManager.ResumeBinding();
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            Updatea();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Updatea();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void checkDate()
        {
            if (denngay.Value <= hieuluctu.Value)
                denngay.Value = hieuluctu.Value;
            if (denngay.Value < DateTime.Today)
                trangthai.SelectedIndex = 2; //hết hiệu lực
            else if (hieuluctu.Value <= DateTime.Today)
                trangthai.SelectedIndex = 0; //đang áp dụng
            else trangthai.SelectedIndex = 1; //chưa áp dụng
        }
        private void denngay_ValueChanged(object sender, EventArgs e)
        {
            checkDate();
        }

        private void hieuluctu_ValueChanged(object sender, EventArgs e)
        {
            checkDate();
        }

        private void Voucher_Paint(object sender, PaintEventArgs e)
        {
            checkDate();
        }
        private void checkDate_database()//Kiểm tra hạn dùng của các voucher
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FormThemVoucher popup = new FormThemVoucher())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData();
                    this.Refresh();
                }
            }
        }

        private void Voucher_Load(object sender, EventArgs e)
        {
            conn = Helper.getdbConnection();
            LoadData();
            dataGridView1.RowTemplate.Height = 45;
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
