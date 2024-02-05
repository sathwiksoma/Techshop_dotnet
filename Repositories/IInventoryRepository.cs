using assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    internal interface IInventoryRepository
    {
        Products GetProduct(int id);
        int GetQuantityInStock(int id);
        bool AddToInventory(int productID, int quantity);
        bool RemoveFromInventory(int productId, int quantity);
        bool UpdateStockQuantity(int productId, int newQuantity);
        bool IsProductAvailable(int productID, int quantity);
        int GetInventoryValue(int productID);
        List<string> ListLowStockProducts(int threshold);
        List<string> ListOutOfStockProducts();
        List<string> ListAllProducts();

    }
}
