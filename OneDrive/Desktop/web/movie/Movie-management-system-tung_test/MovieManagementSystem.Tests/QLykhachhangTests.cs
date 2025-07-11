using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qlyrapchieuphim;
using System;
using System.Data;

namespace MovieManagementSystem.Tests
{
    [TestClass]
    public class ReceiptTemplateTests
    {
        [TestMethod]
        public void TaoMoi_ReceiptTemplate_KhongNull()
        {
            var receipt = new ReceiptTemplate();
            Assert.IsNotNull(receipt);
        }

        [TestMethod]
        public void GanGiaTri_ThuocTinh_PhaiLayLaiDungGiaTri()
        {
            var receipt = new ReceiptTemplate();

            receipt.BillCode = 123;
            receipt.TotalTickets = 45000;
            receipt.TotalProducts = 20000;
            receipt.TotalDiscount = 5000;
            receipt.StudentDiscount = 15000;
            receipt.ChildrenDiscount = 10000;
            receipt.CreatedAt = new DateTime(2024, 1, 1);
            receipt.StartTime = new DateTime(2024, 1, 2);
            receipt.MovieTitle = "Phim hanh dong";

            Assert.AreEqual(123, receipt.BillCode);
            Assert.AreEqual(45000, receipt.TotalTickets);
            Assert.AreEqual(20000, receipt.TotalProducts);
            Assert.AreEqual(5000, receipt.TotalDiscount);
            Assert.AreEqual(15000, receipt.StudentDiscount);
            Assert.AreEqual(10000, receipt.ChildrenDiscount);
            Assert.AreEqual(new DateTime(2024, 1, 1), receipt.CreatedAt);
            Assert.AreEqual(new DateTime(2024, 1, 2), receipt.StartTime);
            Assert.AreEqual("Phim hanh dong", receipt.MovieTitle);
        }

        [TestMethod]
        public void GanBillData_PhaiLayLaiDungDataTable()
        {
            var receipt = new ReceiptTemplate();
            var dt = new DataTable();
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Quantity");

            var row = dt.NewRow();
            row["ProductName"] = "Coke";
            row["Quantity"] = "2";
            dt.Rows.Add(row);

            receipt.BillData = dt;

            Assert.AreEqual(1, receipt.BillData.Rows.Count);
            Assert.AreEqual("Coke", receipt.BillData.Rows[0]["ProductName"]);
        }
    }
}