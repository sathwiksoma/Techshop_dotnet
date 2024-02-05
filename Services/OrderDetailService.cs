using assignment.Exceptions;
using assignment.Model;
using assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Services
{
    internal class OrderDetailService : IOrderDetailService
    {
        readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailService()
        {
            _orderDetailsRepository = new OrderDetailsRepository();
        }

        public void CalculateSubtotal(int id)
        {
            decimal total = _orderDetailsRepository.CalculateSubtotal(id);
            if (total > 0)
            {
                Console.WriteLine($"The sub-total amount id: {id} is {total}");
            }
            else
            {
                throw new Exceptions.InvalidInputException("Invalid input Id entered");
            }
        }

        public void GetOrderDetailsById(int id)
        {
            OrderDetails details = _orderDetailsRepository.GetOrderDetailsById(id);
            if (details != null)
            {
                Console.WriteLine(details);
            }
            else
            {
                throw new Exceptions.IncompleteOrderException("Invalid Order Id entered");
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            if (_orderDetailsRepository.UpdateQuantity(id, quantity))
            {
                Console.WriteLine($"Orderdetail id : {id} has Updated its Quantity to {quantity} ");
            }
            else
            {
                throw new Exceptions.InvalidInputException(" Given Input Id wrong ");
            }
        }

        public void AddDiscount(int id, int discount)
        {
            if (_orderDetailsRepository.AddDiscount(id, discount))
            {
                Console.WriteLine($" Discount: {discount} Added Succesfully to Id: {id}");
            }
            else
            {
                throw new IncompleteOrderException($" Discount Not added for Id : {id}");
            }
        }                     

    }
}
