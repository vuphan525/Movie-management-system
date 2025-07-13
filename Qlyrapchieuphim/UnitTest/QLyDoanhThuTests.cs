using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qlyrapchieuphim;

namespace MovieManagementSystem.Tests
{
    [TestClass]
    public class QlyDoanhThuTests
    {
        [TestMethod]
        public void KhoiTao_QlyDoanhThu_KhongBiNull()
        {
            // Act
            var manHinh = new QlyDoanhThu();

            // Assert
            Assert.IsNotNull(manHinh);
        }

        [TestMethod]
        public void TrangThaiBanDau_CuaBienBool_PhaiDung()
        {
            var manHinh = new QlyDoanhThu();

            // Dùng reflection để kiểm tra biến private
            var startTimeUpdating = typeof(QlyDoanhThu)
                .GetField("_startTimeUpdating", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(manHinh);

            var endTimeUpdating = typeof(QlyDoanhThu)
                .GetField("_endTimeUpdating", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(manHinh);

            var pieTimeUpdating = typeof(QlyDoanhThu)
                .GetField("_pieTimeUpdating", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(manHinh);

            Assert.IsFalse((bool)startTimeUpdating);
            Assert.IsFalse((bool)endTimeUpdating);
            Assert.IsFalse((bool)pieTimeUpdating);
        }
    }
}
