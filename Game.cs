using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        Random random;
        Player player;
        Store store;
        List<Day> days;
        List<Weather> weeklyForecast;
        int gameLength;

        public Game()
        {
            player = new Player();
            store = new Store();
            random = new Random();
            days = new List<Day>();
            weeklyForecast = new List<Weather>();
            gameLength = UserInterface.DetermineGameLength();
            UserInterface.ClearDisplay();

            RunWeek();
        }

        public void RunWeek()
        {
            for (int i = 0; i < gameLength; i++)
            {
                GenerateWeeklyForecast(random);

                UserInterface.DisplayForecast(weeklyForecast);
                UserInterface.ClearDisplay();

                for (int j = 0; j < 7; j++)
                {
                    // Display User Inventory
                    UserInterface.DisplayInventory(player.inventory.lemons.Count(), player.inventory.sugarCubes.Count(), player.inventory.iceCubes.Count(), player.inventory.cups.Count());
                    UserInterface.ClearDisplay();

                    // Go to store for the day
                    RunStorePhase();
                    UserInterface.ClearDisplay();

                    // Run the stand for one day 
                    days.Add(new Day(player, random));

                    // Check if player is broke, end game if so
                    if (IsWalletEmpty() == true)
                    {
                        UserInterface.AllOutOfMoney(player.name);
                        return;
                    }
                }

                ClearForecast();
            }
        }

        public void RunStorePhase() // Here I used the SOLID principle of Single Responsibility by making a separate method for the phase of the game where the player visits the store
        {
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
            store.SellCups(player);
        }

        public void GenerateWeeklyForecast(Random random)
        {
            for(int i = 0; i < 7; i++)
            {
                weeklyForecast.Add(new Weather(random)); 
            }
        }

        public bool IsWalletEmpty()
        {
            if (player.wallet.Money <= 0 && (player.inventory.lemons.Count() == 0 || player.inventory.sugarCubes.Count() == 0 || player.inventory.cups.Count() == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearForecast()
        {
            while(weeklyForecast.Count() != 0)
            {
                weeklyForecast.Clear();
            }
        }
    }
}
