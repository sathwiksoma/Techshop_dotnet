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
    internal class OrderRepository : IOrderRepository
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public OrderRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public int CalculateTotalAmount(int id)
        {
            int totalAmount = 0;
            try
            {               
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    sqlconnection.Open();
                    cmd.CommandText = "SELECT TotalAmount from Orders WHERE orderId = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Connection = sqlconnection;
                    totalAmount = (int)cmd.ExecuteScalar();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return totalAmount;
        }


        #region GetOrderDetails
        public List<Orders> GetOrderDetails()
        {
            List<Orders> ordersList = new List<Orders>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Orders";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Orders orders = new Orders();
                        orders.OrderID = (int)reader["OrderID"];
                        orders.CustomerID = (int)reader["CustomerID"];
                        orders.OrderDate = (DateTime)reader["OrderDate"];
                        orders.TotalAmount = (int)reader["TotalAmount"];
                        orders.Status = (string)reader["status"];
                        ordersList.Add(orders);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ordersList;
        }
        #endregion

        #region UpdateOrderStatus
        public bool UpdateOrderStatus(int id, string status)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    cmd.CommandText = "UPDATE Orders SET status = 'shipped' where orderId=@id";
                    cmd.Connection = sqlConnection;
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            #endregion
        }
    }
}
