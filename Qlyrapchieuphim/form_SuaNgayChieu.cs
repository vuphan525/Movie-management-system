using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlyrapchieuphim
{
    public partial class form_SuaNgayChieu : Form
    {
        private DateTime selectedTime;
        public DateTime KetQuaThoiGian { get; private set; }
        private List<DateTime> danhSachNgayDaCo;

        public form_SuaNgayChieu(DateTime d, List<DateTime> danhSachNgayKhac)
        {
            InitializeComponent();

            // Thiết lập culture cho đúng định dạng dd/MM/yyyy
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            this.selectedTime = d;
            this.danhSachNgayDaCo = danhSachNgayKhac;
        }

        private void sua_Click(object sender, EventArgs e)
        {
            KetQuaThoiGian = date_FormNgaySuatChieu_NgayChieu.Value;

            // Chỉ cho phép chọn ngày từ hôm nay trở đi
            if (KetQuaThoiGian < DateTime.Today)
            {
                MessageBox.Show("Chỉ được chọn ngày chiếu từ hôm nay trở đi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng với các ngày khác
            if (danhSachNgayDaCo.Contains(KetQuaThoiGian))
            {
                MessageBox.Show("Ngày chiếu này đã tồn tại. Vui lòng chọn ngày khác.", "Trùng ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;  // Quan trọng để form.ShowDialog() nhận OK
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            form_SuaNgayChieu_Load(sender, e);
        }

        private void form_SuaNgayChieu_Load(object sender, EventArgs e)
        {
            date_FormNgaySuatChieu_NgayChieu.Format = DateTimePickerFormat.Custom;
            date_FormNgaySuatChieu_NgayChieu.CustomFormat = "dd/MM/yyyy";
            date_FormNgaySuatChieu_NgayChieu.Value = selectedTime;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
