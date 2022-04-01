using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class Drink
    {
        private string _name;
        private string[] _ingredientNames = { "water", "cream", "coffee", "sugar" };
        private string[] _units = { "oz", "oz", "g", "g" };
        private int[] _ingredientsUsed = { 0, 0, 0, 0 };
        private double _cost = 0;

        public Drink(string name, double cost, int water, int cream, int coffee, int sugar)
        {
            _name = name;
            _ingredientsUsed[0] = water;
            _ingredientsUsed[1] = cream;
            _ingredientsUsed[2] = coffee;
            _ingredientsUsed[3] = sugar;
            _cost = cost;
        }
        /// <summary>
        /// Makes drink, uses ingredients from coffeemaker
        /// </summary>
        public void MakeDrink(Ingredients ingredients) {
            if (ingredients.canMakeDrink(_ingredientsUsed))
            {
                ingredients.useIngredients(_ingredientsUsed);
                // TODO: Pay for the drink, give change if needed  
            }
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine($"Drink Name: {_name} \nCost: {_cost} \nWater Used: {_ingredientsUsed[0]} \nCream Used: {_ingredientsUsed[1]} \n" +
                $"Coffee Used: {_ingredientsUsed[2]} \nSugar Used: {_ingredientsUsed[3]}");
            return sw.ToString();
        }

    }
}
