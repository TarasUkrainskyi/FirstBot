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
using WeatherBot.Parametres;

namespace WeatherBot
{
    [Serializable]
    public class AboutCompanyDialog : IDialog<CompanyModel>
    {
        CompanyModel _companyModel = new CompanyModel();

        public AboutCompanyDialog(CompanyModel companyModel)
        {
            _companyModel = companyModel;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var result = _companyModel.Reply(_companyModel.LastQuery);
            await context.PostAsync(result);

            context.Wait(MessageReceivedAsync);
        }
                
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            var repl = _companyModel.Reply(message.Text);

            if (string.IsNullOrEmpty(repl))
            {
                _companyModel.LastQuery = message.Text;

                context.Done(_companyModel);
            }
            else
            {
                await context.PostAsync(repl);

                context.Wait(MessageReceivedAsync);
            }
        }

        //private async Task<string> Reply(string msg)
        //{
        //    var a = msg.ToLower().Split(' ');
            
        //    string result = string.Empty;

        //    if (a.Contains("help")) { result =  "This is a thinkmobiles bot, about company dialog. Examples of commands include: When company founded?"; }
        //    else if (a.Contains("about") && a.Contains("company")) { result = _companyModel.Name + " - " + _companyModel.AboutCompany; }
        //    else if (a.Contains("about") && a.Contains("think")) { result = "Our company - " + _companyModel.AboutCompany; }
        //    else if (a.Contains("departments") && a.Contains("many")) { result = "Our company have " + _companyModel.Departments.Count + " departments"; }
        //    else if (a.Contains("departments")) { result = _companyModel.Name + " have "; _companyModel.Departments.ForEach(i => result += ", " + i); result += " departments"; }            
        //    else if (a.Contains("employ") && a.Contains("many")) { result = "About " + _companyModel.Employees + " employees"; }
        //    else if (a.Contains("feedback")) { result = "About " + _companyModel.Employees + " employees"; }
        //    else if (a.Contains("founded")) { result = _companyModel.Name + " was founded at " + _companyModel.CreateDate.ToShortDateString(); }
        //    else if (a.Contains("founder") && a.Contains("director") && a.Contains("head")) { result = "Our founder is " + _companyModel.Founder; }
        //    else if (a.Contains("News")) { result = _companyModel.News; }
        //    else result = string.Empty;

        //    return result;
        //}
    }
}