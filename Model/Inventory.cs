using System;
using System.Diagnostics;

namespace assignment.Model
{
    internal class Inventory
    {
        // Attributes
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        // Constructor
        public Inventory(int inventoryId, int productId, int quantityInStock, DateTime lastDateUpdate)
        {
            InventoryId = inventoryId;
            ProductId = productId;
            QuantityInStock = quantityInStock;
            LastStockUpdate = lastDateUpdate;
        }

        public override string ToString()
        {
            return $"InventoryID::{InventoryId}\n ProductId::{ProductId}\n QuantityInStock::{QuantityInStock}\n LastStockUpdate::{LastStockUpdate}";
        }
    }
}
