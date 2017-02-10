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
    public partial class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("NoteWork")]
        public async Task ProcessNoteWork(IDialogContext context, LuisResult result)
        {
            string message = @"Please, send me description of your issue (if possible, with screenshots ) on  norbert@easyerp.com";
            
            EntityRecommendation entityConteiner;
            if (result.TryFindEntity("parameters-easyerp", out entityConteiner))
            {
                if (entityConteiner.Entity.Contains("demo"))
                {                    
                    message = @"Please, turn off Adblock or other or other web browser extensions";
                }
            }

            await context.PostAsync("Intent: NoteWork\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("AboutProduct")]
        public async Task ProcessAboutProduct(IDialogContext context, LuisResult result)
        {
            string message = @"This is ERP";

            EntityRecommendation entityConteiner;
            if (result.TryFindEntity("parameters-easyerp", out entityConteiner))
            {
                if (entityConteiner.Entity.Contains("open"))
                {
                    message = @"Yes. You may customize the source code, but it's not alowed to change name of our product";
                }
            }
            await context.PostAsync("Intent: AboutProduct\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetProduct")]
        public async Task ProcessGetProduct(IDialogContext context, LuisResult result)
        {
            string message = @"Please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU";

            await context.PostAsync("Intent: GetProduct\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetSource")]
        public async Task ProcessGetSource(IDialogContext context, LuisResult result)
        {
            string message = @"Please, follow this link http://git.thinkmobiles.com:9000/users/sign_in login: test_easyerp password:12345678";

            await context.PostAsync("Intent: GetSource\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetRepository")]
        public async Task ProcessGetRepository(IDialogContext context, LuisResult result)
        {
            string message = @"We are storing EasyERP's source code on gitlab, here is the link  http://git.thinkmobiles.com:9000/users/sign_in login: test_easyerp password:12345678";

            await context.PostAsync("Intent: GetRepository\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetCost")]
        public async Task ProcessGetCost(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: GetCost\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetDocumentation")]
        public async Task ProcessGetDocumentation(IDialogContext context, LuisResult result)
        {
            var messagesRend = new string[]
                {
                    "We are working on it",
                    "Not yet, we are working on it",
                    "Not yet, soon it will be available",
                    "We are working on it, soon it will be available"
                };

            string message = messagesRend[(new Random()).Next(messagesRend.Count() - 1)];

            await context.PostAsync("Intent: GetDocumentation\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("HelpEasyERP")]
        public async Task ProcessHelpEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: HelpEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetDemoEasyERP")]
        public async Task ProcessGetDemoEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: GetDemoEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("BlogEasyERP")]
        public async Task ProcessBlogEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: BlogEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("CustomizationEasyERP")]
        public async Task ProcessCustomizationEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("RunEasyERP")]
        public async Task ProcessRunEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: RunEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("SourceEasyERP")]
        public async Task ProcessSourceEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: SourceEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("SpecificationsEasyERP")]
        public async Task ProcessSpecificationsEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: SpecificationsEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("OwnershipEasyERP")]
        public async Task ProcessOwnershipEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: OwnershipEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("IntegrationEasyERP")]
        public async Task ProcessIntegrationEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: IntegrationEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetofflineEasyERP")]
        public async Task ProcessGetofflineEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: GetofflineEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("LocalizationEasyERP")]
        public async Task ProcessLocalizationEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: LocalizationEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("CostEasyERP")]
        public async Task ProcessCostEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: CostEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("GetEasyERP")]
        public async Task ProcessGetEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: GetEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("AboutEasyERP")]
        public async Task ProcessAboutEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }

        [LuisIntent("ModulesEasyERP")]
        public async Task ProcessModulesEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }


        [LuisIntent("AddUsersEasyERP")]
        public async Task ProcessAddUsersEasyERP(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: AddUsersEasyERP\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }


        [LuisIntent("SupportUsers")]
        public async Task ProcessSupportUsers(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }
        
        [LuisIntent("TrialVersion")]
        public async Task ProcessTrialVersion(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Intent: TrialVersion\n\n Answer: Empty");

            context.Wait(MessageReceived);
        }
        
        //[LuisIntent("Creator")]
        //public async Task ProcessCreator(IDialogContext context, LuisResult result)
        //{
        //    await context.PostAsync("Intent: Creator\n\n Answer: Empty");

        //    context.Wait(MessageReceived);
        //}
    }
}