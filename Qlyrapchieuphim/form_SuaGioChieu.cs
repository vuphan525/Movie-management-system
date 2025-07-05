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
    public partial class form_SuaGioChieu : Form
    {
        private DateTime selectedTime;
        public DateTime KetQuaThoiGian { get; private set; }
        private List<DateTime> danhSachGioDaCo;
        private int duration = 0;

        public form_SuaGioChieu(DateTime d, List<DateTime> danhSachGioKhac, int duration)
        {
            InitializeComponent();
            this.selectedTime = d;
            this.danhSachGioDaCo = danhSachGioKhac;
            this.duration = duration;
        }

        private void sua_Click(object sender, EventArgs e)
        {
            DateTime selectedTime = date_FormThemSuatChieu_GioChieu.Value;
            DateTime start = selectedTime.Date.AddHours(9);
            DateTime end = selectedTime.Date.AddHours(23);

            if (selectedTime < DateTime.Now.AddMinutes(30))
            {
                MessageBox.Show("Giờ chiếu chỉ được thêm sau 30 phút kể từ hiện tại.", "Thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ❌ Trùng giờ
            if (danhSachGioDaCo.Any(gio => gio.Hour == selectedTime.Hour && gio.Minute == selectedTime.Minute))
            {
                MessageBox.Show("Giờ chiếu đã tồn tại!", "Trùng giờ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ❌ Quá gần các giờ chiếu khác (ít hơn 30 phút + duration)
            foreach (DateTime gio in danhSachGioDaCo)
            {
                double khoangCach = Math.Abs((selectedTime - gio).TotalMinutes);
                if (khoangCach < (30 + duration))
                {
                    MessageBox.Show($"Giờ chiếu phải cách các suất khác ít nhất {30 + duration} phút!", "Thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // ✅ Thời gian hợp lệ
            if (selectedTime >= start && selectedTime <= end)
            {
                KetQuaThoiGian = selectedTime;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giờ chiếu từ 9:00 sáng đến 11:00 tối.", "Thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            form_SuaGioChieu_Load(sender, e);
        }

        private void date_FormThemSuatChieu_NgayChieu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_SuaGioChieu_Load(object sender, EventArgs e)
        {
            date_FormThemSuatChieu_GioChieu.ShowUpDown = true;
            date_FormThemSuatChieu_GioChieu.Format = DateTimePickerFormat.Custom;
            date_FormThemSuatChieu_GioChieu.CustomFormat = "hh:mm tt";
            date_FormThemSuatChieu_GioChieu.Value = selectedTime;
        }
    }
}
