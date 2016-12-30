using Microsoft.Bot.Builder.Dialogs;
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

namespace WeatherBot.Dialogs
{
    public partial class LuisDialog : LuisDialog<object>
    {
        WeatherParam weatherParam = new WeatherParam();

        [LuisIntent("GetWeather")]
        public async Task ProcessGetWeather(IDialogContext context, LuisResult result)
        {
            var parameter = string.Empty;
            var location = string.Empty;
            DateTime date = DateTime.MinValue;

            EntityRecommendation entityConteiner;
            if (result.TryFindEntity("builtin.geography.city", out entityConteiner))
            {
                location = entityConteiner.Entity;
            }

            if (result.TryFindEntity("city", out entityConteiner))
            {
                location = entityConteiner.Entity;
            }

            if (result.TryFindEntity("builtin.datetime.date", out entityConteiner))
            {
                DateTime.TryParse(entityConteiner?.Resolution?.SingleOrDefault().Value, out date);
            }

            if (result.TryFindEntity("parameter", out entityConteiner))
            {
                result.Entities.Where(item => item.Type == "parameter").ToList().ForEach(e => parameter += (" " + e.Entity));
            }

            if(date != DateTime.MinValue)
                weatherParam.When = date;

            if(!string.IsNullOrEmpty(location))
                weatherParam.Location = location;            

            if (parameter.Contains("temp"))
            {
                weatherParam.AlsoMeasure(Measurement.Temp);
            }
            if (parameter.Contains("pres"))
            {
                weatherParam.AlsoMeasure(Measurement.Pressure);
            }
            if (parameter.Contains("humid"))
            {
                weatherParam.AlsoMeasure(Measurement.Humidity);
            }

            var message = await weatherParam.BuildResultOnDate();

            await context.PostAsync("Intent: GetWeather\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }        
    }
}