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
        int currentDay;
        public string name;

        public Game()
        {
            player = new Player();
            store = new Store();
            days = new List<Day>();
            currentDay = 1;
            for(int i = 0; i < 7; i++)
            {
                RunStorePhase();
                days.Add(new Day(player));
                currentDay ++;
            }
        }

        public void RunStorePhase() 
        {
            store.SellLemons(player);
            store.SellSugarCubes(player);
            store.SellIceCubes(player);
            store.SellCups(player);
        }
    }
}
