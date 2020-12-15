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
            SeedDictionary();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Insurance - Badge Access:\n" +
                    "1. Create new badge\n" +
                    "2. Update doors on an existing badge\n" +
                    "3. Show a list with all badge numbers and door accesses\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadges();
                        break;
                    case "2":
                        UpdateBadge();
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
            Console.Clear();

            Badges newBadge = new Badges();

            Console.WriteLine("What is the badge ID?");
            int badgeId = int.Parse(Console.ReadLine());
            newBadge.BadgeId = badgeId;
            Console.WriteLine("List a door that it needs access to: (ex: A#)");
            string aDoor = Console.ReadLine();

            _insuranceRepo.AddDoorsToBadge(newBadge, aDoor);

            Console.WriteLine("Any other doors (y/n)?");
            string anotherDoor = Console.ReadLine().ToLower();
            
            if (anotherDoor == "y")
            {
                Console.WriteLine("List a door that it needs access to: (ex: A#)");
                string aDoor2 = Console.ReadLine();
                _insuranceRepo.AddDoorsToBadge(newBadge,aDoor2);

                Console.WriteLine("Any other doors (y/n)?");
                string anotherDoorDoor = Console.ReadLine().ToLower();

                if(anotherDoorDoor == "y")
                {
                Console.WriteLine("List a door that it needs access to: (ex: A#)");
                string aDoor3 = Console.ReadLine();
                _insuranceRepo.AddDoorsToBadge(newBadge, aDoor3);
                }
            }

            _insuranceRepo.AddBadgestoDict(newBadge);
            
            Dictionary<int, Badges> badgeDirectory = _insuranceRepo.GetEntireDict();
            foreach (KeyValuePair<int, Badges> kvp in badgeDirectory)
            {
                Console.WriteLine($"\nKey = {kvp.Key} has access to:");
                
                foreach(string door in kvp.Value.DoorNames)
                {
                    Console.Write($"{door} ");
                }
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
        private void UpdateBadge()
        {
            Console.Clear();

            Console.WriteLine("What Badge ID would you like to update?");
            int input = int.Parse(Console.ReadLine());
            Badges badge = _insuranceRepo.GetBadgeById(input);

            
            Console.WriteLine(badge[input]);
            
        }
        private void SeedDictionary()
        {
            var userOne = new List<string>() { "A1", "D2", "D3" };
            var userTwo = new List<string>() { "A2", "C5" };
            var userThree = new List<string>() { "B10", "B11" };
            Badges one = new Badges(1, userOne);
            Badges two = new Badges(2, userTwo);
            Badges three = new Badges(3, userThree);

            _insuranceRepo.AddBadgestoDict(one);
            _insuranceRepo.AddBadgestoDict(two);
            _insuranceRepo.AddBadgestoDict(three);
        }

    }
}

