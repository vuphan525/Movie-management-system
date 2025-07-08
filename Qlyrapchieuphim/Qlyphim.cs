using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using Qlyrapchieuphim.FormEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Qlyrapchieuphim
{
    public partial class Qlyphim : UserControl
    {

        public Qlyphim()
        {
            InitializeComponent();
            //idphim.MaxLength = 4;
            tenphim.MaxLength = 100;
            dataGridView1.ReadOnly = true;

            label2.Visible = false;
            idphim.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Segoe UI", 12);
        }
        string poster_url = string.Empty;
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory; // Thư mục dự án
        private void LoadData()
        {
            string SqlQuery = "select MovieID, Title, Description, Duration, PosterURL, Genre, Status, ReleaseDate, ImportDate, Manufacturer from Movies";
            using (SqlConnection conn = Helper.getdbConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
            {
                DataSet ds = new DataSet();
                conn.Open();
                adapter.Fill(ds, "Movies");
                DataTable dt = ds.Tables["Movies"];
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
                dataGridView1.ClearSelection();
            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        {


        }
        void Reset()
        {
            idphim.Clear();
            //idphim.Enabled = true;
            tenphim.Clear();
            theloai.SelectedIndex = 0;
            thoiluong.Clear();
            trangthai.SelectedIndex = 1;
            mota.Clear();
            dataGridView1.ClearSelection();

            poster_url = string.Empty;
            this.Refresh();
        }

        private void Qlyphim_Load(object sender, EventArgs e)
        {
            theloai.SelectedIndex = 0;
            trangthai.SelectedIndex = 1;
            dataGridView1.AutoSize = false;
            SearchTextBox.Text = "Tìm kiếm theo tên";
            SearchTextBox.ForeColor = Color.Gray;
            LoadData();
            dataGridView1.ClearSelection();
            dataGridView1.RowTemplate.Height = 45;
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {


        }
        private void PrintToTextBoxes(int row)
        {
            // Lấy thông tin của dòng được chọn
            DataTable dt = dataGridView1.DataSource as DataTable;

            // Gán giá trị cho các TextBox
            idphim.Text = dt.Rows[row]["MovieID"].ToString();
            idphim.Enabled = false;
            tenphim.Text = dt.Rows[row]["Title"].ToString();
            theloai.SelectedItem = dt.Rows[row]["Genre"].ToString();
            thoiluong.Text = dt.Rows[row]["Duration"].ToString();
            trangthai.SelectedItem = dt.Rows[row]["Status"].ToString();
            mota.Text = dt.Rows[row]["Description"].ToString();
            string relative_poster_path = dt.Rows[row]["PosterURL"].ToString();
            poster_url = Path.Combine(projectFolder, relative_poster_path);
            try
            {
                using (FileStream stream = new FileStream(poster_url, FileMode.Open))
                {

                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(relative_poster_path))
                {
                    switch (ex.GetType().ToString())
                    {
                        case "FileNotFoundException":
                            MessageBox.Show(
                            "Không tìm thấy file ảnh với đường dẫn tương ứng.",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                        case "DirectoryNotFoundException":
                            MessageBox.Show(
                            "Không tìm thấy thư mục với đường dẫn tương ứng.",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show(
                            "Lỗi dữ liệu!",
                            "Lỗi dữ liệu!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {

                }
            }
            check = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Actions")
            {
                // Tính vị trí click trong ô
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dataGridView1.PointToClient(Cursor.Position).X - cellRect.X;

                int iconSize = 32;
                int padding = 8;
                int editLeft = padding;
                int deleteLeft = editLeft + iconSize + padding;

                // Lấy ID phim từ dòng đang click
                DataTable dt = dataGridView1.DataSource as DataTable;
                string movieId = dt.Rows[e.RowIndex]["MovieID"].ToString();

                if (clickX >= editLeft && clickX < editLeft + iconSize)
                {
                    // 👉 Click icon Edit
                    using (FormSuaPhim popup = new FormSuaPhim(movieId)) // truyền ID vào constructor
                    {
                        //Todo: Lấy dữ liệu từ hàng này trong datagridview để truyền qua formSửa
                        popup.StartPosition = FormStartPosition.CenterParent;
                        ;
                        if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            LoadData(); // Chỉ gọi nếu form kia trả về OK
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
                        using (SqlConnection conn = Helper.getdbConnection())
                        {
                            string SqlQuery = "DELETE FROM Movies WHERE MovieID = @tempid";
                            using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                            {
                                cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = movieId;
                                conn.Open();
                                try
                                { cmd.ExecuteNonQuery(); }
                                catch (Exception ex)
                                {
                                    if (ex is SqlException)
                                    {
                                        SqlException sqlex = (SqlException)ex;
                                        if (sqlex.Number == 547)
                                        {
                                            MessageBox.Show(
                                                "Không thể xóa phim, đã có khách hàng đặt vé phim này.",
                                                "Không thể xóa",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                        }
                                        else
                                            MessageBox.Show("Lỗi khi xóa: " + sqlex.Message + "\nSQL Exception number: " + sqlex.Number, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                        MessageBox.Show("Lỗi khi xóa phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // Xóa file ảnh nếu có
                            string fullPath = Path.Combine(projectFolder, "posters", movieId + ".png");
                            if (File.Exists(fullPath))
                                File.Delete(fullPath);

                            conn.Close();
                        }
                        LoadData();
                        Reset();
                    }
                }
            }
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {

            //if (dataGridView1.SelectedRows.Count > 0)
            //{

            //    DialogResult result = MessageBox.Show(
            //        "Bạn có chắc chắn muốn xóa dòng này?",
            //        "Xác nhận",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question);

            //    if (result == DialogResult.Yes)
            //    {
            //        DataTable dt = dataGridView1.DataSource as DataTable;
            //        if (conn.State != ConnectionState.Open)
            //            conn.Open();
            //        foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            //        {
            //            int selected = dr.Index;
            //            string temp_id = dt.Rows[selected]["MovieID"].ToString();
            //            string SqlQuery = "DELETE FROM Movies WHERE MovieID = @tempid";
            //            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
            //            cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = temp_id;
            //            cmd.ExecuteNonQuery();

            //            string fullPath = Path.Combine(projectFolder, "posters", temp_id + ".png");
            //            if (File.Exists(fullPath))
            //                File.Delete(fullPath);
            //        }
            //        conn.Close();
            //        LoadData();
            //        Reset();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Tìm kiếm theo tên")
            {
                SearchTextBox.Text = "";

                SearchTextBox.ForeColor = Color.Black;
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Tìm kiếm theo tên";
                SearchTextBox.ForeColor = Color.Gray;

            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text != "Tìm kiếm theo tên")
            {
                string tenCanTim = SearchTextBox.Text.ToLower();
                string tenSV = " ";
                DataTable dt = dataGridView1.DataSource as DataTable;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = row.Index;
                        tenSV = dt.Rows[index]["Title"].ToString().ToLower();
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

        public bool check = false;
        private void Qlyphim_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Reset();
                }
                check = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {
                if (!dataGridView1.Bounds.Contains(e.Location))
                {
                    dataGridView1.ClearSelection();
                    Reset();
                }
            }
            check = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (check)
            {

                dataGridView1.ClearSelection();
                Reset();
                check = false;

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }


        private void AddPosterButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (FormThemPhim popup = new FormThemPhim())
            {
                popup.StartPosition = FormStartPosition.CenterParent;

                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData(); // Chỉ gọi nếu form kia trả về OK
                }
            }

        }
        private void UpdateReleaseStates()
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
