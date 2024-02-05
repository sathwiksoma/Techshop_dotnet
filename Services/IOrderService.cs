using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Services
{
    internal interface IOrderService
    {
        void CalculateTotalAmount(int id);
        void GetOrderDetails();
        void UpdateOrderStatus(int id, string status);
        //void CancelOrder();
    }
}
