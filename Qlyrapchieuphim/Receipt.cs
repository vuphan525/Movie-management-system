using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlyrapchieuphim
{
    partial class ReceiptTemplate
    {
        private int billCode = 0;
        private decimal totalTickets = 0;
        private decimal totalProducts = 0;
        private decimal totalDiscount = 0;
        private decimal studentDiscount = 0;
        private decimal childrenDiscount = 0;
        private decimal priceAtCheckout = 0;
        private DateTime createdAt = DateTime.MinValue;
        private DateTime startTime = DateTime.MinValue;
        private string title = string.Empty;
        private DataTable billData = new DataTable();
        public ReceiptTemplate()
        { }

        public decimal TotalTickets
        {
            get { return totalTickets; }
            set { totalTickets = value; }
        }
        public string MovieTitle
        {
            get { return title; }
            set { title = value; }
        }
        public int BillCode
        {
            get { return billCode; }
            set { billCode = value; }
        }
        public DataTable BillData
        {
            get { return billData; }
            set { billData = value; }
        }
        public decimal TotalProducts
        {
            get { return totalProducts; }
            set { totalProducts = value; }
        }
        public decimal TotalDiscount
        {
            get { return totalDiscount; }
            set { totalDiscount = value; }
        }
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }
        public decimal StudentDiscount
        {
            get { return studentDiscount; }
            set { studentDiscount = value; }
        }
        public string Title
        { 
            get { return title; }
            set { title = value; }
        }
        public decimal ChildrenDiscount
        {
            get { return childrenDiscount; }
            set { childrenDiscount = value; }
        }
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public decimal PriceAtCheckout
        {
            get { return priceAtCheckout; }
            set { priceAtCheckout = value; }
        }
    }
}
