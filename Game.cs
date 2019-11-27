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
        public string name;

        public Game()
        {
            player = new Player();
            store = new Store();
            days = new List<Day>();

            for(int i = 0; i < 7; i++)
            {
                RunStorePhase();
                UserInterface.ClearDisplay();
                days.Add(new Day(player));
                i ++;
            }
        }

        public void RunStorePhase() // Here I used the SOLID principle of Single Responsibility by making a separate method for the phase of the game where the player visits the store
        {
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
            store.SellCups(player);
        }
    }
}
