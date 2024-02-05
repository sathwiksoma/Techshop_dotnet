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
    internal class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        #region method-1
        public void CalculateTotalOrders(int id)
        {
            int totalorders = _customerRepository.CalculateTotalOrders(id);
            Console.WriteLine($"The Total No. of Orders for given id : {id} is = {totalorders}");
        }
        #endregion

        #region method-2
        public void GetCustomerDetails()
        {
            List<Customers> customers = _customerRepository.GetCustomerDetails();
            foreach (Customers customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
        #endregion

        public void UpdateCustomerInfo(int id, string email)
        {
            bool updated = _customerRepository.UpdateCustomerInfo(id, email);
            if (updated)
            {
                Console.WriteLine("Successfully Updated");
            }
            else
            {
                Console.WriteLine("Invalid Input Entered");
            }
        }
    }
}


