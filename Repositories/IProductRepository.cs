using assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    internal interface IProductRepository
    {
        public Products GetProductDetails(int id);
        public bool UpdateProductInfo(int id);
        public bool IsProductInStock(int id);
    }
}
