using assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    internal interface IOrderRepository
    {
        int CalculateTotalAmount(int id);
        List<Orders> GetOrderDetails();
        bool UpdateOrderStatus(int id, string status);
        //int CancelOrder(int id);
    }
}
