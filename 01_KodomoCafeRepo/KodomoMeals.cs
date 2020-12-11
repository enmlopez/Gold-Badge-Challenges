using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KodomoCafeRepo
{
    public enum enumBreadItems
    {
        White_Bread = 1,
        Wheat_Bread,
        Multigrain,
        Italian,
        Flat_Bread,
    }
    public enum enumMeatItems
    {
        Chicken = 1,
        Tuna,
        Beef,
        Pork,
        Turkey,
        Vegan,
    }
    public enum enumAdditivesItems
    {
        Tomato=1,
        Lettuce,
        Pickles,
        Onion,
    }
    public enum enumSauceItems
    {
        Mustard=1,
        Mayo,
        Ketchup,
        Jalapeño,
    }
    public class KodomoMeals
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public enumBreadItems I1 { get; set; }
        public enumMeatItems I2 { get; set; }
        public enumAdditivesItems I3 { get; set; }
        public enumSauceItems I4 { get; set; }
        //public List<string> ListOfIngredients { get; set; } = new List<string>();
        public string ItemDescription { get; set; }
        public string Price { get; set; }

        public KodomoMeals() { }
        public KodomoMeals(int mealNumber, string mealName, string mealDescription, string price)
        {
            ItemNumber = mealNumber;
            ItemName = mealName;
            ItemDescription = mealDescription;
            Price = price;
        }
        public KodomoMeals(int mealNumber, string mealName, enumBreadItems i1, enumMeatItems i2, enumAdditivesItems i3, enumSauceItems i4, string mealDescription , string price)
        {
            ItemNumber = mealNumber;
            ItemName = mealName;
            I1 = i1;
            I2 = i2;
            I3 = i3;
            I4 = i4;
            ItemDescription = mealDescription;
            Price = price;
        }
    }
}
