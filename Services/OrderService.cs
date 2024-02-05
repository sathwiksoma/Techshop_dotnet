using assignment.Model;
using assignment.Repositories;
using assignment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment.Repository;

namespace assignment.Services
{
    internal class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public void CalculateTotalAmount(int id)
        {
            int totalAmount = _orderRepository.CalculateTotalAmount(id);
            if (totalAmount > 0)
            {
                Console.WriteLine($"The Total Amount is {totalAmount}");
            }
            else
            {
                throw new Exceptions.InvalidDataException("Invalid Id entered");
            }
            
        }

        public void GetOrderDetails()
        {
            List<Orders> orders = _orderRepository.GetOrderDetails();
            foreach (Orders order in orders)
            {
                Console.WriteLine(order);
            }
        }

        public void UpdateOrderStatus(int id, string status)
        {
            bool updated = _orderRepository.UpdateOrderStatus(id, status);
            if (updated)
            {
                Console.WriteLine("Successfully Updated");
                Console.WriteLine("Order status is 'shipped' ");
            }
            else 
            { 
                throw new Exceptions.InvalidDataException(status);
            }
        }

               

    }
}
