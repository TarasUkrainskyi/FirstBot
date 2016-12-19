using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.OpenWeatherMap;

namespace WeatherBot.Dialogs
{
    [Serializable]
    [LuisModel("384d3ab0-a5d4-4fd0-98b6-cb4336bdb37d", "a6e657a06a404f58bdb99a11af6083bb")]
    public class WeatherLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task ProcessNone(IDialogContext context, LuisResult result)
        {
            var message = "Sorry, I couldn't understand you";

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetHelp")]
        public async Task ProcessGetHelp(IDialogContext context, LuisResult result)
        {
            var message = "I'm a simple weather bot.\n\n" +
                "\"What is the weather like in Uzhgorod today?\"";

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Thanks")]
        public async Task ProcessThanks(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                {
                    "Never mind",
                    "You are welcome!",
                    "I'm here to server",
                    "Happy to be useful"
                };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetWeather")]
        public async Task ProcessGetWeather(IDialogContext context, LuisResult result)
        {
            var parameter = "temperature";
            var location = "Uzhgorod";
            DateTime date = DateTime.Today.Date;

            EntityRecommendation entityConteiner;
            if (result.TryFindEntity("builtin.geography.city", out entityConteiner))
            {
                location = entityConteiner.Entity;
            }

            if (result.TryFindEntity("builtin.datetime.date", out entityConteiner))
            {
                DateTime.TryParse(entityConteiner?.Resolution?.SingleOrDefault().Value, out date);
            }

            if (result.TryFindEntity("parameter", out entityConteiner))
            {
                parameter = entityConteiner.Entity;
            }

            WeatherClient WeatherClient = new WeatherClient();
            context.Wait(MessageReceived);
        }

        [LuisIntent("GetHelpEasyERP")]
        public async Task ProcessGetHelpEasyERP(IDialogContext context, LuisResult result)
        {
            //context.Activity.tex
            var messages = new string[]
                {
                    "Never mind",
                    "You are welcome!",
                    "I'm here to server",
                    "Happy to be useful"
                };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }
    }
}