using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.Enums;

namespace WeatherBot
{
    [Serializable]
    public class WeatherDialog : IDialog<WeatherParam>
    {
        WeatherParam weatherParam = new WeatherParam();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Contains("subscribe"))
            {
                //PromptDialog.Confirm(context, Subscribe, $"Do you want to subscribe to weather into in {weatherParam.Location}?");
                context.Done(weatherParam);
            }
            else
            {
                var repl = await Reply(message.Text);
                await context.PostAsync(repl);
                context.Wait(MessageReceivedAsync);
            }            
        }

        //private async Task Subscribe(IDialogContext context, IAwaitable<bool> result)
        //{
        //    var answer = await result;

        //    if (answer)
        //    {
        //        await context.PostAsync("You are subscribe");
        //    }
        //    else
        //    {
        //        await context.PostAsync("Subscribtion cancelled");
        //    }

        //    context.Wait(MessageReceivedAsync);
        //}

        string NextTo(string[] str, string pat)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == pat) return str[i + 1];
            }

            return string.Empty;
        }

        private async Task<string> Reply(string msg)
        {
            var a = msg.ToLower().Split(' ');

            if (a.Contains("help")) return "This is a simple wheather bot. Examples of commands include: temperature today, pressure tomorrow in Uzhgorod, humidity today in Kyiv";
            if (a.Contains("temperature")) weatherParam.AlsoMeasure(Measurement.Temp);
            if (a.Contains("humidity")) weatherParam.AlsoMeasure(Measurement.Humidity);
            if (a.Contains("pressure")) weatherParam.AlsoMeasure(Measurement.Pressure);
            if (a.Contains("today")) { weatherParam.Today(); }
            if (a.Contains("tomorrow")) { weatherParam.Tomorrow(); }
            if (NextTo(a, "in").CompareTo(string.Empty) != 0) { weatherParam.Location = NextTo(a, "in"); }

            return await weatherParam.BuildResult();
        }
    }
}