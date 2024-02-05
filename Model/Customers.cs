using System;
using System.Data;

namespace assignment.Model
{
    internal class Customers
    {
        // Attributes
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Constructor
        public Customers(int customerId, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public Customers() { }
     
        public override string ToString()
        {
            return $"CustomerID:{CustomerID}\n FirstName:{FirstName}\n LastName:{LastName}\n Email:{Email}\n Phone:{Phone}\n Address:{Address}";
        }
    }
}
