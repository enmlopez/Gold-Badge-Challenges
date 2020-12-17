using _05_KodomoEmailRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_KodomoEmail
{
    class UI_Email
    {
        EmailRepo _emailRepo = new EmailRepo();
        public void Run()
        {
            SeedCustomers();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all Customers in the Database\n" +
                    "2. Add a new customer to Database\n" +
                    "3. Remove a customer from Database\n" +
                    "4. Update info on an existing Customer\n" +
                    "5. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllCustomers();
                        break;
                    case 2:
                        AddNewCustomersToList();
                        break;
                    case 3:
                        RemoveCustomerFromList();
                        break;
                    case 4:
                        UpdateExistingCustomer();
                        break;
                    case 5:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.Clear();
                        break;
                }

            }
        }
        private void SeeAllCustomers()
        {
            Console.Clear();
            List<Customers> customerList = _emailRepo.SeeCustomerList();
            IOrderedEnumerable<Customers> customerInOrder = customerList.OrderBy(customer => customer.LastName);
            Console.WriteLine("First Name" + "   " + "Last Name" + "      " + "Type" + "           " + "Email");
            foreach (Customers customer in customerInOrder)
            {
                Console.WriteLine($"{customer.FirstName,-13}" +
                    $"{customer.LastName,-14} " +
                    $"{customer.TypesOfCustomers,-14} " +
                    $"{customer.Email}");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
        private void AddNewCustomersToList()
        {
            Console.Clear();
            Customers newCustomer = new Customers();
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            newCustomer.FirstName = firstName;

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            newCustomer.LastName = lastName;

            Console.WriteLine("Choose a Type: \n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past\n");
            int type = int.Parse(Console.ReadLine());
            newCustomer.TypesOfCustomers = (Types)type;
            switch (type)
            {
                case 1:
                    newCustomer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                case 2:
                    newCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 3:
                    newCustomer.Email = "It's been a long time since we've heard from you, we want you back.";
                    break;
            }

            _emailRepo.AddCustomersToList(newCustomer);
        }
        private void RemoveCustomerFromList()
        {
            Console.Clear();

            SeeAllCustomers();
            Console.WriteLine("What is the First Name of the person to be removed:");
            string firstName = Console.ReadLine();
            _emailRepo.DeleteCustomer(firstName);

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private void UpdateExistingCustomer()
        {
            Console.Clear();

            SeeAllCustomers();
            Customers updateCustomer = new Customers();

            Console.WriteLine("What is the First Name of the person you want to update:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Re-enter customer's first name:");
            string updateFirstName = Console.ReadLine();
            updateCustomer.FirstName = updateFirstName;

            Console.WriteLine("Re-enter customer's last name:");
            string updateLastName = Console.ReadLine();
            updateCustomer.LastName = updateLastName;

            Console.WriteLine("Choose a new Type: \n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past\n");
            int updateType = int.Parse(Console.ReadLine());
            updateCustomer.TypesOfCustomers = (Types)updateType;
            switch (updateType)
            {
                case 1:
                    updateCustomer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                case 2:
                    updateCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 3:
                    updateCustomer.Email = "It's been a long time since we've heard from you, we want you back.";
                    break;
            }

            _emailRepo.UpdateCustomerList(updateCustomer, firstName);
        }
        private void SeedCustomers()
        {
            Customers jakeSmith = new Customers("Jake", "Aldorado", Types.Potential, "We currently have the lowest rates on Helicopter Insurance!");
            Customers jamesSmith = new Customers("James", "Zeta", Types.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Customers janeSmith = new Customers("Jane", "Killa", Types.Past, "It's been a long time since we've heard from you, we want you back.");

            _emailRepo.AddCustomersToList(jakeSmith);
            _emailRepo.AddCustomersToList(jamesSmith);
            _emailRepo.AddCustomersToList(janeSmith);
        }
    }
}

