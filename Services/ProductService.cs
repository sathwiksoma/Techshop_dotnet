using assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment.Repositories;
using assignment.Model;

namespace assignment.Services
{
    internal class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new Repository.ProductRepository();
        }
        public void GetProductDetails(int id)
        {
            Products product = _productRepository.GetProductDetails(id);
            Console.WriteLine(product);
        }

        #region 
        public void UpdateProductInfo(int id)
        {
            bool updatedSuccessfully = _productRepository.UpdateProductInfo(id);
            if (updatedSuccessfully)
            {
                Console.WriteLine("Updation Successful by 50 percent increased");
            }
            else
            {
                Console.WriteLine("Product Updation has Failed");
            }
        }
        #endregion

        public void IsProductInStock(int id)
        {
            if (_productRepository.IsProductInStock(id))
            {
                Console.WriteLine($"The given product id {id} is available in stock");
            }
            else
            {
                throw new InvalidDataException("Invalid id");
            }
        }
    }
}