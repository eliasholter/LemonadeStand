using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public static class WeatherAPIHelper
    {

        public static HttpClient ApiClient { get; set; } 

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
        }
    }
}
