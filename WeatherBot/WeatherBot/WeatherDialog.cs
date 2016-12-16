//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Connector;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using WeatherBot.Enums;

//namespace WeatherBot
//{
//    public class WeatherDialog : IDialog<WeatherParam>
//    {
//        WeatherParam weatherParam = new WeatherParam();

//        public static Task StartAsync(IDialogContext context)
//        {
//            context.Wait(MessageReceivedAsync);
//        }

//        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<Activity> argument)
//        {
//            var message = await argument;
//            var repl = message.CreateReply(message.Text);
//            await context.PostAsync(repl);
//            context.Wait(MessageReceivedAsync);
//        }

//        string NextTo(string[] str, string pat)
//        {
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (str[i] == pat) return str[i + 1];
//            }

//            return string.Empty;
//        }

//        private async Task<string> Reply(string msg)
//        {
//            var a = msg.ToLower().Split(' ');

//            if (a.Contains("help")) return "This is a simple wheather bot. Examples of commands include: temperature today, pressure tomorrow in Uzhgorod, humidity today in Kyiv";
//            if (a.Contains("temperature")) weatherParam.AlsoMeasure(Measurement.Temp);
//            if (a.Contains("humidity")) weatherParam.AlsoMeasure(Measurement.Humidity);
//            if (a.Contains("pressure")) weatherParam.AlsoMeasure(Measurement.Pressure);
//            if (a.Contains("today")) { weatherParam.Today(); }
//            if (a.Contains("tomorrow")) { weatherParam.Tomorrow(); }
//            if (NextTo(a, "in").CompareTo(string.Empty) != 0) { weatherParam.Location = NextTo(a, "in"); }

//            return await weatherParam.BuildResult();
//        }
//    }
//}