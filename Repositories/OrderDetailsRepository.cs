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
    internal class OrderDetailsRepository : IOrderDetailsRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        public OrderDetailsRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public decimal CalculateSubtotal(int id)
        {
            decimal total = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT totalamount FROM orderdetails WHERE orderdetailid = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                try
                {
                    total = (decimal)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return total;
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            OrderDetails orderDetails = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "SELECT * FROM orderdetails WHERE orderdetailid = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orderDetails = new OrderDetails();
                    orderDetails.OrderDetailId = (int)reader["OrderDetailID"];
                    orderDetails.ProductId = (int)reader["ProductID"];
                    orderDetails.OrderId = (int)reader["OrderID"];
                    orderDetails.Quantity = (int)reader["Quantity"];
                    orderDetails.TotalAmount = (decimal)reader["TotalAmount"];
                }
            }
            return orderDetails;
        }

        public bool UpdateQuantity(int id, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "UPDATE orderdetails SET quantity = @qty where orderdetailid = @id";
                cmd.Parameters.AddWithValue("@qty", quantity);
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

        public bool AddDiscount(int id, int discount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd.CommandText = "UPDATE orderdetails SET totalamount = totalamount - (totalamount * @discount/100) WHERE orderdetailid = @id";
                cmd.Parameters.AddWithValue("@discount", discount);
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
    }
}
