using assignment.Exceptions;
using assignment.Model;
using assignment.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Repositories
{
    internal class InventoryRepository : IInventoryRepository
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public InventoryRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Products GetProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT Products.ProductID, Products.ProductName, Products.Description, products.Price FROM products join inventory on products.productid = inventory.productid where inventory.productid=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
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
            return null;
        }

        public int GetQuantityInStock(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT QuantityInStock FROM Inventory where ProductID=@pd_Id";
                cmd.Parameters.AddWithValue("@pd_Id", id);
                cmd.Connection = connection;
                int quantity;
                try
                {
                    quantity = (int)cmd.ExecuteScalar();
                    return quantity;
                }
                catch (InsufficientStockException)
                {
                    Console.WriteLine("Stock not available");
                }
            }
            return 0;
        }

        public bool AddToInventory(int productId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "UPDATE inventory SET QuantityInStock = QuantityInStock + @quantity WHERE ProductID=@id";
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public bool RemoveFromInventory(int productId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "UPDATE inventory SET quantityinstock = quantityinstock - @quantity where ProductID=@id";
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public bool UpdateStockQuantity(int id, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "UPDATE inventory set quantityinstock = @newQuantity where ProductID=@id";
                cmd.Parameters.AddWithValue("@newquantity", newQuantity);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                int rowsEffected;
                try
                {
                    rowsEffected = cmd.ExecuteNonQuery();
                    return rowsEffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public bool IsProductAvailable(int productID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT quantityinstock from inventory where productid=@id";
                cmd.Parameters.AddWithValue("@id", productID);
                cmd.Connection = connection;
                int productQuantity;
                try
                {
                    productQuantity = (int)cmd.ExecuteScalar();
                    return productQuantity >= quantity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return false;
        }

        public int GetInventoryValue(int productID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT (products.price * inventory.quantityinstock) from inventory JOIN products on products.productid = inventory.productid WHERE inventory.productid=@id";
                cmd.Parameters.AddWithValue("@id", productID);
                cmd.Connection = connection;
                int price;
                try
                {
                    price = (int)cmd.ExecuteScalar();
                    return price;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return -1;
        }
                           

        public List<string> ListLowStockProducts(int threshold)
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT products.ProductName from inventory JOIN products on products.productid = inventory.productid where inventory.quantityinstock < @threshold";
                cmd.Parameters.AddWithValue("@threshold", threshold);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;
        }

        public List<string> ListOutOfStockProducts()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT products.ProductName from inventory JOIN products on Products.ProductID = Inventory.ProductID where Inventory.QuantityInStock = 0";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;
        }

        public List<string> ListAllProducts()
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT products.ProductName from inventory join products on products.productid=inventory.productid";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["ProductName"]);
                }
            }
            return result;

        }
    }
}
