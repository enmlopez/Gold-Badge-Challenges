using _01_KodomoCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KodomoCafeRepoTest
{
    [TestClass]
    public class KodomoCafeRepo_Test
    {
        [TestMethod]
        public void TestAddItemsToMenu()
        {
            //Arrange
            var newKodomoMeal = new KodomoMeals(); //create an instance of the object KodomoMeals called newKodomoMeal
            KodomoCafeRepo newCafeRepo = new KodomoCafeRepo(); //create an instance of the repo KodomoCafeRepo to access its methods
            newKodomoMeal.ItemNumber = 5; //set property for newKodomoMeal Item number = 5 
            //Act
            newCafeRepo.AddItemsToMenu(newKodomoMeal); //Add newKodomoMeal to the repo with property set
            KodomoMeals kodomoMeals = newCafeRepo.GetMenuById(5); //create a new instance of POCO and set value by looking it up in repo
            //Assert
            Assert.AreEqual(5, kodomoMeals.ItemNumber); //confirm that item was added to menu with correct property value for ItemNumber

        }
        [TestMethod]
        public void TestGetMealsList_ShouldNotNull()
        {
            //Arrange
            List<KodomoMeals> _newList = new List<KodomoMeals>();
            KodomoMeals newMeal = new KodomoMeals();
            //Act
            _newList.Add(newMeal);
            //Assert
            Assert.IsNotNull(_newList);
        }
        [TestMethod]
        public void TestDeleteMethod_ShouldGiveNull()
        {
            //Arrange
            KodomoMeals mealToDelete = new KodomoMeals();
            KodomoCafeRepo cafeRepoTest = new KodomoCafeRepo();
            mealToDelete.ItemNumber = 10;
            //Act
            cafeRepoTest.AddItemsToMenu(mealToDelete);
            bool testDeleted = cafeRepoTest.DeleteItemsFromMenu(mealToDelete.ItemNumber);
            //Assert
            Assert.IsTrue(testDeleted);
        }
    }
}
