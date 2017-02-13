using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
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
    public class CompanyParam
    {
        public static IForm<CompanyParam> BuildForm()
        {
            return new FormBuilder<CompanyParam>()
                .Message("Welcome to dialog about company")
                .Build();
        }

        [Prompt("Please enter location to get in")]
        public string Location { get; set; }

        public DateTime When { get; set; }
        
        public Measurement MeasurementType { get; set; }

        public string LastQuery { get; set; }

        public CompanyParam()
        {
            Location = string.Empty;
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

            if (string.IsNullOrEmpty(Location))
                return "Please, specify in which locality you want to know the weather\n\n Example answer: in Uzhhorod";

            var forecastArray = await weatherClient.Forecast(Location);
            var forecast = forecastArray.SingleOrDefault(f => f.When.Date == When.Date);           

            StringBuilder stringBuilder = new StringBuilder();

            if (forecast != null)
            {
                Location = forecast.City;

                if (this.Measure(Measurement.Temp))
                {
                    stringBuilder.Append($"The temperature on {forecast.Date} in {Location} is {forecast.Temp}\n\n");
                }
                if (this.Measure(Measurement.Pressure))
                {
                    stringBuilder.Append($"The pressure on {forecast.Date} in {Location} is {forecast.Pressure}\n\n");
                }
                if (this.Measure(Measurement.Humidity))
                {
                    stringBuilder.Append($"The humidity on {forecast.Date} in {Location} is {forecast.Humidity}\n\n");
                }
                if (stringBuilder.Length == 0) return "Sorry, empty or unknown parameter.\n\n";
                else return stringBuilder.ToString();
            }
            else
            {
                stringBuilder.Append($"Sorry, I was not able to get forecast.\n\n Perhaps, Didn't have you correctly written name city!\n\n You input {Location}, perhaps, you meant {forecastArray.FirstOrDefault().City}");
                return stringBuilder.ToString();
            }            
        }

        string NextTo(string[] str, string pat)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == pat) return str[i + 1];
            }

            return string.Empty;
        }

        public void ParseLuisResult(LuisResult luisResult)
        {
            var parameter = string.Empty;
            var location = string.Empty;
            DateTime date = DateTime.MinValue;

            EntityRecommendation entityConteiner;
            if (luisResult.TryFindEntity("builtin.geography.city", out entityConteiner))
            {
                location = entityConteiner.Entity;
            }

            if (luisResult.TryFindEntity("city", out entityConteiner))
            {
                location = entityConteiner.Entity;
            }

            if (luisResult.TryFindEntity("builtin.datetime.date", out entityConteiner))
            {
                DateTime.TryParse(entityConteiner?.Resolution?.SingleOrDefault().Value, out date);
            }

            if (luisResult.TryFindEntity("parameter", out entityConteiner))
            {
                luisResult.Entities.Where(item => item.Type == "parameter").ToList().ForEach(e => parameter += (" " + e.Entity));
            }

            var a = luisResult.Query.ToLower().Split(' ');

            if (date != DateTime.MinValue)
            {
                When = date;
            }              
            else
            {
                if (a.Contains("today")) { Today(); }
                if (a.Contains("tomorrow")) { Tomorrow(); }
            }

            if (!string.IsNullOrEmpty(location))
                Location = location;
            else
                if (NextTo(a, "in").CompareTo(string.Empty) != 0) { Location = NextTo(a, "in"); }

            if (parameter.Contains("temp"))
            {
                AlsoMeasure(Measurement.Temp);
            }
            else
            {
                if (a.Contains("temperature")) { AlsoMeasure(Measurement.Temp); }
                if (a.Contains("weather")) { AlsoMeasure(Measurement.Temp); }
            }

            if (parameter.Contains("pres"))
            {
                AlsoMeasure(Measurement.Pressure);
            }
            else
            {
                if (a.Contains("pressure")) { AlsoMeasure(Measurement.Pressure); }
            }                

            if (parameter.Contains("humid"))
            {
                AlsoMeasure(Measurement.Humidity);
            }
            else
            {
                if (a.Contains("humidity")) { AlsoMeasure(Measurement.Humidity); }
            }
        }
    }
}