using System;
using System.Diagnostics;

namespace assignment.Model
{
    internal class Orders
    {
        // Attributes
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }

        // Constructor
        public Orders(int orderId, int customerId, DateTime orderDate, int totalAmount, string status)
        {
            OrderID = orderId;
            CustomerID = customerId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;         
        }

        public Orders()
        {
        }

        public override string ToString()
        {
            return $"OrderID::{OrderID}\n CustomerID::{CustomerID}\n OrderDate::{OrderDate}\n Price::{TotalAmount}\n Status:: {Status}";
        }
    }
}
