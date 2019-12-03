using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        int amountOfPeople;
        double startOfDayCash;
        double dailyProfitOrLoss;
        public Weather weather;
        public List<Customer> customers;

        public Day(Player player, Random random, Weather weather)
        {
            customers = new List<Customer>();
            startOfDayCash = player.wallet.Money;

            RunDay(player, random, weather);
        }

        public void RunDay(Player player, Random random, Weather weather)
        {
            // Randomly adjust weather based upon forecasted weather
            RandomlyAdjustWeather(weather, random);

            // Display today's weather
            UserInterface.DisplayWeather(weather.temperature, weather.condition);
            UserInterface.ClearDisplay();

            player.recipe.SetRecipe();
            UserInterface.ClearDisplay();
            if(CheckStockIngredients(player) == false)
            {
                return;
            }
            player.pitcher.FillPitcher(player.recipe, player);

            amountOfPeople = random.Next(5, 20);

            // Run through however many people come to the stand that day
            for (int i = 0; i < amountOfPeople; i++)
            {
                customers.Add(new Customer(random, weather, player.recipe));

                CheckStockCups(player);

                if (customers[i].wantsLemonade == true && player.pitcher.cupsInPitcher > 0)
                {
                    player.pitcher.PourAGlass(player);
                    player.wallet.Money += player.recipe.pricePerGlass;
                }
                else if (customers[i].wantsLemonade == true && player.pitcher.cupsInPitcher <= 0)
                {
                    if (CheckStockIngredients(player) == false)
                    {
                        return;
                    }
                    UserInterface.AlertToNewPitcher();
                    player.pitcher.FillPitcher(player.recipe, player);
                    player.pitcher.PourAGlass(player);
                    player.wallet.Money += player.recipe.pricePerGlass;
                }

                UserInterface.CustomerStopsByShop(customers[i].name, customers[i].wantsLemonade);
                UserInterface.ClearDisplay();
            }

            EndOfDayResponsibilities(player);
        }

        public void RandomlyAdjustWeather(Weather weather, Random random)
        {
            weather.temperature = weather.temperature + random.Next(-6, 6);
            if (weather.temperature < 32)
            {
                weather.condition = weather.weatherConditions[random.Next(1, 3)];
            }
            else
            {
                weather.condition = weather.weatherConditions[random.Next(0, 2)];
            }
        }

        public bool CheckStockIngredients(Player player)
        {
            if (player.inventory.lemons.Count() < player.recipe.amountOfLemons || player.inventory.sugarCubes.Count() < player.recipe.amountOfSugarCubes || player.inventory.iceCubes.Count() < player.recipe.amountOfIceCubes)
            {
                UserInterface.StoreIsSoldOut("lemonade");
                UserInterface.DisplayDailyTotals(0, player.wallet.Money, player.name);
                UserInterface.ClearDisplay();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckStockCups(Player player)
        {
            if (player.inventory.cups.Count() <= 0)
            {
                UserInterface.StoreIsSoldOut("cups");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EndOfDayResponsibilities(Player player)
        {
            dailyProfitOrLoss = player.wallet.Money - startOfDayCash;

            UserInterface.DisplayDailyTotals(dailyProfitOrLoss, player.wallet.Money, player.name);

            player.pitcher.EmptyPitcher();
            UserInterface.ClearDisplay();
        }
    }
}