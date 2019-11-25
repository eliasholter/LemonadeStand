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

        public Game()
        {
            player = new Player();
            store = new Store();
            days = new List<Day>();
            currentDay = 1;
            for(int i = 0; i < 7; i++)
            {
                days.Add(new Day(player));
                store.SellCups(player);
                store.SellLemons(player);
                store.SellSugarCubes(player);
                currentDay ++;
            }
        }
    }
}
