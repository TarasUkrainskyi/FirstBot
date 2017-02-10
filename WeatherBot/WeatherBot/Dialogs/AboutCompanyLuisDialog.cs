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
using WeatherBot.Parametres;

namespace WeatherBot.Dialogs
{    
    public partial class LuisDialog : LuisDialog<object>
    {
        CompanyModel companyModel = new CompanyModel();

        [LuisIntent("AboutThinkmobiles")]
        public async Task ProcessAboutThinkmobiles(IDialogContext context, LuisResult result)
        {
            companyModel.ParseLuisResult(result);

            PromptDialog.Confirm(context, ChoiceAboutCompany,
                "Do you want to choice dialog to about company dialog?");

            //await context.PostAsync("Intent: AboutThinkmobiles\n\n Answer: empty AboutThinkmobiles luis");

            //context.Wait(MessageReceived);
        }

        private async Task ChoiceAboutCompany(IDialogContext context, IAwaitable<bool> result)
        {
            var answer = await result;

            if (answer)
            {
                context.Call(new AboutCompanyDialog(companyModel), AboutCompanyDialogDone);
            }
            else
            {
                await context.PostAsync("You stayed in the same luis dialog");

                context.Wait(MessageReceived);
            }
        }

        private async Task AboutCompanyDialogDone(IDialogContext context, IAwaitable<CompanyModel> result)
        {
            await context.PostAsync("You leave from about company dialog");
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
    }
}