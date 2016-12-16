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
                StateClient stateClient = activity.GetStateClient();
                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                var WeatherParamTemp = userData.GetProperty<WeatherParam>("weather");
                if (WeatherParamTemp != null)
                    weatherParam = WeatherParamTemp;
              
                var repl = await Reply(activity.Text);
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));                
                Activity reply = activity.CreateReply(repl);
                userData.SetProperty<WeatherParam>("weather", weatherParam);
                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
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