using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_KodomoEmailRepo
{
    public enum Types
    {
        Potential = 1,
        Current, 
        Past
    }
    public class Customers
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public Types TypesOfCustomers { get; set; }
        public string Email { get; set; }
        public Customers() { }
        public Customers(string firstName, string lastName, Types typesOfCustomers, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            TypesOfCustomers = typesOfCustomers;
            Email = email;
        }
    }
}
