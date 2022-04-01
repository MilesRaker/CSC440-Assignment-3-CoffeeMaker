using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker;

namespace CoffeeMakerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Coffee Maker Starting....");
            Thread.Sleep(1500);
            Console.WriteLine("Grinding beans");
            Thread.Sleep(1000);
            Console.WriteLine("Energizing Caffiene!");
            Thread.Sleep(500);
            Console.WriteLine("Fully Brewed. Welcome to Miles' Coffee Maker App");
            Thread.Sleep(1000);

            CoffeeMachine coffeeMachine = new CoffeeMachine();
            bool consoleOn = true;
            while (consoleOn)
            {
                Console.WriteLine(coffeeMachine.menue());

                int input = Int32.Parse(Console.ReadLine()); // TODO: invalid input handling
                string output = "";

                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        output = cashierHelper(coffeeMachine, input);
                        break;
                    case 5:
                        output = coffeeMachine.Report().ToString();
                        break;
                    case 6:
                        coffeeMachine.restock();
                        output = "Coffee machine fully restocked.";
                        break;
                    case 7:
                        coffeeMachine.power();
                        consoleOn = coffeeMachine.Power;
                        output = "Coffee maching turned off. Goodbye.";
                        break;
                }
                Console.WriteLine(output);
            }
        }
        public static string cashierHelper(CoffeeMachine coffeeMachine, int input)
        {
            Console.WriteLine($"Your total is: {coffeeMachine.Price[input - 1]}");
            Console.WriteLine($"How much money did you put in the machine?");
            decimal cashPaid = decimal.Parse(Console.ReadLine());// TODO: invalid input handling
            return coffeeMachine.orderDrink(input - 1, cashPaid).ToString();
        }
       
    }
}
