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

            while (!userInputIsADouble || pricePerGlass < 0)
            {
                Console.WriteLine("How much would you like to charge per glass?");

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
            Console.Clear();
        }

        public static void DisplayWeather()
        {

        }

        public static void DisplayDailyTotals(double profitLoss, double runningTotal)
        {
            Console.WriteLine("You made $" + profitLoss + " today!");
            Console.WriteLine("You now have $" + runningTotal);
        }

        public static void ClearDisplay()
        {
            Console.Clear();
        }
    }
}
