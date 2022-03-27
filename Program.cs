using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] items = new[] { "espresso", "latte", "cappuccino" };
            int[] items_water = new[] { 50, 200, 250 };
            int[] items_cream = new[] { 0, 150, 100 };
            int[] items_coffee = new[] { 25, 20, 15 };
            decimal[] items_prices = new[] { 1.5M, 2.5M, 3M };

            string[] resource = new[] { "water", "cream", "coffee", "money" };
            decimal[] resource_levels = new[] { 300M, 200M, 100M, 0M };
            string[] resource_measures = new[] { "oz", "oz", "g", "USD" };

            bool machineOn = true;

            do
            {
                if (!Console.IsOutputRedirected)
                    Console.Clear();

                Console.WriteLine("What would you like? (espresso/latte/cappuccino)");
                string input = Console.ReadLine() ?? "";

                switch (input.ToUpperInvariant())
                {
                    case "OFF":
                        machineOn = false;
                        Console.WriteLine("Shutting down... Press [any] key.");
                        Console.ReadKey(true);
                        break;
                    case "REPORT":
                        Console.WriteLine("Current Status:");
                        for (int index = 0; index < resource.Length; index++)
                        {
                            Console.WriteLine($"\t{resource[index]} = {resource_levels[index]}{resource_measures[index]}");
                        }
                        Console.WriteLine("Press [any] key.");
                        Console.ReadKey(true);
                        break;
                    case "MENU":
                        Console.WriteLine("Current Menu:");
                        for (int index = 0; index < items.Length; index++)
                        {
                            Console.WriteLine($"{items[index]} {items_prices[index]}{resource_measures[3]}");
                        }
                        Console.WriteLine("Press [any] key.");
                        Console.ReadKey(true);
                        break;
                    case "ESPRESSO":
                    case "LATTE":
                    case "CAPPUCCINO":

                        // find menu item index
                        int item = 0;
                        for (int index = 0; index < items.Length; index++)
                        {
                            if (string.Equals(items[index], input, StringComparison.InvariantCultureIgnoreCase))
                            {
                                item = index;
                            }
                        }

                        // check resources
                        if (resource_levels[0] < items_water[item])
                        {
                            Console.WriteLine("Sorry not enough water...");
                        }
                        else if (resource_levels[1] < items_cream[item])
                        {
                            Console.WriteLine("Sorry not enough cream...");
                        }
                        else if (resource_levels[2] < items_coffee[item])
                        {
                            Console.WriteLine("Sorry not enough coffee...");
                        }
                        else
                        {
                            decimal amountPaid = 0;
                            int coins;

                            Console.WriteLine($"Please pay {items_prices[item]}{resource_measures[3]}:");
                            Console.WriteLine("How many quarters?");
                            if (int.TryParse(Console.ReadLine(), out coins))
                                amountPaid += coins * .25M;

                            Console.WriteLine("How many dimes?");
                            if (int.TryParse(Console.ReadLine(), out coins))
                                amountPaid += coins * .10M;

                            Console.WriteLine("How many nickles?");
                            if (int.TryParse(Console.ReadLine(), out coins))
                                amountPaid += coins * .05M;

                            Console.WriteLine("How many pennies?");
                            if (int.TryParse(Console.ReadLine(), out coins))
                                amountPaid += coins * .01M;

                            if (amountPaid < items_prices[item])
                            {
                                Console.WriteLine("Sorry not enough money...");
                            }
                            else
                            {
                                resource_levels[0] -= items_water[item];
                                resource_levels[1] -= items_cream[item];
                                resource_levels[2] -= items_coffee[item];
                                resource_levels[3] += items_prices[item];

                                Console.WriteLine($"Here is your change {amountPaid - items_prices[item]}{resource_levels[3]}");
                                Console.WriteLine($"Here is your {items[item]}. Enjoy!");
                            }
                        }

                        Console.WriteLine("To continue, press [any] key.");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Invalid selection, please try again. Press [any] key.");
                        Console.ReadKey(true);
                        break;
                }
            } while (machineOn);
        }
    }
}
