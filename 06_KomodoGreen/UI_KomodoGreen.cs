using _06_KomodoGreenRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreen
{
    class UI_KomodoGreen
    {
        KomodoCarRepo _carRepo = new KomodoCarRepo();
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
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See the entire Car List\n" +
                    "2. See List of Car by Type\n" +
                    "3. Add a new car to the list\n" +
                    "4. Remove a car from the list\n" +
                    "5. Update information on an existing car\n" +
                    "6. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllCarsList();
                        break;
                    case 2:
                        SeeCarListByType();
                        break;
                    case 3:
                        AddNewCarToList();
                        break;
                    case 4:
                        DeleteCarFromList();
                        break;
                    case 5:
                        UpdateCarOnList();
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.Clear();
                        break;
                }
            }
        }
        private void SeeAllCarsList()
        {
            Console.Clear();
            List<Cars> carList = _carRepo.SeeCarList();
            foreach (Cars car in carList)
            {
                Console.WriteLine($"VIN: {car.Vin}\n" +
                    $"Type: {car.TypeOfCar}\n" +
                    $"Model: {car.Model}\n" +
                    $"Brand: {car.Brand}\n" +
                    $"Range: {car.Range} miles\n" +
                    $"Price: {car.CarPrice:C2}\n" +
                    $"Yearly Cost of Maintenance: {car.CostMaintenanceYearly:C2}\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void SeeCarListByType()
        {
            Console.WriteLine("Choose Type of Car to view:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    List<Cars> electricList = _carRepo.SeeCarList();
                    foreach (Cars car in electricList)
                    {
                        if (TypeOfCar.Electric == car.TypeOfCar)
                            Console.WriteLine($"VIN: {car.Vin}\n" +
                                $"Type: {car.TypeOfCar}\n" +
                                $"Model: {car.Model}\n" +
                                $"Brand: {car.Brand}\n" +
                                $"Range: {car.Range} miles\n" +
                                $"Price: {car.CarPrice:C2}\n" +
                                $"Yearly Cost of Maintenance: {car.CostMaintenanceYearly:C2}\n");

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 2:
                    List<Cars> hybridList = _carRepo.SeeCarList();
                    foreach (Cars car in hybridList)
                    {
                        if (TypeOfCar.Hybrid == car.TypeOfCar)
                            Console.WriteLine($"VIN: {car.Vin}\n" +
                                $"Type: {car.TypeOfCar}\n" +
                                $"Model: {car.Model}\n" +
                                $"Brand: {car.Brand}\n" +
                                $"Range: {car.Range} miles\n" +
                                $"Price: {car.CarPrice:C2}\n" +
                                $"Yearly Cost of Maintenance: {car.CostMaintenanceYearly:C2}\n");

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 3:
                    List<Cars> gasList = _carRepo.SeeCarList();
                    foreach (Cars car in gasList)
                    {
                        if (TypeOfCar.Gas == car.TypeOfCar)
                            Console.WriteLine($"VIN: {car.Vin}\n" +
                                $"Type: {car.TypeOfCar}\n" +
                                $"Model: {car.Model}\n" +
                                $"Brand: {car.Brand}\n" +
                                $"Range: {car.Range} miles\n" +
                                $"Price: {car.CarPrice:C2}\n" +
                                $"Yearly Cost of Maintenance: {car.CostMaintenanceYearly:C2}\n");

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    break;
            }
        }
        private void AddNewCarToList()
        {
            Console.Clear();

            Cars newCar = new Cars();

            Console.WriteLine("What is the Vehicle Identification Number? (VIN)");
            int vin = int.Parse(Console.ReadLine());
            newCar.Vin = vin;

            Console.WriteLine("Choose the Type of Car:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            int input = int.Parse(Console.ReadLine());
            newCar.TypeOfCar = (TypeOfCar)input;

            Console.WriteLine("What is the model of the car?");
            string model = Console.ReadLine();
            newCar.Model = model;

            Console.WriteLine("What is the brand of the car?");
            string brand = Console.ReadLine();
            newCar.Brand = brand;

            Console.WriteLine("What is the Range? (Miles when full)");
            int range = int.Parse(Console.ReadLine());
            newCar.Range = range;

            Console.WriteLine("What is the price of the car?");
            double carPrice = double.Parse(Console.ReadLine());
            newCar.CarPrice = carPrice;

            Console.WriteLine("What is the yearly maintenance cost?");
            double maintYearlyCost = double.Parse(Console.ReadLine());
            newCar.CostMaintenanceYearly = maintYearlyCost;

            _carRepo.AddCartoList(newCar);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void DeleteCarFromList()
        {
            Console.Clear();
            Console.WriteLine("What is the VIN of the car to remove: (ex:1)");
            int vin = int.Parse(Console.ReadLine());
            _carRepo.DeleteCarFromList(vin);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void UpdateCarOnList()
        {
            Console.Clear();

            Console.WriteLine("What is the VIN of the car to update: (ex:1)");
            int vin = int.Parse(Console.ReadLine());
            Cars oldCar = _carRepo.GetCarByVin(vin);
            oldCar.Vin = vin;

            Console.WriteLine("Choose the Type of Car:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            int input = int.Parse(Console.ReadLine());
            oldCar.TypeOfCar = (TypeOfCar)input;

            Console.WriteLine("What is the model of the car?");
            string model = Console.ReadLine();
            oldCar.Model = model;

            Console.WriteLine("What is the brand of the car?");
            string brand = Console.ReadLine();
            oldCar.Brand = brand;

            Console.WriteLine("What is the Range? (Miles when full)");
            int range = int.Parse(Console.ReadLine());
            oldCar.Range = range;

            Console.WriteLine("What is the price of the car?");
            double carPrice = double.Parse(Console.ReadLine());
            oldCar.CarPrice = carPrice;

            Console.WriteLine("What is the yearly maintenance cost?");
            double maintYearlyCost = double.Parse(Console.ReadLine());
            oldCar.CostMaintenanceYearly = maintYearlyCost;

            _carRepo.UpdateCarOnList(vin, oldCar);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        private void SeedList()
        {
            Cars tesla = new Cars(1, TypeOfCar.Electric, "X", "Tesla", 350, 50000, 5000);
            Cars teslaY = new Cars(2, TypeOfCar.Electric, "Y", "Tesla", 300, 60000, 6000);
            Cars prius = new Cars(3, TypeOfCar.Hybrid, "Prius", "Toyota", 350, 30000, 10000);
            Cars f150 = new Cars(4, TypeOfCar.Gas, "F-150", "Ford", 200, 40000, 3000);

            _carRepo.AddCartoList(teslaY);
            _carRepo.AddCartoList(tesla);
            _carRepo.AddCartoList(prius);
            _carRepo.AddCartoList(f150);
        }
    }
}
