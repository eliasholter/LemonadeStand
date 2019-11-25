using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        Random random;
        int amountOfPeople;
        public Weather weather;
        public List<Customer> customers;

        public Day(Player player)
        {
            weather = new Weather();
            customers = new List<Customer>();
            random = new Random();
            amountOfPeople = random.Next(10, 50);

            for(int i = 0; i < amountOfPeople; i++)
            {
                customers.Add(new Customer());
                if (weather.temperature < random.Next(35, 50) || player.recipe.pricePerGlass > random.NextDouble())
                {
                    customers[i].wantsLemonade = false;
                }

                if(weather.condition == weather.weatherConditions[random.Next(0, 3)])
                {
                    customers[i].wantsLemonade = false;
                }

                if(customers[i].wantsLemonade == true)
                {
                    player.pitcher.PourAGlass();
                }
            }
        }
    }
}
