using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        Player player;
        Store store;
        List<Day> days;
        List<Weather> weeklyForecast;
        int gameLength;

        public Game()
        {
            player = new Player();
            store = new Store();
            days = new List<Day>();
            weeklyForecast = new List<Weather>();
            gameLength = UserInterface.DetermineGameLength();
            UserInterface.ClearDisplay();

            for (int i = 0; i < gameLength; i++)
            {
                GenerateWeeklyForecast();

                for (int j = 0; j < 7; j++)
                {
                    // Display User Inventory
                    UserInterface.DisplayInventory(player.inventory.lemons.Count(), player.inventory.sugarCubes.Count(), player.inventory.iceCubes.Count(), player.inventory.cups.Count());
                    UserInterface.ClearDisplay();
                    RunStorePhase();
                    UserInterface.ClearDisplay();
                    days.Add(new Day(player, weeklyForecast[j]));
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

        public void GenerateWeeklyForecast()
        {
            for(int i = 0; i < 7; i++)
            {
                weeklyForecast.Add(new Weather()); // For some reason is only generating randomly when stepping through, otherwise it just fills all spaces with same weather object
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
