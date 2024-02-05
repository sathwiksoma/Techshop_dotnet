using assignment.Model;
using assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Services
{
    internal class InventoryService : IInventoryService
    {
        readonly IInventoryRepository _inventoryRepository;

        public InventoryService()
        {
            _inventoryRepository = new InventoryRepository();
        }

        public void GetProduct(int id)
        {
            Products product = _inventoryRepository.GetProduct(id);
            if (product == null)
            {
                Console.WriteLine("Product id you entered is INVALID");
            }
            else
            {
                Console.WriteLine(product);
            }

        }

        public void GetQuantityInStock(int id)
        {
            int quantity = _inventoryRepository.GetQuantityInStock(id);
            if (quantity == 0)
            {
                Console.WriteLine(" No Stock Available in entered Id ");
            }
            else
            {
                Console.WriteLine(quantity);
            }
        }

        public void AddToInventory(int productID, int quantity)
        {
            if (_inventoryRepository.AddToInventory(productID, quantity))
            {
                Console.WriteLine("Quantity Added Successfully");
            }
            else 
            {
                Console.WriteLine(" NOT ADDED ");
            }
        }

        public void RemoveFromInventory(int productId, int quantity)
        {
            if (_inventoryRepository.RemoveFromInventory(productId, quantity))
            {
                Console.WriteLine("Quantity Removed Successfully");
            }
            else
            {
                Console.WriteLine(" NOT REMOVED ");
            }
        }

        public void UpdateStockQuantity(int productId, int newQuantity)
        {
            if (_inventoryRepository.UpdateStockQuantity(productId, newQuantity))
            {
                Console.WriteLine(" Quantity Updated Successfully ");
            }
            else
            {
                Console.WriteLine("Invalid Data");
            }
        }

        public void IsProductAvailable(int productID, int quantity)
        {
            if (_inventoryRepository.IsProductAvailable(productID, quantity))
            {
                Console.WriteLine($"The product {productID} and the quantity {quantity} is available.");
            }
            else
            {
                Console.WriteLine($"The product {productID} is not availabe as per selected quantity {quantity}");
            }
        }

        public void GetInventoryValue(int productID)
        {
            decimal value = _inventoryRepository.GetInventoryValue(productID);
            if (value > 0)
            {
                Console.WriteLine($"The Total Value of the entered product {productID} is {value}.");
            }
            else
            {
                Console.WriteLine("Invalid productID or Stock Unavailable");
            }
        }
                        

        public void ListLowStockProducts(int threshold)
        {
            List<string> result = _inventoryRepository.ListLowStockProducts(threshold);
            if (result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine($" NO Products Available under given {threshold} value");
            }
        }

        public void ListOutOfStockProducts()
        {
            List<string> result = _inventoryRepository.ListOutOfStockProducts();
            if (result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine(" No Stock Available ");
            }
        }

        public void ListAllProducts()
        {
            List<string> result = _inventoryRepository.ListAllProducts();
            if (result != null && result.Count > 0)
            {
                foreach (string product in result)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine(" Invalid Data ");
            }

        }

    }
}
