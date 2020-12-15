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

            _insuranceRepo.AddDoorsToBadge(badgeId, aDoor);

            Console.WriteLine("Any other doors (y/n)?");
            string anotherDoor = Console.ReadLine().ToLower();

            if (anotherDoor == "y")
            {
                Console.WriteLine("List a door that it needs access to: (ex: A#)");
                string aDoor2 = Console.ReadLine();
                _insuranceRepo.AddDoorsToBadge(badgeId, aDoor2);

                Console.WriteLine("Any other doors (y/n)?");
                string anotherDoorDoor = Console.ReadLine().ToLower();

                if (anotherDoorDoor == "y")
                {
                    Console.WriteLine("List a door that it needs access to: (ex: A#)");
                    string aDoor3 = Console.ReadLine();
                    _insuranceRepo.AddDoorsToBadge(badgeId, aDoor3);
                }
            }

            _insuranceRepo.AddBadgestoDict(newBadge);
            WriteDictionaryOut();

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
        private void UpdateBadge()
        {
            Console.Clear();

            WriteDictionaryOut();

            Badges newBadge = new Badges();
            Console.WriteLine("What Badge ID would you like to update?");
            int input = int.Parse(Console.ReadLine());
            newBadge.BadgeId = input;

            Console.ReadLine();
            Console.WriteLine("What would you like to do?\n" +
                "1. Add a door\n" +
                "2. Remove a door");
            int addOrRemove = int.Parse(Console.ReadLine());
            switch (addOrRemove)
            {
                case 1:
                    Console.WriteLine("List a door to add: (ex: A#)");
                    string addDoor = Console.ReadLine();
                    _insuranceRepo.AddDoorsToBadge(input, addDoor);

                    WriteDictionaryOut();

                    foreach (string door in newBadge.DoorNames)
                    {
                        Console.WriteLine($"{door} ");
                    }
                    break;
                case 2:
                    Console.WriteLine("List a door to remove: (ex: A#)");
                    string removeDoor = Console.ReadLine();
                    _insuranceRepo.DelDoorFromBadge(input, removeDoor);
                    WriteDictionaryOut();
                    foreach (string door in newBadge.DoorNames)
                    {
                        Console.WriteLine($"{door} ");
                    }
                    break;

            }
            bool wasUpdated = _insuranceRepo.UpdateDict(input, newBadge);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update content");
            }
            
            Console.ReadLine();
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
        private void WriteDictionaryOut()
        {
            Dictionary<int, Badges> badgeDirectory = _insuranceRepo.GetEntireDict();
            foreach (KeyValuePair<int, Badges> kvp in badgeDirectory)
            {
                Console.WriteLine($"\nKey = {kvp.Key} has access to:");

                foreach (string door in kvp.Value.DoorNames)
                {
                    Console.Write($"{door} \n");
                }
            }
        }
    }
}

