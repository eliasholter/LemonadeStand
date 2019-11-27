using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        public int cupsInPitcher;

        public Pitcher()
        {
            cupsInPitcher = 0;
        }

        public void FillPitcher(Recipe currentRecipe, Player user)
        {
            user.inventory.RemoveLemonsFromInventory(currentRecipe.amountOfLemons);
            user.inventory.RemoveSugarCubesFromInventory(currentRecipe.amountOfSugarCubes);
            user.inventory.RemoveIceCubesFromInventory(currentRecipe.amountOfIceCubes);
            cupsInPitcher = 12;
        }

        public void PourAGlass(Player user)
        {
            user.inventory.RemoveCupFromInventory();
            cupsInPitcher --;
        }

        public void EmptyPitcher()
        {
            cupsInPitcher = 0;
        }
    }
}
