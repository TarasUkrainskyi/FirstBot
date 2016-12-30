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
    [Serializable]
    [LuisModel("384d3ab0-a5d4-4fd0-98b6-cb4336bdb37d", "a6e657a06a404f58bdb99a11af6083bb")]
    public partial class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task ProcessNone(IDialogContext context, LuisResult result)
        {
            var message = "Sorry, I couldn't understand you";

            await context.PostAsync("Intent: None\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }
        
        [LuisIntent("Hello")]
        public async Task ProcessHello(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                 {
                    "Hello!",
                    "Hi!",
                    "Welcome!",
                    "Good day!",
                    "Good to see you!",
                    "Hey."
                 };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync("Intent: Hello\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Ok")]
        public async Task ProcessOk(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                 {
                    "Ok =)",
                    "You are welcome!",
                    "No problem!",
                    "what can help else?"
                 };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync("Intent: Ok\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetHelp")]
        public async Task ProcessGetHelp(IDialogContext context, LuisResult result)
        {
            EntityRecommendation entityRecommendation;
            List<EntityRecommendation> help = new List<EntityRecommendation>();

            if (result.TryFindEntity("help", out entityRecommendation))
            {
                help = result.Entities.Where(item => item.Type == "help").ToList();
            }

            //var message = "I'm a Thinkmobiles's bot.\n\n" +
            //    "I can tell you about the products of our company EasyERP\n\n" +
            //    "and provide links to the information you need\n\n" +
            //    "for example:\n\n" +
            //    "\"Where can I download source code?\"";

            var message = "I'm a Thinkmobiles's bot.\n\n" +
                "I can tell you about the products of our company\n\n" +
                "and provide links to the information you need\n\n" +
                "for example:\n\n" +
                "\"Where can I ...?\"";

            await context.PostAsync("Intent: GetHelp\n\n Answer: " + message);

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

            await context.PostAsync("Intent: Thanks\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Sorry")]
        public async Task ProcessSorry(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                {
                    "Sorry",
                    "Sorry!",
                    "Sorry!!",
                    "Sorry!!!"
                };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync("Intent: Sorry\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Goodbye")]
        public async Task ProcessGoodbye(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                {
                    "Goodbye",
                    "Bye!",
                    "Bye-Bye",
                    "Happy new year!"
                };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync("Intent: Goodbye\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("BadBot")]
        public async Task ProcessBadBot(IDialogContext context, LuisResult result)
        {
            var messages = new string[]
                {
                    "Bad man, relax!",
                    "Bad little man!",
                    "Relax!",
                    "Сalm down!",
                    "Take it easy!"
                };

            var message = messages[(new Random()).Next(messages.Count() - 1)];

            await context.PostAsync("Intent: BadBot\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("MyLocation")]
        public async Task ProcessMyLocation(IDialogContext context, LuisResult result)
        {
            string message = "Intent: MyLocation\n\n Answer: We are based in Ukraine";

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }
        
        [LuisIntent("GetLanguage")]
        public async Task ProcessGetLanguage(IDialogContext context, LuisResult result)
        {
            //string message = @"It's available only in English, if needed, we may translate it for you into other language";
            string message = @"Intent: GetLanguage\n\n Answer: I communicate in English only";

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetNameCompany")]
        public async Task ProcessGetNameCompany(IDialogContext context, LuisResult result)
        {
            //string message = @"It's available only in English, if needed, we may translate it for you into other language";
            string message = @"Intent: GetNameCompany\n\n Answer: Thinkmobiles";

            await context.PostAsync(message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Creator")]
        public async Task ProcessCreator(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: Creator\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Wrong")]
        public async Task ProcessWrong(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: Wrong\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }
    }
}