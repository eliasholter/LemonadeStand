using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        List<string> possiblePeople;
        int chooseFlavor;
        public string name;
        public string flavorProfile;
        public bool wantsLemonade;


        public Customer(Random random)
        {
            possiblePeople = new List<string> { "Seasonally Depressed Young Adult", "Angsty Teenager", "Basic White Girl", "A Ditzy Blonde", "A Man Who Doesn't Need Directions", "Kid Who Knows Everything" };


            chooseFlavor = random.Next(0, 2);
            name = possiblePeople[random.Next(0, 5)];
            wantsLemonade = true;

            if(chooseFlavor == 0)
            {
                flavorProfile = "sweet";
            }
            else if(chooseFlavor == 1)
            {
                flavorProfile = "sour";
            }
        }
    }
}
