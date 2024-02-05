using System;
using System.Diagnostics;

namespace assignment.Model
{
    internal class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }   

        // Constructor
        public OrderDetails(int orderDetailId, int orderId, int productId, int quantity, decimal totalAmount)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;          
            TotalAmount = totalAmount;
        }

        public OrderDetails()
        {
        }

        public override string ToString()
        {
            return $"OrderDetailId::{OrderDetailId}\n OrderId::{OrderId}\n ProductId::{ProductId}\n Quantity::{Quantity}\n TotalAmount :: {TotalAmount}";
        }
    }
}
