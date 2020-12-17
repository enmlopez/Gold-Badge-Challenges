using _04_KomodoOutingsRepo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutings
{
    class UI_Outings
    {
        OutingRepository _outingsRepo = new OutingRepository();
        public void Run()
        {
            SeedOutings();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all Company Outings\n" +
                    "2. Add an Outing to the list\n" +
                    "3. Display the cost of an individual Outing\n" +
                    "4. Display Total Cost of Outings\n" +
                    "5. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllOutings();
                        break;
                    case 2:
                        AddNewOutings();
                        break;
                    case 3:
                        CostByTypeOfEvent();
                        break;
                    case 4:
                        CostOfAllEvents();
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
        private void SeeAllOutings()
        {
            Console.Clear();
            List<Outings> newListOutings = _outingsRepo.SeeOutingsList();
            foreach (Outings newOuting in newListOutings)
            {
                Console.WriteLine($"Event Type: {newOuting.EventTypes}\n" +
                    $"Number of Attendees: {newOuting.NumberOfAttendees}\n" +
                    $"Price per Person: {newOuting.CostPerPerson:C2}\n" +
                    $"Date of Event: {newOuting.DateOfEvent.ToString("MM/dd/yyyy")}\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void AddNewOutings()
        {
            Console.Clear();
            Outings newOuting = new Outings();

            Console.WriteLine("Choose the Type of Event available:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int i1 = int.Parse(Console.ReadLine());
            newOuting.EventTypes = (enumEventTypes)i1;

            Console.WriteLine("Enter how many people will attend:");
            int i2 = int.Parse(Console.ReadLine());
            newOuting.NumberOfAttendees = i2;

            Console.WriteLine("Enter cost per person:");
            double i3 = double.Parse(Console.ReadLine());
            newOuting.CostPerPerson = i3;

            Console.WriteLine("Enter Date Of Event:  (mm/dd/yyyy)");
            DateTime i4 = DateTime.Parse(Console.ReadLine());
            newOuting.DateOfEvent = i4;

            _outingsRepo.AddOutingToList(newOuting);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private void CostByTypeOfEvent()
        {
            Console.WriteLine("Choose the type of event:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");

            int chooseType = int.Parse(Console.ReadLine());
            switch (chooseType)
            {
                case 1:
                    double costOfGolfEvent = _outingsRepo.TestCostPerType(enumEventTypes.Golf);
                    Console.WriteLine($"Total Cost of Golf Outings: {costOfGolfEvent:C2}");
                    Console.ReadLine();
                    break;
                case 2:
                    double costOfBowlingEvent = _outingsRepo.TestCostPerType(enumEventTypes.Bowling);
                    Console.WriteLine($"Total Cost of Bowling Outings: {costOfBowlingEvent:C2}");
                    Console.ReadLine();
                    break;
                case 3:
                    double costOfAmuEvent = _outingsRepo.TestCostPerType(enumEventTypes.Amusement_Park);
                    Console.WriteLine($"Total Cost of Amusement Park Outings: {costOfAmuEvent:C2}");
                    Console.ReadLine();
                    break;
                case 4:
                    double costOfConcertEvent = _outingsRepo.TestCostPerType(enumEventTypes.Concert);
                    Console.WriteLine($"Total Cost of Concerts: {costOfConcertEvent:C2}");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please try again");
                    break;
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
        private void CostOfAllEvents()
        {
            double totalCost = _outingsRepo.TotalCostEvents();
            Console.WriteLine($"Total Cost of all Company Outings: {totalCost:C2}");

            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        }
        private void SeedOutings()
        {
            DateTime golfDate = new DateTime(2020, 01, 30);
            DateTime concertDate = new DateTime(2020, 02, 25);
            DateTime bowlingDate = new DateTime(2020, 03, 30);
            DateTime amuParkDate = new DateTime(2020, 04, 30);

            Outings golfEvent = new Outings(enumEventTypes.Golf, 300, golfDate, 30.00);
            Outings concertEvent = new Outings(enumEventTypes.Concert, 500, concertDate, 40.00);
            Outings bowlingEvent = new Outings(enumEventTypes.Bowling, 50, bowlingDate, 20.00);
            Outings amuParkEvent = new Outings(enumEventTypes.Amusement_Park, 1000, amuParkDate, 50.00);

            _outingsRepo.AddOutingToList(golfEvent);
            _outingsRepo.AddOutingToList(concertEvent);
            _outingsRepo.AddOutingToList(bowlingEvent);
            _outingsRepo.AddOutingToList(amuParkEvent);
        }
        
    }
}
