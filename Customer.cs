﻿using System;
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
            possiblePeople = new List<string> { "Ben Dover", "Eileen Dover", "Jim Nasuim", "Herbie Hind", "Ivanna Tinkle", "Sandy Beach", "Lee Kee Bum", "Dr. Seymour Butz",  };
            name = possiblePeople[random.Next(0, 5)];
            wantsLemonade = true;

            RandomizeLemonadeDesire(random, weather, recipe);
        }

        private void RandomizeLemonadeDesire(Random random, Weather weather, Recipe recipe)
        {
            chooseFlavor = random.Next(0, 2);


            if (chooseFlavor == 0)
            {
                flavorProfile = "sweet";
            }
            else if (chooseFlavor == 1)
            {
                flavorProfile = "sour";
            }

            // Randomly decide based upon weather condition, temperature, and the cost of lemonade whether to purchase a lemonade or not
            if (weather.temperature < random.Next(5, 35) || recipe.pricePerGlass > (random.NextDouble() + .4) || weather.condition == weather.weatherConditions[random.Next(0, 3)])
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
