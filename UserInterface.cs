using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static int GetNumberOfIngredients(string ingredientsToAdd)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem <= 0)
            {
                Console.WriteLine("How many " + ingredientsToAdd + " would you like to add?");
                Console.WriteLine("Please enter a positive integer:");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }


        public static double SetPricePerGlass()
        {
            bool userInputIsADouble = false;
            double pricePerGlass = -1;

            while (!userInputIsADouble || pricePerGlass <= 0)
            {
                Console.WriteLine("How much would you like to charge per glass?");
                Console.WriteLine("Please enter a price between $0.01 and $1.00:");

                userInputIsADouble = Double.TryParse(Console.ReadLine(), out pricePerGlass);
            }


            return pricePerGlass;
        }

        public static string GetUserName()
        {
            Console.WriteLine("What is your name?");

            return Console.ReadLine();
        }

        public static void CustomerStopsByShop(string customerName, bool buysLemonade)
        {
            if (buysLemonade == true)
            {
                Console.WriteLine(customerName + " has stopped by your lemonade stand and purchased a lemonade!");
            }
            else
            {
                Console.WriteLine(customerName + " stopped by your lemonade stand, they didn't want any lemonade this time.");
            }
            Console.ReadLine();
        }

        public static int DetermineGameLength()
        {
            bool userInputIsAnInteger = false;
            int lengthOfGame = -1;

            while (!userInputIsAnInteger || lengthOfGame <= 0)
            {
                Console.WriteLine("How many weeks would you like to play for?");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out lengthOfGame);
            }

            return lengthOfGame;
        }

        public static void DisplayForecast(List<Weather> forecast)
        {
            int i = 0;
            Console.WriteLine("This Week's Weather Forecast");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            while(i < forecast.Count())
            {
                Console.WriteLine("Day " + (i+1) + ": Weather-" + forecast[i].condition + "      Temperature-" + forecast[i].temperature + " degrees");
                i++;
            }

            Console.ReadLine();
        }

        public static void DisplayWeather(int temp, string condition)
        {
            Console.WriteLine("It is " + condition + " out today.");
            Console.WriteLine("The temperature is " + temp + ".");
        }

        public static void DisplayInventory(int lemons, int sugar, int ice, int cups)
        {
            Console.WriteLine("Lemons: " + lemons);
            Console.WriteLine("Sugar Cubes: " + sugar);
            Console.WriteLine("Ice Cubes: " + ice);
            Console.WriteLine("Cups: " + cups);
            Console.ReadLine();
        }

        public static void DisplayDailyTotals(double profitLoss, double runningTotal, string name)
        {
            Console.WriteLine("You made $" + Math.Round(profitLoss, 2) + " today, " + name + "!");
            Console.WriteLine("You now have $" + runningTotal);
            Console.ReadLine();
        }

        public static void StoreIsSoldOut(string item)
        {
            Console.WriteLine("Your shop is sold out of " + item + ". Make sure to stock up on more product for tomorrow!");
            Console.ReadLine();
        }

        public static void AllOutOfMoney(string name)
        {
            Console.WriteLine("Oh no! You ran out of money, " + name + "! Better luck next time!");
            Console.ReadLine();
        }

        public static void ClearDisplay()
        {
            Console.Clear();
        }
    }
}
