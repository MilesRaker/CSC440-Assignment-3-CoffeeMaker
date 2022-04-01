using System;
using CoffeeMaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMakerTest
{
    [TestClass]
    public class DrinkTesting
    {
        [TestMethod]
        [DataRow("late", 3.50, 100, 0, 12, 0, new int[4] {200, 200, 88, 100})]
        [DataRow("Krazy Koffee", 43.23, 150, 190, 99, 90, new int[4] { 150, 10, 1, 10 })]
        public void CreateDrinks(string name, double cost, int water, int cream, int coffee, int sugar, int[] expected)
        {
            // arrange
            Drink drink = new Drink(name, cost, water, cream, coffee, sugar);
            Ingredients ingredients = new Ingredients();

            // act
            drink.MakeDrink(ingredients);
            
            // assert
            Assert.AreEqual(expected[0], ingredients.IngredientCount[0]);
            Assert.AreEqual(expected[1], ingredients.IngredientCount[1]);
            Assert.AreEqual(expected[2], ingredients.IngredientCount[2]);
            Assert.AreEqual(expected[3], ingredients.IngredientCount[3]);
        }
    }
}
