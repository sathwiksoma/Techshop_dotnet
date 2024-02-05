using assignment.Model;
using assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment.Utility;
using System.Reflection.Metadata.Ecma335;

namespace assignment.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public string connectionString;
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public ProductRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Products GetProductDetails(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM products WHERE ProductID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Products product = new Products();
                        product.ProductId = (int)reader["ProductID"];
                        product.ProductName = (string)reader["ProductName"];
                        product.Description = (string)reader["Description"];
                        product.Price = (int)reader["Price"];
                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        #region UpdateProductInfo
        public bool UpdateProductInfo(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE Products SET price = price + (price*0.5) where ProductID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    int rowsEffected = cmd.ExecuteNonQuery();
                    result = rowsEffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region IsProductInStock
        public bool IsProductInStock(int id)
        {
            int res = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.CommandText = "select productId From Inventory where productId = @ID and quantityInStock > 0";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection = conn;
                    res = (int)cmd.ExecuteScalar();                                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res > 0;
        }

    }
    #endregion
}
