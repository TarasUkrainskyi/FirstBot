using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WeatherBot.Dialogs
{
    [Serializable]
    [LuisModel("384d3ab0-a5d4-4fd0-98b6-cb4336bdb37d", "ThinkBotLuis")]
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
    }
}