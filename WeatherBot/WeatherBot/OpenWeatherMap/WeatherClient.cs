using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WeatherBot.OpenWeatherMap
{
    public class WeatherClient
    {
        public string AppID { get; set; } = "";

        private HttpClient cli = new HttpClient();
        public WeatherClient(string AppID)
        {
            this.AppID = AppID;
        }

        public async Task<WeatherRecord[]> Forecast(string city)
        {
            try
            {
                var res = await cli.GetStringAsync($"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&mode=json&units=metric&cnt=7&APPID={AppID}");
                var f = new List<WeatherRecord>();
                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                string cityName = x.city.name;

                if (city.ToLower().CompareTo(cityName.ToLower()) != 0)
                {
                    f.Add(new WeatherRecord()
                    {
                        City = cityName
                    });

                    return f.ToArray();
                }
                 

                foreach (var z in x.list)
                {
                    f.Add(new WeatherRecord()
                    {
                        When = Convert((long)z.dt),
                        Temp = z.temp.day,
                        Pressure = z.pressure,
                        Humidity = z.humidity,
                        City = cityName
                    });
                }

                return f.ToArray();
            }
            catch
            {
                return new List<WeatherRecord>().ToArray();
            }            
            
        }
        private DateTime Convert(long x)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(x).ToLocalTime();
            return dtDateTime;
        }

    }
}