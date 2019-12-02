using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        Random random;
        int amountOfPeople;
        double startOfDayCash;
        double dailyProfitOrLoss;
        public Weather weather;
        public List<Customer> customers;

        public Day(Player player)
        {
            weather = new Weather();
            customers = new List<Customer>();
            random = new Random();
            startOfDayCash = player.wallet.Money;

            // Display today's weather
            UserInterface.DisplayWeather(weather.temperature, weather.condition);

            // Validate that user is not sold out of any ingredients, procceed if they are not
            if (player.inventory.lemons.Count() == 0 || player.inventory.sugarCubes.Count() == 0 || player.inventory.iceCubes.Count() == 0)
            {
                UserInterface.StoreIsSoldOut("lemonade");
                UserInterface.DisplayDailyTotals(0, player.wallet.Money);
                UserInterface.ClearDisplay();
                return;
            }
            else
            {
                player.recipe.SetRecipe();
                UserInterface.ClearDisplay();
                player.pitcher.FillPitcher(player.recipe, player);

                amountOfPeople = random.Next(5, 10);

                for (int i = 0; i < amountOfPeople; i++)
                {
                    customers.Add(new Customer());

                    // Randomly decide based upon weather condition, temperature, and the cost of lemonade whether to purchase a lemonade or not
                    if (weather.temperature < random.Next(5, 35) || player.recipe.pricePerGlass > random.NextDouble() || weather.condition == weather.weatherConditions[random.Next(0, 3)])
                    {
                        customers[i].wantsLemonade = false;
                    }

                    if (customers[i].flavorProfile == "sweet" && player.recipe.amountOfSugarCubes < player.recipe.amountOfLemons)
                    {
                        customers[i].wantsLemonade = false;
                    }
                    else if(customers[i].flavorProfile == "sour" && player.recipe.amountOfSugarCubes > player.recipe.amountOfLemons)
                    {
                        customers[i].wantsLemonade = false;
                    }

                    // Make sure there are cups to pour lemonade in
                    if (player.inventory.cups.Count() <= 0)
                    {
                        UserInterface.StoreIsSoldOut("cups");
                        return;
                    }

                    if (customers[i].wantsLemonade == true && player.pitcher.cupsInPitcher > 0)
                    {
                        player.pitcher.PourAGlass(player);
                        player.wallet.Money += player.recipe.pricePerGlass;
                    
                    }
                    else if (customers[i].wantsLemonade == true && player.pitcher.cupsInPitcher <= 0)
                    {
                        if (player.inventory.lemons.Count() < player.recipe.amountOfLemons || player.inventory.sugarCubes.Count() < player.recipe.amountOfSugarCubes || player.inventory.iceCubes.Count() < player.recipe.amountOfIceCubes)
                        {
                            UserInterface.StoreIsSoldOut("lemonade");
                            UserInterface.DisplayDailyTotals(0, player.wallet.Money);
                            UserInterface.ClearDisplay();
                            return;
                        }
                        else
                        {
                            player.pitcher.FillPitcher(player.recipe, player);
                            player.pitcher.PourAGlass(player);
                            player.wallet.Money += player.recipe.pricePerGlass;
                        }
                    }

                    UserInterface.CustomerStopsByShop(customers[i].name, customers[i].wantsLemonade);
                    UserInterface.ClearDisplay();
                }

                dailyProfitOrLoss = player.wallet.Money - startOfDayCash;

                UserInterface.DisplayDailyTotals(dailyProfitOrLoss, player.wallet.Money, player.name);

                player.pitcher.EmptyPitcher();
                UserInterface.ClearDisplay();
            }
        }
    }
}
