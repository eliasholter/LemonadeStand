﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        int amountOfPeople;
        bool canMakePitcher;
        double startOfDayCash;
        double dailyProfitOrLoss;
        public Weather weather;
        public List<Customer> customers;

        public Day(Player player, Random random)
        {
            weather = new Weather(random);
            customers = new List<Customer>();
            startOfDayCash = player.wallet.Money;

            RunDay(player, random);
        }

        public void RunDay(Player player, Random random)
        {
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
                    player.pitcher.FillPitcher(player.recipe, player);
                    player.pitcher.PourAGlass(player);
                    player.wallet.Money += player.recipe.pricePerGlass;
                }

                UserInterface.CustomerStopsByShop(customers[i].name, customers[i].wantsLemonade);
                UserInterface.ClearDisplay();
            }

            EndOfDayResponsibilities(player);
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