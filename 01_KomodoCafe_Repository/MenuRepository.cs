using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class MenuRepository
    {
        private List<Meal> _listOfMenuItems = new List<Meal>();
        private List<string> _listOfIngredients = new List<string>();

        //Create
        public void AddItemToList(Meal item)
        {
            _listOfMenuItems.Add(item);
        }

        public void AddIngredientToMeal(string ingredient)
        {
            _listOfIngredients.Add(ingredient);
        }

        //Read
        public List<Meal> GetMealList()
        {
            return _listOfMenuItems;
        }

        public List<string> GetIngredientList()
        {
            return _listOfIngredients;
        }
        
        //Update
        public bool UpdateExistingMeal(string originalItemNumber, Meal newMeal)
        {
            //find
            Meal oldMeal = GetMealByNumber(originalItemNumber);

            //update
            if(oldMeal != null)
            {
                oldMeal.ItemNumber = newMeal.ItemNumber;
                oldMeal.MealDescription = newMeal.MealDescription;
                oldMeal.ListOfIngredients = newMeal.ListOfIngredients;
                oldMeal.MealName = newMeal.MealName;
                oldMeal.MealPrice = newMeal.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool UpdateExistingIngredients(string ogIngredientName, string newIngredient)
        //{
        //    //find
        //    string oldIngredient = GetIngredientByName(ogIngredientName);

        //    //update
        //    if(oldIngredient != null)
        //    {
        //        oldIngredient = newIngredient;
        //        //oldIngredient.IngredientNumber = newIngredient.IngredientNumber;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool UpdateIngredientList(string mealNumber, List<string> newList)
        {
            //find
            Meal oldMeal = GetMealByNumber(mealNumber);

            //update
            if(oldMeal != null)
            {
                oldMeal.ListOfIngredients = newList;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Delete
        public bool RemoveMealFromList(string itemNumber)
        {
            Meal meal = GetMealByNumber(itemNumber);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(meal);

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper methods
        public Meal GetMealByNumber(string itemNumber)
        {
            foreach (Meal meal in _listOfMenuItems)
            {
                if(meal.ItemNumber.ToLower() == itemNumber.ToLower())
                {
                    return meal;
                }
            }

            return null;
        }

        public string GetIngredientByName(string ingredientInput)
        {
            foreach(string ingredient in _listOfIngredients)
            {
                if(ingredient.ToLower() == ingredientInput.ToLower())
                {
                    return ingredient;
                }
            }

            return null;
        }
    }
}
