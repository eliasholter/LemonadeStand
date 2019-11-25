using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        string condition;
        int temperature;
        Random random;
        List<string> weatherConditions;

        public Weather()
        {
            weatherConditions = new List<string>{ "Sunny", "Rainy", "Cloudy", "Snowmaggedon"};
        }

        public void GenerateWeather()
        {
            random = new Random();
            temperature = random.Next(5, 65);
            if(temperature <= 32)
            {
                condition = weatherConditions[random.Next(0, 4)];
            }
            else
            {
                condition = weatherConditions[random.Next(0, 3)];
            }
        }
    }
}
