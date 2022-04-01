using System;
using CoffeeMaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMakerTest
{
    [TestClass]
    public class IngredientsTesting
    {

        [TestMethod]
        [DataRow("water", 300)]
        [DataRow("cream", 200)]
        [DataRow("coffee", 100)]
        [DataRow("sugar", 100)]
        public void GetStockTest(string ingredient, int expected)
        {
            // arrange
            Ingredients ingredients = new Ingredients();

            // act
            int actual = ingredients.getStock(ingredient);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [DataRow("water", 100, 200)]
        [DataRow("cream", 75, 125)]
        [DataRow("coffee", 22, 78)]
        [DataRow("sugar", 99, 1)]
        public void UseIngredientTest(string ingredientName, int amountUsed, int expected)
        {
            // arrange
            Ingredients ingredients = new Ingredients();

            // act
            ingredients.useIngredient(ingredientName, amountUsed);
            int actual = ingredients.getStock(ingredientName);

            // assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow("water", 300)]
        [DataRow("cream", 200)]
        [DataRow("coffee", 100)]
        [DataRow("sugar", 100)]
        public void ResetIngredientTest(string ingredient, int expected)
        {
            // arrange
            Ingredients ingredients = new Ingredients();

            // act
            ingredients.useIngredient("water", 100);
            ingredients.useIngredient("sugar", 75);
            ingredients.useIngredient("cream", 50);
            ingredients.refillIngredients();
            int actual = ingredients.getStock(ingredient);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }


}
