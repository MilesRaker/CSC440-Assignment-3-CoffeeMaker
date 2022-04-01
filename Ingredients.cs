using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class Ingredients
    {
        private string[] _ingredientNames = { "water", "cream", "coffee", "sugar" };
        private string[] _units = { "oz", "oz", "g", "g" };
        private int[] _ingredientCount = { 300, 200, 100, 100 };

        public int[] IngredientCount { get { return _ingredientCount; } }
        public string[] Units { get { return _units; } }
        public string[] IngredientNames { get { return _ingredientNames; } }

        public Ingredients(){}
        public Ingredients(int water, int cream, int coffee, int sugar)
        {
            _ingredientCount[0] = water;
            _ingredientCount[1] = cream;
            _ingredientCount[2] = coffee;
            _ingredientCount[3] = sugar;
        }

        /// <summary>
        /// Uses ingredients from vending machine's supply.
        /// </summary>
        /// <param name="ingredient">choose from: water cream coffee sugar</param>
        /// <param name="amountUsed">should match amount needed for drink made</param>
        /// <returns>
        /// If there is enough supply for the method call, then method decreases the amount in storage and returns true
        /// If there is not enough supply, method returns false. No changes made to internal fields
        /// </returns>
        public bool useIngredient(string ingredient, int amountUsed)
        {
            int ingredientIndex = getIndex(ingredient);

            if (getStock(ingredient) > amountUsed)
            {
                _ingredientCount[ingredientIndex] = _ingredientCount[ingredientIndex] - amountUsed;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks current stock of particular ingredient
        /// </summary>
        /// <param name="ingredient">choose from: water cream coffee sugar</param>
        /// <returns>int, stock of ingredient</returns>
        public int getStock(string ingredient)
        {
            int indexOfIngredientUsed = getIndex(ingredient);
            return _ingredientCount[indexOfIngredientUsed];
        }

        /// <summary>
        /// Finds the index of a particular ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns>returns index of ingredient</returns>
        public int getIndex(string ingredient)
        {
            return Array.IndexOf(_ingredientNames, ingredient);
        }

        /// <summary>
        /// Restocks ingredients
        /// </summary>
        public void refillIngredients()
        {
            _ingredientCount[0] = 300;
            _ingredientCount[1] = 200;
            _ingredientCount[2] = 100;
            _ingredientCount[3] = 100;
        }
    }
}
