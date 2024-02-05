using assignment.Model;
using assignment.Utility;
using System;
using System.Data.SqlClient;

namespace assignment.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public CustomerRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        #region CalculateTotalOrders

        public int CalculateTotalOrders(int id)
        {
            int totalorders = 0;
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    sqlconnection.Open();
                    cmd.CommandText = "SELECT count(CustomerId) FROM Orders WHERE CustomerId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = sqlconnection;
                    totalorders = (int)cmd.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return totalorders;
        }
        #endregion

        #region GetCustomerDetails
        public List<Customers> GetCustomerDetails()
        {
            List<Customers> customersList = new List<Customers>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Customers";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customers customers = new Customers();
                        customers.CustomerID = (int)reader["CustomerID"];
                        customers.FirstName = (string)reader["FirstName"];
                        customers.LastName = (string)reader["LastName"];
                        customers.Email = (string)reader["Email"];
                        customers.Phone = (string)reader["Phone"];
                        customers.Address = (string)reader["Address"];
                        customersList.Add(customers);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customersList;
        }
        #endregion

        #region UpdateCustomerInfo
        public bool UpdateCustomerInfo(int id, string email)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    cmd.CommandText = "UPDATE customers SET Email=@email WHERE customerID = @id";
                    cmd.Connection = sqlConnection;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@email", email);
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

