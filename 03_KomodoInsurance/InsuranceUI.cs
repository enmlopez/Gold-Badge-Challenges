using _03_KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_KomodoInsurance
{
    class InsuranceUI
    {
        private InsuranceRepo _insuranceRepo = new InsuranceRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance - Badge Access:\n" +
                    "1. Create new badge\n" +
                    "2. Update doors on an existing badge\n" +
                    "3. Show a list with all badge numbers and door accesses\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        Thread.Sleep(750);
                        break;
                }

            }
        }
        private void AddBadges()
        {
            Badges newBadge = Dictionary<int,List<string>>() 
            
            
        }

    }
}
