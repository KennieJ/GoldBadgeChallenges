using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        //public string IngredientNumber { get; set; }

        public Ingredient() { }
        public Ingredient(string ingredientName)
        {
            IngredientName = ingredientName;
            //IngredientNumber = ingredientNumber;
        }
    }
    public class Meal
    {
        public string ItemNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public double MealPrice { get; set; }

        public Meal() { }
        public Meal(string itemNumber, string mealName, string mealDescription, double mealPrice, List<string> listOfIngredients)
        {
            ItemNumber = itemNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }
    }
}
