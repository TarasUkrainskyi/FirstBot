using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            weatherParam.ParseLuisResult(result);

            PromptDialog.Confirm(context, ChoiceWeatherDialog,
                "Do you want to choice dialog to weather dialog?");
                       

            //var message = await weatherParam.BuildResultOnDate();

            //await context.PostAsync("Intent: GetWeather\n\n Answer: " + message);

            //await context.PostAsync("Intent: GetWeather\n\n Answer: empty weather luis");

            //context.Wait(MessageReceived);
        }

        private async Task ChoiceWeatherDialog(IDialogContext context, IAwaitable<bool> result)
        {
            var answer = await result;

            if (answer)
            {
                //choice dialog here
                //await context.PostAsync("You are choice dialog to weather dialog");
                context.Call(new WeatherDialog(weatherParam), WeatherDialogDone);//, "message", CancellationToken.None);
                //await (new WeatherDialog(weatherParam)).StartAsync(context);
            }
            else
            {
                await context.PostAsync("You stayed in the same luis dialog");

                context.Wait(MessageReceived);
            }            
        }

        private async Task WeatherDialogDone(IDialogContext context, IAwaitable<WeatherParam> result)
        {
            await context.PostAsync("You leave from weather dialog");
            var weatherParam = await result;
            var messageHandled = weatherParam.LastQuery;
            var tasks = this.services.Select(s => s.QueryAsync(messageHandled, CancellationToken.None)).ToArray();
            var luisResult = await Task.WhenAll(tasks);
            var winner = this.BestResultFrom(luisResult.Select(b => new LuisServiceResult(b, BestIntentFrom(b), this.services.FirstOrDefault())));

            IntentActivityHandler handler = null;

            if (this.handlerByIntent == null)
            {
                this.handlerByIntent = new Dictionary<string, IntentActivityHandler>(GetHandlersByIntent());
            }

            if (winner == null || !this.handlerByIntent.TryGetValue(winner.BestIntent.Intent, out handler))
            {
                handler = this.handlerByIntent[string.Empty];
            }

            if (handler != null)
            {
                await handler(context, null, winner?.Result);
            }
        }

        private async Task WeatherDialogDone(IDialogContext context, IAwaitable<string> result)
        {
            var messageHandled = await result;
            var tasks = this.services.Select(s => s.QueryAsync(messageHandled, CancellationToken.None)).ToArray();
            var luisResult = await Task.WhenAll(tasks);
            var winner = this.BestResultFrom(luisResult.Select(b => new LuisServiceResult(b, BestIntentFrom(b), (ILuisService)this)));

            IntentActivityHandler handler = null;

            if (this.handlerByIntent == null)
            {
                this.handlerByIntent = new Dictionary<string, IntentActivityHandler>(GetHandlersByIntent());
            }

            if (winner == null || !this.handlerByIntent.TryGetValue(winner.BestIntent.Intent, out handler))
            {
                handler = this.handlerByIntent[string.Empty];
            }

            if (handler != null)
            {
                await handler(context, null, winner?.Result);
            }
        }

        //protected virtual LuisServiceResult BestResultFrom1(IEnumerable<LuisResult> results)
        //{
        //    var winners = from result in results
        //                  let resultWinner = BestIntentFrom(result)
        //                  where resultWinner != null
        //                  select new LuisServiceResult(result, resultWinner, (ILuisService)this);
        //    return winners.MaxBy(i => i.BestIntent.Score ?? 0d);
        //}

        //protected override LuisServiceResult BestResultFrom2.0(IEnumerable<LuisResult> results)
        //{
        //    var winners = from result in results
        //                  let resultWinner = BestIntentFrom(result)
        //                  where resultWinner != null
        //                  select new LuisServiceResult(result, resultWinner);
        //    var nonNoneWinner = winners.Where(i => i.BestIntent.Intent != "None").MaxBy(i => i.BestIntent.Score ?? 0d);
        //    return nonNoneWinner ?? winners.MaxBy(i => i.BestIntent.Score ?? 0d);
        //}

        //protected override LuisServiceResult BestResultFrom2.1(IEnumerable<LuisResult> results)
        //{
        //    var allResults =
        //        from result in results
        //        from intent in result.Intents
        //        select new LuisServiceResult(result, intent);
        //    var nonNoneWinner = allResults.Where(i => string.IsNullOrEmpty(i.BestIntent.Intent) == false).MaxBy(i => i.BestIntent.Score ?? 0d);
        //    return nonNoneWinner ?? allResults.MaxBy(i => i.BestIntent.Score ?? 0d);
        //}

        //protected override IDictionary<string, IntentActivityHandler> GetHandlersByIntent()
        //{
        //    var classCollection = AppDomain.CurrentDomain.GetAssemblies()
        //                .SelectMany(assembly => assembly.GetTypes())
        //                .Where(type => type.IsSubclassOf(typeof(BaseForm)));
        //    List<KeyValuePair<string, IntentActivityHandler>> handler = new List<KeyValuePair<string, IntentActivityHandler>>();
        //    foreach (var item in classCollection)
        //    {
        //        handler.AddRange(MyLuisDialog.EnumerateHandlers(Activator.CreateInstance(item)).ToList());
        //    }
        //    return handler.ToDictionary(kv => kv.Key, kv => kv.Value);
        //}
    }
}