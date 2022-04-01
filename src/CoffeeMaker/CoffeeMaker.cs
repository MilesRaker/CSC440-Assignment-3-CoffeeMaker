using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMaker
    {
        /* psuedo code
         * 
         * Needed Classes:
         * - drinks (abstract)
         *   + descendants: espresso, latte, cappuccino, <custom drink 1>, <custom drink 2>
         *   + drinks have (has a) ingredients
         * - ingredients (template)
         *   + descendants: sugar, coffee, water, cream
         * - money (abstract)
         *   + descendants: all common denominations of physical US currency
         * - coffeemaker (drink factory?)
         * 
         * Needed methods:
         * - TurnCoffeeMakerOnOff()
         * - ReportInventory()
         * - orderDrink()
         *   + exchangeMoney() makes change and deposits cash into inventory
         *   + makeDrink() uses ingredients
         *   + menue items: drinks[]
         * - refillInventory()
         * 
         * Each unit test and git commit gives 2pts extra credit
         */


    }
}
