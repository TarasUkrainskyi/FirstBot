using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using WeatherBot.OpenWeatherMap;
using System.Text;
using WeatherBot.Enums;
using Microsoft.Bot.Builder.Dialogs;

namespace WeatherBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity,
                    () =>
                        new WeatherDialog()
                        .ContinueWith<WeatherParam, string>(
                            async (ctx, wpa) =>
                            {
                                var wp = await wpa;
                                return new ChoiceDialog($"Do you want to subscribe to weather in {wp.Location}?", new string[] { "Yes", "No" });
                            })
                        .Do(
                            async (ctx, sta) =>
                            {
                                var s = await sta;

                                if (s.ToLower().CompareTo("yes") == 0)
                                {
                                    await ctx.PostAsync("You are subscribe");
                                }
                                else
                                {
                                    await ctx.PostAsync("Canceled subscribe");
                                }
                            }));
            }
            else
            {
                HandleSystemMessage(activity);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }       

        string NextTo(string[] str, string pat)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == pat) return str[i + 1];
            }

            return string.Empty;
        }

        WeatherParam weatherParam = new WeatherParam();

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

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}