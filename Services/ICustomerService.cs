using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Services
{
    internal interface ICustomerService
    {
        void CalculateTotalOrders(int id);
        void GetCustomerDetails();
        void UpdateCustomerInfo(int id, string email);
    }
}
