using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_KomodoCafe_Repository;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class RepoTests
    {
        private MenuRepository _menuRepo;
        private Meal _meal;
        //private Ingredient _ingredient;

        [TestInitialize]

        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _meal = new Meal("3", "Fries", "Hot and salty", 1.99, new System.Collections.Generic.List<string> { "potatoes", "salt", "oil" });
            _menuRepo.AddItemToList(_meal);
            
        }

        [TestMethod]
        public void AddItemToList_ShouldNotGetNull()
        {
            //arrange
            Meal meal = new Meal();
            
            meal.ItemNumber = "1";
            //meal.ListOfIngredients.Add("2 all beef patties");
            //meal.ListOfIngredients.Add("special sauce");
            //meal.ListOfIngredients.Add("Bun, no seeds");
            meal.MealDescription = "A classic";
            meal.MealName = "The Big Mick";
            meal.MealPrice = 2.99;

            MenuRepository repository = new MenuRepository();

            //act
            repository.AddItemToList(meal);
            Meal mealFromMenu = repository.GetMealByNumber("1");

            //assert
            Assert.IsNotNull(mealFromMenu);
            
        }

        [TestMethod]
        public void AddIngredientToMeal_ShouldNotGetNull()
        {
            //arrange
            Meal meal2 = new Meal("2","Big Mac","A cheap ripoff", 5.99, null);

            //meal2.ItemNumber = "2";
            //meal2.MealDescription = "A ripoff";
            //meal2.MealPrice = 5.99;
            //meal2.MealName = "Big Mac";
            //string ingredient1 = "2 all beef patties";
            //string ingredient2 = "special sauce";
            //string ingredient3 = "sesame seed bun";

            //meal2.ListOfIngredients.Add(ingredient1);

            MenuRepository repository2 = new MenuRepository();

            //act
            repository2.AddItemToList(meal2);
            repository2.AddIngredientToMeal("sesame seed bun");
            //repository2.AddIngredientToMeal(ingredient2);
            //repository2.AddIngredientToMeal(ingredient3);

            string ingredientCheck = repository2.GetIngredientByName("sesame seed bun");
            //string ingredient2Check = repository2.GetIngredientByName(ingredient2);
            //string ingredient3Check = repository2.GetIngredientByName(ingredient3);
            Meal meal2Check = repository2.GetMealByNumber("2");

            //assert
            Assert.IsNotNull(ingredientCheck);
            //Assert.IsNotNull(ingredient2Check);
            //Assert.IsNotNull(ingredient3Check);
        }

        [TestMethod]
        public void UpdateExistingMeal_ShouldReturnTrue()
        {
            //arrange
            Meal newMeal = new Meal("3", "Fries", "Our hottest potatoes", 1.99, 
                new System.Collections.Generic.List<string>() { "potatoes", "salt", "oil" });

            //act
            bool updateResult = _menuRepo.UpdateExistingMeal("3", newMeal);

            //assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void UpdateIngredientList_ShouldReturnTrue()
        {
            //arrange
            Meal newMeal = new Meal("3", "Fries", "Our hottest potatoes", 1.99,
                new System.Collections.Generic.List<string>() { "potatoes", "salt", "oil" });

            //act
            bool updateResult = _menuRepo.UpdateIngredientList("3", new System.Collections.Generic.List<string> { "sea salt", "pepper", "potatoes" });

            //assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            //arrange
            //act
            bool deleteResult = _menuRepo.RemoveMealFromList(_meal.ItemNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }

    }
}
