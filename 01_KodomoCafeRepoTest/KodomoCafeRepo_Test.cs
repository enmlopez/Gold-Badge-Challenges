using _01_KodomoCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KodomoCafeRepoTest
{
    [TestClass]
    public class KodomoCafeRepo_Test
    {
        [TestMethod]
        public void TestAddItemsToMenu()
        {
            //Arrange
            KodomoMeals newMeal = new KodomoMeals(); //creating a new meal object class KodomoMeals
            KodomoCafeRepo newCafeRepo = new KodomoCafeRepo(); //creating a new repo class KodomoCafeRepo
            newMeal.ItemNumber = 5; //setting the property of new meal object = to 5

            //Act
            KodomoMeals testMeal = newCafeRepo.GetMenuById(5); //Using helper method to find if item 5 exists



            //Assert




















            ////Arrange
            //KodomoCafeRepo cafeRepo = new KodomoCafeRepo();
            //KodomoMeals mealOne = new KodomoMeals();
            //mealOne.ItemNumber = 5;

            ////Act
            //cafeRepo.AddItemsToMenu(mealOne);
            //KodomoMeals kodomoMeals = cafeRepo.GetMenuById(5);
            ////Assert
            //Assert.AreEqual(5, kodomoMeals.ItemNumber);
        }
    }
}
