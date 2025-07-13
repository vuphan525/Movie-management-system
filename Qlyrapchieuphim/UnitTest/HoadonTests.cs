using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qlyrapchieuphim;
using System.Reflection;

namespace MovieManagementSystem.Tests
{
    [TestClass]
    public class HoadonTests
    {
        [TestMethod]
        public void GetTienCanTra_PhaiTinhDung()
        {
            var hoadon = new Hoadon();

            // Gán các giá trị nội bộ bằng Reflection
            SetPrivateField(hoadon, "total", 100000);              // Tiền vé
            SetPrivateField(hoadon, "food_total", 30000);          // Đồ ăn
            SetPrivateField(hoadon, "drinks_total", 20000);        // Nước uống
            SetPrivateField(hoadon, "discount", 10000);            // Giảm giá voucher
            SetPrivateField(hoadon, "student_discount", 5000);     // Giảm giá sinh viên
            SetPrivateField(hoadon, "child_discount", 5000);       // Giảm giá trẻ em

            // Act
            int tongTien = hoadon.GetTienCanTra();

            // Assert
            Assert.AreEqual(130000, tongTien); // 100k + 30k + 20k - 10k - 5k - 5k = 130k
        }

        private void SetPrivateField(object obj, string fieldName, object value)
        {
            var field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, value);
        }


        [TestMethod]
        public void GetTienCanTra_KhongCoPhuPhiVaGiamGia()
        {
            var hoadon = new Hoadon();

            SetPrivateField(hoadon, "total", 100000);
            SetPrivateField(hoadon, "food_total", 0);
            SetPrivateField(hoadon, "drinks_total", 0);
            SetPrivateField(hoadon, "discount", 0);
            SetPrivateField(hoadon, "student_discount", 0);
            SetPrivateField(hoadon, "child_discount", 0);

            int tongTien = hoadon.GetTienCanTra();

            Assert.AreEqual(100000, tongTien);
        }

        [TestMethod]
        public void GetTienCanTra_GiamGiaTuVoucher()
        {
            var hoadon = new Hoadon();

            SetPrivateField(hoadon, "total", 100000);
            SetPrivateField(hoadon, "food_total", 0);
            SetPrivateField(hoadon, "drinks_total", 0);
            SetPrivateField(hoadon, "discount", 20000); // Voucher giảm 20k
            SetPrivateField(hoadon, "student_discount", 0);
            SetPrivateField(hoadon, "child_discount", 0);

            int tongTien = hoadon.GetTienCanTra();

            Assert.AreEqual(80000, tongTien);
        }

        [TestMethod]
        public void GetTienCanTra_GiamGiaBangTongTien()
        {
            var hoadon = new Hoadon();

            SetPrivateField(hoadon, "total", 50000);
            SetPrivateField(hoadon, "food_total", 20000);
            SetPrivateField(hoadon, "drinks_total", 10000);
            SetPrivateField(hoadon, "discount", 40000);
            SetPrivateField(hoadon, "student_discount", 20000);
            SetPrivateField(hoadon, "child_discount", 20000);

            int tongTien = hoadon.GetTienCanTra();

            Assert.AreEqual(0, tongTien); // Không được âm tiền phải trả
        }

        [TestMethod]
        public void GetTienCanTra_GiamGiaVuotTongTien()
        {
            var hoadon = new Hoadon();

            SetPrivateField(hoadon, "total", 100000);
            SetPrivateField(hoadon, "food_total", 0);
            SetPrivateField(hoadon, "drinks_total", 0);
            SetPrivateField(hoadon, "discount", 120000); // Giảm nhiều hơn tổng

            int tongTien = hoadon.GetTienCanTra();

            Assert.AreEqual(-20000, tongTien); // Kết quả âm
        }

    }
}
