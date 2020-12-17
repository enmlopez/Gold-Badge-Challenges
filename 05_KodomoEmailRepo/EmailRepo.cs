using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_KodomoEmailRepo
{
    public class EmailRepo
    {
        List<Customers> listOfCustomers = new List<Customers>();
        public void AddCustomersToList(Customers customer)
        {
            listOfCustomers.Add(customer);
        }
        public List<Customers> SeeCustomerList()
        {

            return listOfCustomers;
        }
        public bool UpdateCustomerList(Customers newCustomer, string firstName)
        {
            Customers oldCustomer = FindCustomerByName(firstName);
            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.TypesOfCustomers = newCustomer.TypesOfCustomers;
                oldCustomer.Email = newCustomer.Email;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteCustomer(string firstName)
        {
            Customers toBeRemoved = FindCustomerByName(firstName);
            listOfCustomers.Remove(toBeRemoved);
        }
        public Customers FindCustomerByName(string firstName) //For the sake of the challenge - otherwise by social, by driver's license, etc.
        {
            foreach(Customers customer in listOfCustomers)
            {
                if(customer.FirstName == firstName)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
