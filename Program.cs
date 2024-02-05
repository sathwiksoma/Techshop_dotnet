using System;
using assignment.Model;
using assignment.Repositories;
using assignment.Services;

namespace assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerService customerService = new CustomerService();
            customerService.CalculateTotalOrders(4);
            customerService.GetCustomerDetails();
            customerService.UpdateCustomerInfo(12,"eww@gmail.com");

            IProductService productService = new ProductService();
            productService.GetProductDetails(1);
            productService.UpdateProductInfo(2);
            productService.IsProductInStock(2);

            IOrderService orderService = new OrderService();
            orderService.CalculateTotalAmount(3);
            orderService.GetOrderDetails();
            orderService.UpdateOrderStatus(3,"shipped");

            IOrderDetailService orderDetailService = new OrderDetailService();
            orderDetailService.GetOrderDetailsById(2);
            orderDetailService.CalculateSubtotal(2);
            orderDetailService.UpdateQuantity(3, 45);
            orderDetailService.AddDiscount(8,19);

            IInventoryService inventoryService = new InventoryService();
            inventoryService.GetProduct(2);
            inventoryService.GetQuantityInStock(3);
            inventoryService.AddToInventory(3,20);
            inventoryService.RemoveFromInventory(3,20);
            inventoryService.UpdateStockQuantity(8,10);
            inventoryService.IsProductAvailable(4,2);
            inventoryService.GetInventoryValue(5);
            inventoryService.ListLowStockProducts(55);
            inventoryService.ListOutOfStockProducts();
            inventoryService.ListAllProducts();
        }
    }
}
