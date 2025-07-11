using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Qlyrapchieuphim;

namespace MovieManagementSystem.Tests
{
    [TestClass]
    public class BansanphamTests
    {
        [TestMethod]
        public void DanhSachSanPham_PhaiCo4CotKhiTao()
        {
            // Arrange
            var form = new Bansanpham();
            DataTable bangSanPham = form.List;

            // Assert
            Assert.IsNotNull(bangSanPham);
            Assert.AreEqual(4, bangSanPham.Columns.Count);
            Assert.AreEqual("id", bangSanPham.Columns[0].ColumnName);
            Assert.AreEqual("num", bangSanPham.Columns[1].ColumnName);
            Assert.AreEqual("name", bangSanPham.Columns[2].ColumnName);
            Assert.AreEqual("price", bangSanPham.Columns[3].ColumnName);
        }

        [TestMethod]
        public void TongTien_BanDauPhaiBang0()
        {
            // Arrange
            var form = new Bansanpham();

            // Act
            int tongTien = form.Total;

            // Assert
            Assert.AreEqual(0, tongTien);
        }
    }
}
