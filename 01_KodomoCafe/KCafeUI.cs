using _01_KodomoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KodomoCafe
{
    class KCafeUI
    {
        private KodomoCafeRepo _cafeRepo = new KodomoCafeRepo();

        public void Run()
        {
            SeedMenu();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to KODOMO Cafe\n\n" +
                    "Choose a number below\n" +
                    "1. Add Menu items\n" +
                    "2. Delete Menu items\n" +
                    "3. See Items by ID\n" +
                    "4. See all items in the Menu\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddMenuItems();
                        break;
                    case "2":
                        DeleteMenuItems();
                        break;
                    case "3":
                        SeeMealByNumber();
                        break;
                    case "4":
                        SeeAllMenuItems();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Plase press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void AddMenuItems()
        {
            Console.Clear();
            KodomoMeals newItem = new KodomoMeals();
            Console.WriteLine("Enter the Item Number");
            newItem.ItemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Item Name");
            newItem.ItemName = Console.ReadLine();

            Console.WriteLine("1. Meals\n" +
                "2. Drinks/Desserts/Etc.");
            int mealOrEtc = int.Parse(Console.ReadLine());
            switch (mealOrEtc)
            {
                case 1:
                    Console.WriteLine("Choose your type of bread: \n" +
                        "1. White_Bread\n" +
                        "2. Wheat_Bread\n" +
                        "3. Multigrain\n" +
                        "4. Italian\n" +
                        "5. Flat_Bread");
                    int ingredientAsInt1 = int.Parse(Console.ReadLine());
                    newItem.I1 = (enumBreadItems)ingredientAsInt1;

                    Console.WriteLine("Choose your meat: \n" +
                        "1. Chicken\n" +
                        "2. Beef\n" +
                        "3. Pork\n" +
                        "4. Turkey");
                    int ingredientAsInt2 = int.Parse(Console.ReadLine());
                    newItem.I2 = (enumMeatItems)ingredientAsInt2;

                    Console.WriteLine("Choose your topping: \n" +
                        "1. Tomato\n" +
                        "2. Lettuce\n" +
                        "3. Pickles\n" +
                        "4. Onions\n" +
                        "5. Spinach");
                    int ingredientAsInt3 = int.Parse(Console.ReadLine());
                    newItem.I3 = (enumAdditivesItems)ingredientAsInt3;

                    Console.WriteLine("Choose your sauce: \n" +
                        "1. Mustard\n" +
                        "2. Mayo\n" +
                        "3. Ketchup\n" +
                        "4. Jalapeño");
                    int ingredientAsInt4 = int.Parse(Console.ReadLine());
                    newItem.I4 = (enumSauceItems)ingredientAsInt4;

                    Console.WriteLine("Type the item's description below");
                    string descriptionItem = Console.ReadLine();
                    newItem.ItemDescription = descriptionItem;
                    
                    Console.Clear();
                    Console.WriteLine("Input price: (ex: 5.99)");
                    string priceItem = Console.ReadLine();
                    newItem.Price = priceItem;

                    _cafeRepo.AddItemsToMenu(newItem);
                    break;
                case 2:
                    Console.WriteLine("Type the item's description below");
                    string descriptionItem1 = Console.ReadLine();
                    newItem.ItemDescription = descriptionItem1;
                    
                    Console.Clear();
                    Console.WriteLine("Input price: (ex: 5.99)");
                    string priceItem1 = Console.ReadLine();
                    newItem.Price = priceItem1;

                    _cafeRepo.AddItemsToMenu(newItem);
                    break;
            }

        }
        private void DeleteMenuItems()
        {
            SeeAllMenuItems();
            Console.WriteLine("Enter the Item ID Number to remove:");
            int idNumber = int.Parse(Console.ReadLine());
            bool wasDeleted = _cafeRepo.DeleteItemsFromMenu(idNumber);
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted");
            }
            else
            {
                Console.WriteLine("Oops. Try again!");
            }
        }
        private void SeeMealByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the Item Number:");
            int itemNumber = int.Parse(Console.ReadLine());
            KodomoMeals cafeItem = _cafeRepo.GetMenuById(itemNumber);
            if (cafeItem != null)
            {
                Console.Clear();
                Console.WriteLine($"ID: {cafeItem.ItemNumber}\nName: {cafeItem.ItemName}\nIngredients:\n     {cafeItem.I1}\n     {cafeItem.I2}\n     {cafeItem.I3}\n     {cafeItem.I4}\nDescription: {cafeItem.ItemDescription}\nPrice: {cafeItem.Price}\n");
            }
            else
            {
                Console.WriteLine("No item by that number. Try again!");
            }
        }
        private void SeeAllMenuItems()
        {
            Console.Clear();
            List<KodomoMeals> listOfMenuItems = _cafeRepo.GetMealsList();
            foreach (KodomoMeals meals in listOfMenuItems)
            {
                Console.WriteLine($"ID: {meals.ItemNumber}\nName: {meals.ItemName}\nDescription: {meals.ItemDescription}\nPrice: {meals.Price}\n");
            }
        }
        private void SeedMenu()
        {
            KodomoMeals roastedChickenBreast = new KodomoMeals(1, "Roasted Chicken Breast", enumBreadItems.White_Bread, enumMeatItems.Chicken, enumAdditivesItems.Lettuce, enumSauceItems.Mayo, "A roasted chicken breast", "7.99");
            KodomoMeals tunaSandwich = new KodomoMeals(2, "Tuna Sandwich", enumBreadItems.Italian, enumMeatItems.Tuna, enumAdditivesItems.Lettuce, enumSauceItems.Mayo, "A wild tuna sandwich, plenty for everyone at home", "5.99");
            KodomoMeals smallCoffee = new KodomoMeals(3, "Small Coffee", "A delicious HOT small coffee", "1.99");
            KodomoMeals smallOrangeJuice = new KodomoMeals(4, "Small Orange Juice", "Plain squeezed oranges.  All natural.", "2.99");

            _cafeRepo.AddItemsToMenu(roastedChickenBreast);
            _cafeRepo.AddItemsToMenu(tunaSandwich);
            _cafeRepo.AddItemsToMenu(smallCoffee);
            _cafeRepo.AddItemsToMenu(smallOrangeJuice);
        }
    }
}

