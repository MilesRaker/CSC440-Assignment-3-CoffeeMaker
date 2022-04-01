using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMaker
    {
        private Ingredients _stock = new Ingredients();
        private decimal _cash = 0;
        private Drink[] _menue = 
            { new Drink("Espresso", 1.5M, 50, 0, 25, 0),
            new Drink("Late", 2.5M, 50, 25, 25, 0),
            new Drink("Cappuccino", 3M, 0, 50, 50, 0),
            new Drink("SugarHigh", 0.5M, 25, 25, 50, 35)};
        private bool _on = true; // is the coffee maker powered on?
        public CoffeeMaker() { }

        /// <summary>
        /// for use with menu option: "Report"
        /// </summary>
        /// <returns>StringWriter formatted report</returns>
        public StringWriter Report()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine($"---Coffee Maker Report---\nMoney in Till: {_cash}\nWater: {_stock.IngredientCount[0]} {_stock.Units[0]}\n" +
                $"Cream: {_stock.IngredientCount[1]} {_stock.Units[1]}\nCoffee: {_stock.IngredientCount[2]} {_stock.Units[2]}\n" +
                $"Sugar: {_stock.IngredientCount[3]} {_stock.Units[3]}\n");
            return sw;
        }
        /// <summary>
        /// For use with menu option: "Power Off"
        /// </summary>
        public void power()
        {
            _on = !_on;
        }


    }
}
