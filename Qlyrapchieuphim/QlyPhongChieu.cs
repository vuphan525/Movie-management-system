using Qlyrapchieuphim.FormEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;


namespace Qlyrapchieuphim
{
    public partial class QlyPhongChieu : UserControl
    {
        public QlyPhongChieu()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Font = new Font("Segoe UI", 12);
        }
        private void LoadData()
        {
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT RoomID, RoomName, SeatCount, RoomType FROM Rooms";
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    DataSet ds = new DataSet();
                    conn.Open();
                    adapter.Fill(ds, "Rooms");
                    DataTable dt = ds.Tables["Rooms"];
                    dataGridView1.DataSource = dt;
                    if (!dataGridView1.Columns.Contains("Actions"))
                    {
                        DataGridViewTextBoxColumn actionCol = new DataGridViewTextBoxColumn();
                        actionCol.Name = "Actions";
                        actionCol.HeaderText = "Actions";
                        actionCol.Width = 60;
                        dataGridView1.Columns.Add(actionCol);
                    }
                }
            }
            dataGridView1.Columns["Actions"].DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (FormThemPhongChieu popup = new FormThemPhongChieu())
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                if (popup.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadData();
                }
            }

        }

        private void QlyPhongChieu_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 45;
            LoadData();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Actions" && e.RowIndex >= 0)
            {
                // Tính vị trí click so với ô
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dataGridView1.PointToClient(Cursor.Position).X - cellRect.X;

                int iconSize = 32;
                int padding = 8;
                int editLeft = padding;
                int deleteLeft = editLeft + iconSize + padding;

                // Lấy ID phòng từ dòng đang click
                DataTable dt = dataGridView1.DataSource as DataTable;
                string roomId = dt.Rows[e.RowIndex]["RoomID"].ToString();

                if (clickX >= editLeft && clickX < editLeft + iconSize)
                {
                    // 👉 Click icon Edit
                    using (FormSuaPhongChieu popup = new FormSuaPhongChieu(roomId))
                    {
                        //Todo: Lấy dữ liệu từ hàng này trong datagridview để truyền qua formSửa
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
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa dòng này?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conn = Helper.getdbConnection())
                        {
                            conn.Open();
                            //Xoá các ghế trong phòng
                            string SqlQuery = "DELETE FROM Seats WHERE RoomID = @tempid";
                            SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                            cmd.Parameters.Add("@tempid", SqlDbType.Char).Value = roomId;
                            cmd.ExecuteNonQuery();
                            //Xoá phòng
                            SqlQuery = "DELETE FROM Rooms WHERE RoomID = @tempid";
                            cmd.CommandText = SqlQuery;
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
                                            "Không thể xóa phòng chiếu, đã có khách hàng đặt vé phòng chiếu này.",
                                            "Không thể xóa",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show("Lỗi khi xóa: " + sqlex.Message + "\nSQL Exception number: " + sqlex.Number, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                    MessageBox.Show("Lỗi khi xóa phòng chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadData();
                            this.Refresh();
                        }
                    }
                }
            }
        }
    }
}
