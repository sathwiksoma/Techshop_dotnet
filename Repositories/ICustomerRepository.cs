using assignment.Model;
using System;

namespace assignment.Repositories
{
    internal interface ICustomerRepository
    {
        int CalculateTotalOrders(int customerId);
        List <Customers>GetCustomerDetails();
        bool UpdateCustomerInfo(int id, string mail);
    }
}
