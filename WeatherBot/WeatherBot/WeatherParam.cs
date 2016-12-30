using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.Enums;
using WeatherBot.OpenWeatherMap;

namespace WeatherBot
{
    [Serializable]
    public class WeatherParam
    {
        public static IForm<WeatherParam> BuildForm()
        {
            return new FormBuilder<WeatherParam>()
                .Message("Welcome to weather bot")
                .Build();
        }

        [Prompt("Please enter location to get in")]
        public string Location { get; set; }

        public DateTime When { get; set; }
        
        public Measurement MeasurementType { get; set; }

        public WeatherParam()
        {
            Location = "Uzhgorod";
            When = DateTime.Now;
            MeasurementType = Measurement.Temp;
        }

        public void Today()
        {
            When = DateTime.Now;
        }

        public void Tomorrow()
        {
            When = DateTime.Now.AddDays(1);
        }

        public void AlsoMeasure(Measurement M)
        {
            MeasurementType |= M;
        }

        public bool Measure(Measurement M)
        {
            return (M & MeasurementType) > 0;
        }

        public int Offset
        {
            get
            {
                return (int)(((float)(When - DateTime.Now).Hours) / 24.0 + 0.5);
            }
        }

        public async Task<string> BuildResult()
        {
            //API Key OpenWeatherMap = "0cdba8c6da79d5a786f2944ce5bd4ea8"
            WeatherClient weatherClient = new WeatherClient("0cdba8c6da79d5a786f2944ce5bd4ea8");
            var res = await weatherClient.Forecast(Location);
            var r = res[Offset];
            StringBuilder stringBuilder = new StringBuilder();

            if (Measure(Measurement.Temp))
            {
                stringBuilder.Append($"The temperature on {r.Date} in {Location} is {r.Temp}\r\n");
            }
            if (Measure(Measurement.Pressure))
            {
                stringBuilder.Append($"The pressure on {r.Date} in {Location} is {r.Pressure}\r\n");
            }
            if (Measure(Measurement.Humidity))
            {
                stringBuilder.Append($"The humidity on {r.Date} in {Location} is {r.Humidity}\r\n");
            }
            if (stringBuilder.Length == 0) return "I do not understand";
            else return stringBuilder.ToString();
        }

        public async Task<string> BuildResultOnDate()
        {
            //API Key OpenWeatherMap = "0cdba8c6da79d5a786f2944ce5bd4ea8"
            WeatherClient weatherClient = new WeatherClient("0cdba8c6da79d5a786f2944ce5bd4ea8");
            var forecastArray = await weatherClient.Forecast(Location);
            var forecast = forecastArray.SingleOrDefault(f => f.When.Date == When.Date);
            StringBuilder stringBuilder = new StringBuilder();

            if (forecast != null)
            {
                if (Measure(Measurement.Temp))
                {
                    stringBuilder.Append($"The temperature on {forecast.Date} in {Location} is {forecast.Temp}\n\n");
                }
                if (Measure(Measurement.Pressure))
                {
                    stringBuilder.Append($"The pressure on {forecast.Date} in {Location} is {forecast.Pressure}\n\n");
                }
                if (Measure(Measurement.Humidity))
                {
                    stringBuilder.Append($"The humidity on {forecast.Date} in {Location} is {forecast.Humidity}\n\n");
                }
                if (stringBuilder.Length == 0) return "Sorry, empty or unknown parameter.\n\n";
                else return stringBuilder.ToString();
            }
            else
            {
                stringBuilder.Append("Sorry, I was not able to get forecast.\n\n");
                return stringBuilder.ToString();
            }            
        }
    }
}