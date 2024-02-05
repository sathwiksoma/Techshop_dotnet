using System;

namespace assignment.Model
{
    internal class Products
    {
        // Attributes
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public Products(int productId, string productName, string description, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Price = price;
        }
        public Products() { }
       
        public override string ToString()
        {
            return $"ProductID::{ProductId}\n ProductName::{ProductName}\n Description::{Description}\n Price::{Price}";
        }
    }
}
