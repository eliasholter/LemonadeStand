using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerGlass;

        public Recipe()
        {

        }

        public void SetRecipe()
        {
            amountOfLemons = UserInterface.GetNumberOfIngredients("lemons");
            amountOfSugarCubes = UserInterface.GetNumberOfIngredients("sugar cubes");
            amountOfIceCubes = UserInterface.GetNumberOfIngredients("ice cubes");
            pricePerGlass = UserInterface.SetPricePerGlass();
        }
    }
}
