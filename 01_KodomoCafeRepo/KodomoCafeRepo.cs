using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KodomoCafeRepo
{
    //public static class KomodoCafeDatabase
    //{
    //    public static List<KodomoMeals> _meals = new List<KodomoMeals>();
    //}
    public class KodomoCafeRepo
    {
        private List<KodomoMeals> _listofCafeItems = new List<KodomoMeals>();

        //Create
        public void AddItemsToMenu(KodomoMeals meals)
        {
            _listofCafeItems.Add(meals);
        }
        //Read
        public List<KodomoMeals> GetMealsList()
        {
            return _listofCafeItems;
        }
        //Delete
        public bool DeleteItemsFromMenu(int mealId)
        {
            KodomoMeals meals = GetMenuById(mealId);
            if(meals == null)
            {
                return false;
            }
            int initialCount = _listofCafeItems.Count;
            _listofCafeItems.Remove(meals);

            if(initialCount > _listofCafeItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public KodomoMeals GetMenuById(int mealId)
        {
            foreach (KodomoMeals meals in _listofCafeItems)
            {
                if(meals.ItemNumber == mealId)
                {
                    return meals;
                }
            }
            return null;
        }
    }
}
