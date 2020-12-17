using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        private List<Ingredient> _ingredientList = new List<Ingredient>();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            
            while (keepRunning)
            {
                //display options
                Console.WriteLine("Welcome to the Komodo Cafe! Select an option below:\n" +
                    "1. Create a new menu item\n" +
                    "2. Update an existing menu item\n" +
                    "3. Delete a menu item\n" +
                    "4. View meal details\n" +
                    "5. View all menu items\n" +
                    "6. Close program" );

                //get input
                string input = Console.ReadLine();

                //switch case
                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        UpdateMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        DisplayMenuItemByNumber();
                        break;
                    case "5":
                        DisplayAllMenuItems();
                        break;
                    case "6":
                        //close app
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();

            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();
            Meal newMeal = new Meal();

            Console.WriteLine("Enter the meal name:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal description:");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the meal item number:");
            newMeal.ItemNumber = Console.ReadLine();

            Console.WriteLine("Enter the meal price:");
            string priceAsString = Console.ReadLine();
            newMeal.MealPrice = double.Parse(priceAsString);

            Console.WriteLine("Enter ingredients separated by a comma:");
            //double check this part
            List<string> listOfIngredientsString = Console.ReadLine().Split(',').ToList();
            var listOfIngredientsToAdd = new List<string>();

            foreach(string ingredientString in listOfIngredientsString)
            {
                string newIngredient = _menuRepo.GetIngredientByName(ingredientString);
                listOfIngredientsToAdd.Add(newIngredient);
            }

            _menuRepo.AddItemToList(newMeal);
        }

        private void UpdateMenuItem()
        {
            DisplayAllMenuItems();

            Console.WriteLine("Enter the item number you wish to update:");
            string oldItemNumber = Console.ReadLine();
            
            Console.Clear();
            Meal newMeal = new Meal();

            Console.WriteLine("Enter the meal name:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Enter the meal description:");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the meal item number:");
            newMeal.ItemNumber = Console.ReadLine();

            Console.WriteLine("Enter the meal price:");
            string priceAsString = Console.ReadLine();
            newMeal.MealPrice = double.Parse(priceAsString);

            Console.WriteLine("Enter ingredients separated by a comma:");
            //double check this part
            List<string> listOfIngredientsString = Console.ReadLine().Split(',').ToList();
            var listOfIngredientsToAdd = new List<string>();

            foreach (string ingredientString in listOfIngredientsString)
            {
                string newIngredient = _menuRepo.GetIngredientByName(ingredientString);
                listOfIngredientsToAdd.Add(newIngredient);
            }

            //verify
            bool wasUpdated = _menuRepo.UpdateExistingMeal(oldItemNumber, newMeal);

            if (wasUpdated)
            {
                Console.WriteLine("Meal updated successfully");
            }
            else
            {
                Console.WriteLine("Could not update meal");
            }
        }

        private void DeleteMenuItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("Enter the meal number you'd like to delete:");
            string mealNumber = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveMealFromList(mealNumber);

            if (wasDeleted)
            {
                Console.WriteLine("The meal was deleted");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted");
            }
        }

        private void DisplayMenuItemByNumber()
        {
            Console.Clear();
            DisplayAllMenuItems();

            Console.WriteLine("Enter a meal number to see details:");
            string input = Console.ReadLine();
            Meal displayMeal = _menuRepo.GetMealByNumber(input);

            if(displayMeal != null)
            {
                DisplayMealDetails(displayMeal);
            }
            else
            {
                Console.WriteLine("Please enter a valid meal number");
            }

        }

        private void DisplayMealDetails(Meal displayMeal)
        {
            Console.WriteLine($"{displayMeal.ItemNumber}. {displayMeal.MealName}:\n" +
                $"{displayMeal.MealDescription}\n" +
                $"Ingredients:");
            displayMeal.ListOfIngredients = _menuRepo.GetIngredientList();
            foreach(var ingredient in displayMeal.ListOfIngredients)
            {
                DisplayIngredient(ingredient);
            }
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<Meal> listOfMeals = _menuRepo.GetMealList();
            foreach(Meal meal in listOfMeals)
            {
                Console.WriteLine($"{meal.ItemNumber}. {meal.MealName}");
            }
        }
        
        private void DisplayIngredient(string ingredient)
        {
            Console.WriteLine($"{ingredient}");
        }
    }
}
