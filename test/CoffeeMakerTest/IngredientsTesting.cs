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
        [DataRow(new int[4] { 100, 50, 50, 10 }, new int[4] { 200, 150, 50, 90 })]
        [DataRow(new int[4] { 200, 75, 20, 90 }, new int[4] { 100, 125, 80, 10 })]
        public void UseIngredientsTest(int[] ingredientsUsed, int[] expected)
        {
            // arrange
            Ingredients ingredients = new Ingredients();

            // act
            ingredients.useIngredients(ingredientsUsed);
            int[] actual = ingredients.getStock();

            // assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);

        }

        [TestMethod]
        [DataRow(new int[4] { 300, 200, 100, 100 })]
        public void RestockTest(int[] expected)
        {
            // arrange
            Ingredients ingredients = new Ingredients();

            // act
            ingredients.useIngredients(new int[4]{130, 50, 30, 20});
            ingredients.restock();
            int[] actual = ingredients.getStock();

            // assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }


}
