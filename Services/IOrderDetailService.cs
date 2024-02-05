using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Services
{
    internal interface IOrderDetailService
    {
        void CalculateSubtotal(int id);
        void GetOrderDetailsById(int id);
        void UpdateQuantity(int id, int quantity);
        void AddDiscount(int id, int discount);
    }
}
