using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        public string condition;
        public int temperature;
        Random random;
        public List<string> weatherConditions;

        public Weather()
        {
            weatherConditions = new List<string>{ "Rainy", "Sunny", "Cloudy", "Snowmaggedon"};
            GenerateWeather();
        }

        public void GenerateWeather()
        {
            random = new Random();
            temperature = random.Next(5, 65);
            if(temperature < 32)
            {
                condition = weatherConditions[random.Next(1, 3)];
            }
            else
            {
                condition = weatherConditions[random.Next(0, 2)];
            }
        }
    }
}
