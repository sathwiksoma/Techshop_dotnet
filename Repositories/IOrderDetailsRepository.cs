using assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    internal interface IOrderDetailsRepository
    {
        decimal CalculateSubtotal(int id);
        OrderDetails GetOrderDetailsById(int id);
        bool UpdateQuantity(int id, int quantity);
        bool AddDiscount(int id, int discount);

    }
}
