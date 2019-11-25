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
        Random random;
        string name;
        public bool wantsLemonade;


        public Customer()
        {
            possiblePeople = new List<string> { "Seasonally Depressed Young Adult", "Angsty Teenager", "Basic White Chick", "A Ditzy Blonde", "A Man Who Doesn't Need Directions" };
            random = new Random();

            name = possiblePeople[random.Next(0, 5)];
            wantsLemonade = true;
        }
    }
}
