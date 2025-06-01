using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    public partial class QlyDoanhThu : UserControl
    {
        public QlyDoanhThu()
        {
            InitializeComponent();
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void QlyDoanhThu_Load(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Doanh thu",
            Values = new ChartValues<double> { 250, 190, 200, 180, 270, 150, 240 }
        }
    };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = new[] { "02/10", "03/10", "04/10", "05/10", "06/10", "07/10", "08/10" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Doanh thu",
                LabelFormatter = value => value.ToString("N0") + " đ"
            });

            pieChart1.Series = new SeriesCollection
{
    new PieSeries
    {
        Title = "Phim",
        Values = new ChartValues<double> { 150 },
        DataLabels = true
    },
    new PieSeries
    {
        Title = "Khác",
        Values = new ChartValues<double> { 500 },
        DataLabels = true
    }
};

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
