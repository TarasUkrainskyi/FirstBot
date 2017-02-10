using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.Dialogs;
using WeatherBot.Enums;
using WeatherBot.OpenWeatherMap;

namespace WeatherBot
{
    [Serializable]
    public class WeatherDialog : IDialog<WeatherParam>
    {
        WeatherParam _weatherParam = new WeatherParam();

        public WeatherDialog(WeatherParam weatherParam)
        {
            _weatherParam = weatherParam;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var result = await _weatherParam.BuildResultOnDate();
            await context.PostAsync(result);
            //PromptDialog.Text(result);
            context.Wait(MessageReceivedAsync);
        }
                
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Contains("subscribe"))
            {
                //PromptDialog.Confirm(context, Subscribe, $"Do you want to subscribe to weather into in {weatherParam.Location}?");
                context.Done(_weatherParam);
            }
            else
            {
                var repl = await Reply(message.Text);

                if (string.IsNullOrEmpty(repl))
                {

                    //await (new LuisDialog()).StartAsync(context);
                    _weatherParam.LastQuery = message.Text;
                    context.Done(_weatherParam);
                }
                else
                {
                    await context.PostAsync(repl);

                    context.Wait(MessageReceivedAsync);
                }
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
            bool isDone = true;
            _weatherParam.MeasurementType = Measurement.None;

            if (a.Contains("help"))
            {
                isDone = false;
                return "This is a simple wheather bot. Examples of commands include: temperature today, pressure tomorrow in Uzhgorod, humidity today in Kyiv";
            }
            if (a.Contains("temperature")) { isDone = false; _weatherParam.AlsoMeasure(Measurement.Temp); }
            if (a.Contains("weather")) { isDone = false; _weatherParam.AlsoMeasure(Measurement.Temp); }
            if (a.Contains("humidity")) { isDone = false; _weatherParam.AlsoMeasure(Measurement.Humidity); }
            if (a.Contains("pressure")) { isDone = false; _weatherParam.AlsoMeasure(Measurement.Pressure); }
            if (a.Contains("today")) { isDone = false; _weatherParam.Today(); }
            if (a.Contains("tomorrow")) { isDone = false; _weatherParam.Tomorrow(); }
            if (NextTo(a, "in").CompareTo(string.Empty) != 0) { isDone = false; _weatherParam.Location = NextTo(a, "in"); }

            if (_weatherParam.MeasurementType == Measurement.None)
                _weatherParam.MeasurementType = Measurement.Temp;

            if (isDone)
            {
                WeatherClient weatherClient = new WeatherClient("0cdba8c6da79d5a786f2944ce5bd4ea8");

                var forecastArray = await weatherClient.Forecast(msg);
                var forecast = forecastArray.SingleOrDefault(f => f.When.Date == _weatherParam.When.Date);

                if (forecast != null)
                {
                    _weatherParam.Location = msg;
                    return await _weatherParam.BuildResultOnDate();
                }                    
            }

            return isDone ? string.Empty : await _weatherParam.BuildResultOnDate();
        }
    }
}