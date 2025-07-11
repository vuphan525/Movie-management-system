using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qlyrapchieuphim;

namespace MovieManagementSystem.Tests
{
    [TestClass]
    public class HoadonTests
    {
        [TestMethod]
        public void BillCode_KhiGanGiaTri_PhaiDung()
        {
            // Arrange
            var hoadon = new Hoadon();

            // Act
            hoadon.BillCode = 1001;

            // Assert
            Assert.AreEqual(1001, hoadon.BillCode);
        }

        [TestMethod]
        public void LoyaltyPointsBefore_KhiGanGiaTri_PhaiDung()
        {
            var hoadon = new Hoadon();
            hoadon.LoyaltyPointsBefore = 12;

            Assert.AreEqual(12, hoadon.LoyaltyPointsBefore);
        }

        [TestMethod]
        public void UsedPoints_KhiGanTrue_PhaiDung()
        {
            var hoadon = new Hoadon();
            hoadon.UsedPoints = true;

            Assert.IsTrue(hoadon.UsedPoints);
        }
    }
}
