using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        List<string> possiblePeople;
        int chooseFlavor;
        public string name;
        public string flavorProfile;
        public bool wantsLemonade;


        public Customer(Random random, Weather weather, Recipe recipe)
        {
            possiblePeople = new List<string> { "Seasonally Depressed Young Adult", "Angsty Teenager", "Basic White Girl", "A Ditzy Blonde", "A Man Who Doesn't Need Directions", "Kid Who Knows Everything" };
            name = possiblePeople[random.Next(0, 5)];
            wantsLemonade = true;
            chooseFlavor = random.Next(0, 2);


            if(chooseFlavor == 0)
            {
                flavorProfile = "sweet";
            }
            else if(chooseFlavor == 1)
            {
                flavorProfile = "sour";
            }

            // Randomly decide based upon weather condition, temperature, and the cost of lemonade whether to purchase a lemonade or not
            if (weather.temperature < random.Next(5, 35) || recipe.pricePerGlass > random.NextDouble() || weather.condition == weather.weatherConditions[random.Next(0, 3)])
            {
                wantsLemonade = false;
            }

            // Compares customers flavor preferences to today's recipe
            if ((flavorProfile == "sweet" && recipe.amountOfSugarCubes < recipe.amountOfLemons) || (flavorProfile == "sour" && recipe.amountOfSugarCubes > recipe.amountOfLemons))
            {
                wantsLemonade = false;
            }
        }
    }
}
