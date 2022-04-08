using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMachine
    {
        private Ingredients _stock = new Ingredients();
        private decimal _cash = 10;
        // look for and store file names in Drinks folder

        private Drink[] _menue = {};
        public decimal[] Price { get { return new decimal[4] { _menue[0].Cost, _menue[1].Cost, _menue[2].Cost, _menue[3].Cost }; } }
        private bool _power = true; // is the coffee maker powered on?
        private bool _notEnoughChange = false;
        public bool Power { get { return _power; } }

        /// <summary>
        /// Constructor, reads Drink files to initialize _menue
        /// </summary>
        public CoffeeMachine() 
        {
            IEnumerable<FileInfo> drinkFiles = getDrinkFiles();
            FileInfo[] drinkFilesArray = drinkFiles.ToArray();
            Drink[] menue = new Drink[drinkFilesArray.Length];
            for (int i = 0; i < drinkFiles.Count(); i++)
            {
                menue[i] = getDrinkFromFile(drinkFilesArray[i].FullName);
            }
            _menue = menue;
        }

        /// <summary>
        /// Find all drink files in Drink directory
        /// </summary>
        /// <returns>Enumerable with FileInfo for each drink file</returns>
        private static IEnumerable<FileInfo> getDrinkFiles()
        {
            DirectoryInfo drinkDirectory = new DirectoryInfo(@"./../../../Drinks");
            IEnumerable<FileInfo> drinkFiles = drinkDirectory.EnumerateFiles();
            return drinkFiles;
        }
        /// <summary>
        /// Reads a drink file and creates a Drink object
        /// </summary>
        /// <param name="arg">path to a drink file</param>
        /// <returns>Drink object</returns>
        private static Drink getDrinkFromFile(string arg)
        {
            // open file
            // read data from file
            string[] lines = System.IO.File.ReadAllLines(@arg);
            return new Drink(lines[0], decimal.Parse(lines[1]), int.Parse(lines[2]), int.Parse(lines[3]), int.Parse(lines[4]), int.Parse(lines[5]));
        }

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
            _power = !_power;
        }

        public StringWriter menue()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine($"Coffee Menu:\n (enter the option number to make a selection)\n 1. {_menue[0].Name} ....... {_menue[0].Cost} \n 2. {_menue[1].Name} ....... {_menue[1].Cost} \n" +
                $" 3. {_menue[2].Name} ....... {_menue[2].Cost} \n 4. {_menue[3].Name} ....... {_menue[3].Cost} \n 5. Report \n 6. Restock \n 7. Power Off");
            return sw;
        }

        public void restock()
        {
            _cash = 10;
            _stock.restock();
        }

        public decimal makeChange(int drinkNumber, decimal cashPaid)
        {
            // paid - cost of drink = change
            decimal change = cashPaid - _menue[drinkNumber].Cost;
            if(change > _cash)
            {
                _notEnoughChange = true;
                return cashPaid;
            }
            _cash += _menue[drinkNumber].Cost;
            return change;
        }
        public StringWriter orderDrink(int drinkNumber, decimal cashPaid)
        {
            decimal change = makeChange(drinkNumber, cashPaid);
            bool canMakeDrink = _stock.canMakeDrink(_menue[drinkNumber].IngredientsUsed);
            StringWriter sw = new StringWriter();
            if(canMakeDrink && !_notEnoughChange)
            {
                // make the drink
                _menue[drinkNumber].MakeDrink(_stock);
                sw.WriteLine($"Thank you, here is your {_menue[drinkNumber].Name}");
                if(change > 0)
                {
                    sw.WriteLine($"Your change is: {change}");
                }
            }
            else
            {
                // don't make the drink
                sw.WriteLine($"I wasn't able to process your order.");
                if (!canMakeDrink)
                {
                    sw.WriteLine("Insufficient ingredients in machine. Please restock.");
                }
                if (_notEnoughChange)
                {
                    sw.WriteLine("Insufficient change. Please use exact change, or restock.");
                }
            }

            return sw;
        }
    }
}
