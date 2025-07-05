using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Media;
using TheArtOfDevHtmlRenderer.Adapters.Entities;

namespace Qlyrapchieuphim
{
    public partial class QlyDoanhThu : UserControl
    {
        public QlyDoanhThu()
        {
            InitializeComponent();
        }
        bool _startTimeUpdating = false;
        bool _endTimeUpdating = false;
        bool _dataAvailableCartesian = false;
        bool _dataAvailablePie = false;
        bool _pieTimeUpdating = false;
        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        private int GetMovieIdFromComboBox()
        {
            if (tenphim.SelectedItem == null)
                return -1;
            if (tenphim.SelectedItem.ToString().IsNullOrEmpty())
                return -1;
            return (int.Parse(Helper.SubStringBetween(tenphim.SelectedItem.ToString(), " (ID: ", ")")));
        }
        private bool LoadMoviesToComboBox()
        {
            int count;
            using (SqlConnection conn = Helper.getdbConnection())
            {
                conn.Open();
                string SqlQuery = "SELECT COUNT(*) FROM Movies WHERE Status = N'Đang chiếu'";
                using (SqlCommand countCmd = new SqlCommand(SqlQuery, conn))
                {
                    count = (int)countCmd.ExecuteScalar();
                    conn.Close();
                }
            }

            if (count > 0)
            {
                tenphim.Enabled = true;
                errorProvider1.Clear();
                string SqlQuery = "SELECT MovieID, Title FROM Movies WHERE Status = N'Đang chiếu'";
                string[] movies = new string[count];
                using (SqlConnection conn = Helper.getdbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                movies[i] = reader.GetString(1) + " (ID: " + reader.GetInt32(0).ToString() + ")";
                                i++;
                            }
                        }
                    }
                }
                tenphim.DataSource = movies;
            }
            else
            {
                tenphim.Enabled = false;
                errorProvider1.SetError(tenphim, "Không có phim trong hệ thống!");
            }
            return count > 0;
        }
        private void QlyDoanhThu_Load(object sender, EventArgs e)
        {
            _startTimeUpdating = true;
            _endTimeUpdating = true;
            _pieTimeUpdating = true;
            dtp_Time_End.Value = DateTime.Today;
            dtp_Time_Start.Value = DateTime.Today;
            dtp_Pie_Chart_Date.Value = DateTime.Today;
            _pieTimeUpdating = false;
            _startTimeUpdating = false;
            _endTimeUpdating = false;
            if (LoadMoviesToComboBox())
                tenphim.SelectedIndex = 0;
            RefreshCharts();

            this.Refresh();
        }
        private void LoadPieChart(int movieId, DateTime date)
        {
            pieChart1.Series = new SeriesCollection();
            //Load doanh thu từ tiền vé
            int seatRevenue = 0;
            DataTable seatsRevenueTable = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT bks.TotalPrice, bks.BookingID, vcs.DiscountPercent, CONVERT(DATE, bks.CreatedAt) AS CreatedAt " +
                    "FROM Bookings bks " +
                    "LEFT JOIN Vouchers vcs ON (vcs.VoucherID = bks.VoucherID) " +
                    "WHERE (CONVERT(DATE, bks.CreatedAt) = @date) " +
                    "ORDER BY CONVERT(DATE, bks.CreatedAt) ASC ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    adapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;
                    conn.Open();
                    adapter.Fill(seatsRevenueTable);
                }
            }
            foreach (DataRow row in seatsRevenueTable.Rows)
            {
                _dataAvailablePie = true;
                double discountPercent = (row["DiscountPercent"] == DBNull.Value) ? 0 : (double)row["DiscountPercent"];
                seatRevenue += Convert.ToInt32(((decimal)row["TotalPrice"]) * Convert.ToDecimal(1 - discountPercent));
            }
            pieChart1.Series.Add(new PieSeries
            {
                Title = "Vé xem phim",
                Values = new ChartValues<int> { seatRevenue },
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 95, 61, 204)) //Purple from theme
            });

            //Load doanh thu sản phẩm
            int productRevenue = 0;
            DataTable productsRevenueTable = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT SUM(bkprs.Quantity * prds.Price) AS ProductRevenue, vcs.DiscountPercent " +
                    "FROM BookingProducts bkprs JOIN Bookings bks ON (bkprs.BookingID = bks.BookingID) " +
                    "JOIN Products prds ON (prds.ProductID = bkprs.ProductID) " +
                    "LEFT JOIN Vouchers vcs ON (vcs.VoucherID = bks.VoucherID) " +
                    "WHERE (CONVERT(DATE, bks.CreatedAt) = @date) " +
                    "GROUP BY bkprs.BookingID, vcs.DiscountPercent ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    adapter.SelectCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;
                    conn.Open();
                    adapter.Fill(productsRevenueTable);
                }
            }
            foreach (DataRow row in productsRevenueTable.Rows)
            {
                double discountPercent = (row["DiscountPercent"] == DBNull.Value) ? 0 : (double)row["DiscountPercent"];
                productRevenue += Convert.ToInt32(((decimal)row["ProductRevenue"]) * Convert.ToDecimal(1 - discountPercent));
            }
            pieChart1.Series.Add(new PieSeries
            {
                Title = "Khác",
                Values = new ChartValues<int> { productRevenue },
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 155, 198, 255)) //Pastel blue
            });
        }
        private void LoadCartesianChart(int movieId, DateTime startTime, DateTime endTime)
        {
            int numOfDays = (endTime.Date - startTime.Date).Duration().Days + 1;
            DateTime[] dateTimes = new DateTime[numOfDays];
            string[] dates = new string[numOfDays];
            int iterator = 0;
            for (DateTime date = startTime; date <= endTime; date = date.AddDays(1))
            {
                dates[iterator] = (date.ToString("dd/MM"));
                dateTimes[iterator] = date.Date;
                iterator++;
            }

            //Load dữ liệu doanh thu
            int[] seatRevenues = new int[numOfDays];
            Helper.Populate<int>(seatRevenues, 0);
            DataTable seatsRevenueTable = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT bks.TotalPrice, bks.BookingID, vcs.DiscountPercent, CONVERT(DATE, bks.CreatedAt) AS CreatedAt " +
                    "FROM Bookings bks " +
                    "LEFT JOIN Vouchers vcs ON (vcs.VoucherID = bks.VoucherID) " +
                    "WHERE (CONVERT(DATE, bks.CreatedAt) BETWEEN @start AND @end) " +
                    "ORDER BY CONVERT(DATE, bks.CreatedAt) ASC ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    adapter.SelectCommand.Parameters.Add("@start", SqlDbType.DateTime).Value = startTime.Date;
                    adapter.SelectCommand.Parameters.Add("@end", SqlDbType.DateTime).Value = endTime.Date;
                    conn.Open();
                    adapter.Fill(seatsRevenueTable);
                }
            }
            foreach (DataRow row in seatsRevenueTable.Rows)
            {
                int dateIndex = 0;
                foreach (DateTime date in dateTimes)
                {
                    DateTime createdAt = (DateTime)row["CreatedAt"];
                    if (date == createdAt.Date)
                        break;
                    dateIndex++;
                }
                if (dateIndex == dateTimes.Length)
                    continue;
                double discountPercent = (row["DiscountPercent"] == DBNull.Value) ? 0 : (double)row["DiscountPercent"];
                seatRevenues[dateIndex] += Convert.ToInt32(((decimal)row["TotalPrice"]) * Convert.ToDecimal(1 - discountPercent));
                _dataAvailableCartesian = true;
            }

            int[] productRevenues = new int[numOfDays];
            Helper.Populate<int>(productRevenues, 0);
            DataTable productsRevenueTable = new DataTable();
            using (SqlConnection conn = Helper.getdbConnection())
            {
                string SqlQuery = "SELECT SUM(bkprs.Quantity * prds.Price) AS ProductRevenue, CONVERT(DATE, bks.CreatedAt) AS CreatedAt, vcs.DiscountPercent " +
                    "FROM BookingProducts bkprs JOIN Bookings bks ON (bkprs.BookingID = bks.BookingID) " +
                    "JOIN Products prds ON (prds.ProductID = bkprs.ProductID) " +
                    "LEFT JOIN Vouchers vcs ON (vcs.VoucherID = bks.VoucherID) " +
                    "WHERE (CONVERT(DATE, bks.CreatedAt) BETWEEN @start AND @end) " +
                    "GROUP BY bkprs.BookingID, CONVERT(DATE, bks.CreatedAt), vcs.DiscountPercent " +
                    "ORDER BY CONVERT(DATE, bks.CreatedAt) ASC ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, conn))
                {
                    adapter.SelectCommand.Parameters.Add("@start", SqlDbType.DateTime).Value = startTime.Date;
                    adapter.SelectCommand.Parameters.Add("@end", SqlDbType.DateTime).Value = endTime.Date;
                    conn.Open();
                    adapter.Fill(productsRevenueTable);
                }
            }

            foreach (DataRow row in productsRevenueTable.Rows)
            {
                int dateIndex = 0;
                foreach (DateTime date in dateTimes)
                {
                    if (date == (DateTime)row["CreatedAt"])
                        break;
                    dateIndex++;
                }
                if (dateIndex == dateTimes.Length)
                    continue;
                double discountPercent = (row["DiscountPercent"] == DBNull.Value) ? 0 : (double)row["DiscountPercent"];
                productRevenues[dateIndex] += Convert.ToInt32(((decimal)row["ProductRevenue"]) * Convert.ToDecimal(1 - discountPercent));
            }

            int[] revenueByDates = new int[numOfDays];
            Helper.Populate<int>(revenueByDates, -10);
            for (int i = 0; i < numOfDays; i++)
                revenueByDates[i] = seatRevenues[i] + productRevenues[i];

            //Tạo đường theo dữ liệu đã thu
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries()
                {
                    Title = "Doanh thu",
                    Values = revenueByDates.AsChartValues()
                }
            };

            //Tạo trục ngày AxisX

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = dates,
            });

            //Tạo trục Doanh thu AxisY
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Doanh thu",
                LabelFormatter = value => value.ToString("N0") + " đ",
                MinValue = 0,
            });
        }
        private void RefreshCharts()
        {
            //Make Cartesian look slightly better without data
            if (!_dataAvailableCartesian)
            {
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Ngày",
                    Labels = new string[] { dtp_Time_End.Value.Date.ToString("dd/MM") },
                });

                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Doanh thu",
                    LabelFormatter = value => value.ToString("N0") + " đ",
                    MinValue = 0,
                });
            }

            //Make Pie look slightly better without data
            if (!_dataAvailablePie)
            {
                pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Không dữ liệu",
                    Values = new ChartValues<double> { 100 },
                    DataLabels = true,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 155, 198, 255)) //Pastel blue
                }
            };
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tenphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            int movieId = GetMovieIdFromComboBox();
            if (movieId != -1)
            {
                LoadCartesianChart(movieId, dtp_Time_Start.Value.Date, dtp_Time_End.Value.Date);
                LoadPieChart(movieId, dtp_Pie_Chart_Date.Value.Date);
            }
        }

        private void dtp_Time_End_ValueChanged(object sender, EventArgs e)
        {
            if (_endTimeUpdating) return;
            //Kiểm tra ngày bắt đầu trước ngày kết thúc
            if (dtp_Time_Start.Value.Date > dtp_Time_End.Value.Date)
                dtp_Time_End.Value = dtp_Time_Start.Value.Date;

            //Kiểm tra giới hạn 10 ngày
            if ((dtp_Time_Start.Value.Date - dtp_Time_End.Value.Date).Duration().Days + 1 > 10)
                dtp_Time_End.Value = dtp_Time_Start.Value.Date.AddDays(9);
            int movieId = GetMovieIdFromComboBox();
            if (movieId != -1)
                LoadCartesianChart(movieId, dtp_Time_Start.Value.Date, dtp_Time_End.Value.Date);
            //else
            //    _dataAvailableCartesian = false;
            //RefreshCharts();
            this.Refresh();
        }

        private void dtp_Time_Start_ValueChanged(object sender, EventArgs e)
        {
            if (_startTimeUpdating) return;
            //Kiểm tra ngày bắt đầu trước ngày kết thúc
            if (dtp_Time_Start.Value.Date > dtp_Time_End.Value.Date)
                dtp_Time_Start.Value = dtp_Time_End.Value.Date;

            //Kiểm tra giới hạn 10 ngày
            if ((dtp_Time_Start.Value.Date - dtp_Time_End.Value.Date).Duration().Days + 1 > 10)
                dtp_Time_Start.Value = dtp_Time_End.Value.Date.AddDays(-9);
            int movieId = GetMovieIdFromComboBox();
            if (movieId != -1)
                LoadCartesianChart(movieId, dtp_Time_Start.Value.Date, dtp_Time_End.Value.Date);
            //else
            //    _dataAvailableCartesian = false;
            //RefreshCharts();
            this.Refresh();
        }

        private void QlyDoanhThu_Enter(object sender, EventArgs e)
        {
            if (LoadMoviesToComboBox())
                tenphim.SelectedIndex = 0;
        }

        private void dtp_Pie_Chart_Date_ValueChanged(object sender, EventArgs e)
        {
            if (_pieTimeUpdating) return;
            int movieId = GetMovieIdFromComboBox();
            if (movieId != -1)
                LoadPieChart(movieId, dtp_Pie_Chart_Date.Value.Date);
            //else
            //    _dataAvailablePie = false;
            this.Refresh();
        }
    }
}
