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

        [LuisIntent("TechEasyERP")]
        public async Task ProcessTechEasyERP(IDialogContext context, LuisResult result)
        {
            string str = result.Query;

            if ((str.Contains("need") || str.Contains("recommended")) && str.Contains("64"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: x64 system alows more efective usage of vaster amounts of physical and virtual memory compared to x32 based systems, so roughly saying EasyERP runs way faster and better, than it could be on x32 system. ");

            if ((str.Contains("run") || str.Contains("have")) && str.Contains("32"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: I`m affraid it`s not possible. EasyERP was meant for x64 bit operating systems only.");

            if ((str.Contains("run") || str.Contains("have")) && str.Contains("32") && str.Contains("why"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: Well, because EasyERP was meant for x64 bit operating systems only.");

            if ((str.Contains("run") || str.Contains("install") || str.Contains("use")) && str.Contains("64"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: Yes you do. x64 system alows more efective usage of vaster amounts of physical and virtual memory compared to x32 based systems, so roughly saying EasyERP runs way faster and better, than it could be on x32 system. ");

            if (str.Contains("web-based"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: Yeap, it is. You can assure yourself in this simply by following this link https://easyerp.com/ and ckicking on 'Demo' button.");

            if (str.Contains("offline") || str.Contains("desktop"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: You may download it over here https://easyerp.com/download/");

            if (str.Contains("hardware") && str.Contains("own"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: Remember that you can use EasyERP on x64 system only, and in case of running EasyERP on your own server it would be preferable to contact us for further evaluation. ");

            if (str.Contains("run") && str.Contains("easyerp") && str.Contains("my"))
                await context.PostAsync("Intent: TechEasyERP\n\n Answer: It depends on what system you have. Could you please describe me hardware and software aspects your system?");


            context.Wait(MessageReceived);
        }

        [LuisIntent("GetProduct")]
        public async Task ProcessGetProduct(IDialogContext context, LuisResult result)
        {
            string message = @"Please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU";

            await context.PostAsync("Intent: GetProduct\n\n Answer: " + message);

            context.Wait(MessageReceived);
        }

        [LuisIntent("GenQueEasyERP")]
        public async Task ProcessGenQueEasyERP(IDialogContext context, LuisResult result)
        {
            string str = result.Query;

            if (str.Contains("user") && str.Contains("support"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Quantity of users isn`t limited, but in current version only 5 users are for free, every extra user will cost 15 USD (please check out our price list at:  https://easyerp.com/)");

            if (str.Contains("crm") && str.Contains("erp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: It's an ERP, newertheless, it includes CRM and other modules");

            if ((str.Contains("n`t") || str.Contains("not")) && str.Contains("understand"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP is made for all-in-one business management, this includes CRM, inventory manegement, accounting, HR.");

            if (str.Contains("do") && str.Contains("easyerp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: It gives you the possibilty to manage all your business aspects in one program. ");

            if (str.Contains("manufactur") && str.Contains("good"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Yes, anyway, we need to make some customization for your company before starting, please contact our sales team norbert@easyerp.com");

            if (str.Contains("saas") && str.Contains("mean"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: SaaS stands for 'Software as service'. It is a software licensing and delivery model in which software is licensed on a subscription basis and is centrally hosted. We rpovide this service for 15$");

            if (str.Contains("many") && str.Contains("use") && str.Contains("easyerp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: For now EasyERp is still under development and there was`nt official release.");

            if (str.Contains("money") && str.Contains("save"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: It all depends on how many users you are wiiling to connect and if you wish to get some customizations in your EasyERP. ");

            if (str.Contains("analytics") && str.Contains("forecast"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: At the current state of development we have a variety of business analytic reports, that can give you important information. Forecast abilities are still in development.");

            if (str.Contains("data") && str.Contains("manually"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: No, we have powerfull instruments that allow import of products, orders, shipping templates, contancts, and payments from Magento, Shopify or Etsy.");

            if (str.Contains("easyerp") && str.Contains("odoo"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP is better than odoo");

            if (str.Contains("easyerp") && (str.Contains("owner") || str.Contains("creator") || str.Contains("develop")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Owner and developer of EasyERP is 'ThinkMobiles' company.");

            if (str.Contains("operate") && str.Contains("retail") && str.Contains("easyerp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyErp was meant for retail bussiness. You can operate your online store based on different ecommerce platforms right from EasyERP! Or our team can customize EasyERP specially for your bussiness, in this case contact us at: https://easyerp.com/contact-us/. Also you`re able to customize it by yourself.");

            if (str.Contains("another") && str.Contains("proper") && str.Contains("easyerp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Our genuine product you can find only at https://easyerp.com/.");

            if (str.Contains("inventory") && str.Contains("management"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP includes a powerfull multichannel inventory management system.");

            if (str.Contains("demo") && str.Contains("easy"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP is very customizable, you can change it so it will suit your needs. If you have any questions please read the documentation here https://easyerp.com/documentation/");

            if (str.Contains("non-profit") && str.Contains("erp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP is free to use for 5 users.");

            if (str.Contains("ios") || str.Contains("web") && str.Contains("demo"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: You can change the departments in the Settings -> Departments section. ");

            if (str.Contains("suitable") && str.Contains("industries"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP is very customizable, you can change it so it will suit your needs. If you have any questions please read the documentation here https://easyerp.com/documentation/");

            if (str.Contains("different") && str.Contains("quickbook"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP also includes fully functional CRM and HR modules and allows you to manage your online stores, so it covers your bussiness issues more efficiently. ");

            if (str.Contains("client") && str.Contains("have to use") && str.Contains("easyerp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Depends on the nature of your business.");

            if (str.Contains("switch") && str.Contains("another") && str.Contains("erp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Regretfully in current version there is no straightforward possibillity to switch from other ERP/CRM into EasyERP, but we are working on it so this will be available as soon as possible.");

            if (str.Contains("offline") && str.Contains("mode"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Desktop version can work in offline mode, with limited functionality, offcourse. You can download it here https://easyerp.com/download/");

            if (str.Contains("differs") && str.Contains("easyerp") && (str.Contains("erp") || str.Contains("crm") || str.Contains("odoo")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP was meant as all-in-one business management ecosystem that includes decent CRM, inventory manegement, accounting, HR modules, so you`ll benefit from using all listed above modules in one place, with posibility to integrate different ecomerce platforms. Also EasyERP is highly customizable system, so it can satisfy needs of nearly every business, doesn't matter how unique it is. And our prices are more then affordable.");

            if (str.Contains("easyerp") && (str.Contains("special") || str.Contains("exceptional") || str.Contains("benefit") || str.Contains("exclusive") || str.Contains("buy")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERP was meant as all-in-one business management ecosystem that includes decent CRM, inventory manegement, accounting, HR modules, so you`ll benefit from using all listed above modules in one place, with posibility to integrate different ecomerce platforms. Also EasyERP is highly customizable system, so it can satisfy needs of nearly every business, doesn't matter how unique it is.");

            if (str.Contains("easyerp") && str.Contains("awesome"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: We are really pleased you liked our creation =)");

            if (str.Contains("fantastic") && str.Contains("attention"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Thanks a lot for your interest in our product!");

            if (str.Contains("opensource"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Yes, there is an opensource and paid versions of our project");

            if (str.Contains("license"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: AGPL v.3");

            if (str.Contains("agpl v.3"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: yes, we use this license for our software");

            if (str.Contains("agpl v.2"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: no, we use AGPL v.3");

            if (str.Contains("version") && str.Contains("best"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: It depends on the needs of your bussines. If you have small company with limited number of workers and budget 'SaaS' version may suit you well. If your bussiness is rapidly growing or you have a big company it might be a good decision to chose 'Enterprise' version which delivers good customization features specially for your bussiness and support conditions. Be sure to contact us if you have any questions or propositions according acquiring our product at https://easyerp.com/contact-us.");

            if (str.Contains("easyerp") && (str.Contains("n`t") || str.Contains("not")) && str.Contains("fast"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Could you, please, describe me your problem more detailed? Maybe i`ll be able to help you with performance improvement.");

            if (str.Contains("easyerp") && (str.Contains("ugly") || str.Contains("bad")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: You are able to customise UI as you wish through working with our source code on your own. Or we can customize UI of our product as you desire.");

            if (str.Contains("easyerp") && (str.Contains("n`t") || str.Contains("not")) && str.Contains("friend"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: You are able to customise UI as you wish through working with our source code on your own. Or we can customize UI of our product as you desire.");

            if (str.Contains("hire") && (str.Contains("person") || str.Contains("specialist")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Of course it is not mandatory, if you are basically familiar with ERP/CRM systems and IT-products maintaining. Otherwise we can be your IT person! ");

            if (str.Contains("differen") && str.Contains("crm") && str.Contains("erp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: While ERP and CRM systems are highly interlinked there are some pretty visible differences. If CRM is mainly focused on acquiring new leads, clients and working on future purposes in general, then ERP is better at dealing with day-to-day business/company related issues, existing clients and products. So it`s pretty cool to have both of these systems in one place, huh?");

            if (str.Contains("together") && str.Contains("crm") && str.Contains("erp"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: We thought it would be a great idea to create some workspace where you`ll be able to withstand all business managing challenges on your path to intercontinental corporation with billions clients, without constant switching between different business managing decisions and having problems with maintaining or keeping them alltogether in one piece. So we created EasyERP.");

            if (str.Contains("easyerp") && (str.Contains("profit") || str.Contains("revenue")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: EasyERp will provide you with complex decision for managing your business, while having more than fair price. With it you`ll be able to handle all your projects, orders, accounting and ecommerce issues more efficiently and generate leads, attract new clients much faster what in the end will help you achieve new hights and generate more revenue.");

            if (str.Contains("web-base") && str.Contains("version"))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Of course we have. You can assure yourself in this simply by following this link https://easyerp.com/ and ckicking on 'Demo' button.");

            if (str.Contains("erp") && (str.Contains("mean") || str.Contains("is") || str.Contains("stand for") || str.Contains("know") || str.Contains("tell")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Enterprise resource planning (ERP) is the integrated management of core business processes, often in real-time and mediated by software and technology. And in our case it`s complete business management ecosystem that includes decent inventory manegement, accounting, HR, expenses counting modules and great built-in CRM module on top.");

            if (str.Contains("crm") && (str.Contains("mean") || str.Contains("is") || str.Contains("stand for") || str.Contains("know") || str.Contains("tell")))
                await context.PostAsync("Intent: GenQueEasyERP\n\n Answer: Customer relationship management (CRM) is an approach to managing a company's interaction with current and potential future customers which tries to analyze data about customers' history with a company, to improve business relationships with customers, specifically focusing on customer retention, and ultimately to drive sales growth. And in our case that`s great built-in module wich provides you with possibility to effectively manage your leads, future and current clients with a purpose of achieving new hights in your business.");


            context.Wait(MessageReceived);
        }

        //[LuisIntent("AboutThinkmobiles")]
        //public async Task ProcessAboutThinkmobiles(IDialogContext context, LuisResult result)
        //{
        //    string str = result.Query;

        //    if (str.Contains("based"))
        //        await context.PostAsync("Intent: AboutThinkmobiles\n\n Answer: We are based in Ukraine");
                        
        //    context.Wait(MessageReceived);
        //}

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
            string str = result.Query;

            var Entities = result.Entities;

            if (str.Contains("module") && str.Contains("install"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: You can't chose directly which modules to install, but if needed we may customize EasyERP according to your needs.");

            if (str.Contains("turn off HR"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Yes, this option is availiable. Please contact our sales team norbert@easyerp.com.");

            if (str.Contains("change design"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: It`s not possible in stock version for now, but our team can customize EasyERP specially for your, in this case contact us at: https://easyerp.com/contact-us/. Also you`re able to customize it by yourself.");

            if (str.Contains("know more") && str.Contains("customization feature"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: You can customize it by yourself. Our product is open-source and you can customize it as you wish. Just remember that you can`t change the name of our product or resell it to other parties. Also we can customize it for you, if you wish so.");

            if (str.Contains("to customize") && str.Contains("you charge"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Well it depends on your needs. The price is negotiable for now, while project is still under development. If you wish simply customize interface of your version it won`t take much time, so the price will be one, but if you wish to add new modules or integrate third party software further negotiations will be necessary. Anyway contact us at https://easyerp.com/contact-us/ and we`ll be pleased to fullfill your wishes.");

            if (str.Contains("solutions") && str.Contains("business"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Our EasyERP is already highly customizable in 'from the box' condition, but you can customize it even farther as by yourself (through working on our source), or with help from our highly professional team, so our EasyERP will meet all the needs of your business, no matter how unique it can be. For further details, please, contact those guys over there https://easyerp.com/contact-us and they`ll tell you even more.");

            if (str.Contains("customized") && str.Contains("business") || str.Contains("company"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Our EasyERP is already highly customizable in 'from the box' condition, but you can customize it even farther as by yourself (through working on our source), or with help from our highly professional team, so our EasyERP will meet all the needs of your business, no matter how unique it can be. For further details, please, contact those guys over there https://easyerp.com/contact-us and they`ll tell you even more.");

            if (str.Contains("customization") && str.Contains("provide"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Our EasyERP is already highly customizable in 'from the box' condition, but you can customize it even farther as by yourself (through working on our source), or with help from our highly professional team, so our EasyERP will meet all the needs of your business, no matter how unique it can be. For further details, please, contact those guys over there https://easyerp.com/contact-us and they`ll tell you even more.");

            if (str.Contains("customizable"))
                await context.PostAsync("Intent: CustomizationEasyERP\n\n Answer: Our EasyERP is already highly customizable in 'from the box' condition, but you can customize it even farther as by yourself (through working on our source), or with help from our highly professional team, so our EasyERP will meet all the needs of your business, no matter how unique it can be. For further details, please, contact those guys over there https://easyerp.com/contact-us and they`ll tell you even more.");

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
            string str = result.Query;

            if (str.Contains("integrate") && str.Contains("software"))
                await context.PostAsync("Intent: IntegrationEasyERP\n\n Answer: I`m affraid it`s not possible in 'from box' version, but you can integrate desired software by yourself working with our open-source code (which you can get here: https://github.com/EasyERP/EasyERP_open_source). Or our team will gladly do this for you, in this case contact us at: https://easyerp.com/contact-us/.");

            if (str.Contains("import") && str.Contains("data"))
                await context.PostAsync("Intent: IntegrationEasyERP\n\n Answer: I`m affraid, currently such feature isn`t available.");

            if (str.Contains("add") && str.Contains("extension"))
                await context.PostAsync("Intent: IntegrationEasyERP\n\n Answer: Regretfully there is no way to perform this in current version of EasyERP, but we are tirelessly working on it and it will be available as soon as possible.");

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
            string str = result.Query;

            if (str.Contains("much") && str.Contains("cost"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: You can check out our price list on the main page of our product (please follow this link: https://easyerp.com/). But let me tell you, our price are more than affordable.");

            if (str.Contains("cheap") && (str.Contains("sap") || str.Contains("netsuite")))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: EasyERP is a low cost ERP.  It's implementation will  cost you much cheaper.");

            if (str.Contains("pay") && str.Contains("license"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: It is free for five or fewer users.");

            if (str.Contains("send") && str.Contains("offer"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Sure, please write a letter to our sales team with describtion  of your company and what would you like to have in ERP. Sales team e-mail: norbert@easyerp.com");

            if (str.Contains("partner") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: If you have a proposition please contact us here https://easyerp.com/contact-us/");

            if (str.Contains("resell") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: No you can not. You may customize the source code, but it's not allowed to change name of our product and/or resell it to other parties.");

            if (str.Contains("terms") && str.Contains("agreement") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: EasyERP terms of agreement are currently under development. Follow our blog for updates. https://easyerp.com/blog/");

            if (str.Contains("plan") && str.Contains("negotiable"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: We are open to new ideas and alliances. Conact us  here https://easyerp.com/contact-us/ , and maybe we can give you discount.");

            if (str.Contains("pay") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: First you have to choose payment plan which suits you at https://easyerp.com/pricing/#buy_page_form, then fill in all fields and click 'Buy', after that our team will contact you via e-mail and negotiate further details.");

            if (str.Contains("afford") && str.Contains("budget"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Chances are that you can afford EasyERP, for more details about pricing please visit https://easyerp.com/pricing/#buy_page_form ");

            if (str.Contains("bank account") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: It is not mandatory, however you`ll find very usefull to manage your account or multiple accounts through EasyERP while dealing with your bussiness");

            if (str.Contains("erp") && str.Contains("taxable"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Taxes are charged according to tax rates of your country.");

            if (str.Contains("purchase") && str.Contains("module"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Of course it is possible! Please contact our sales team norbert@easyerp.com for further negotiations.");

            if (str.Contains("buy") && str.Contains("version") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: It depends on the needs of your bussines. If you have small company with limited number of workers and budget 'SaaS' version may suit you well. If your bussiness is rapidly growing or you have a big company it might be a good decision to chose 'Enterprise' version which delivers good customization features specially for your bussiness and support conditions. Be sure to contact us if you have any questions or propositions according acquiring our product at https://easyerp.com/contact-us.");

            if (str.Contains("purchase") && str.Contains("version") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: It depends on the needs of your bussines. If you have small company with limited number of workers and budget 'SaaS' version may suit you well. If your bussiness is rapidly growing or you have a big company it might be a good decision to chose 'Enterprise' version which delivers good customization features specially for your bussiness and support conditions. Be sure to contact us if you have any questions or propositions according acquiring our product at https://easyerp.com/contact-us.");

            if (str.Contains("saas") && str.Contains("enterprise"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: It depends on the needs of your bussines. If you have small company with limited number of workers and budget 'SaaS' version may suit you well. If your bussiness is rapidly growing or you have a big company it might be a good decision to chose 'Enterprise' version which delivers good customization features specially for your bussiness and support conditions. Be sure to contact us if you have any questions or propositions according acquiring our product at https://easyerp.com/contact-us.");

            if (str.Contains("safe") && str.Contains("data") && str.Contains("erp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Safety of clients data is very important for us. We use servers on Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients can store DB in their own office or in private cloud.");

            if (str.Contains("level") && str.Contains("protection"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Safety of clients data is very important for us. We use servers on Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients can store DB in their own office or in private cloud.");

            if (str.Contains("protect") && str.Contains("easyerp"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Safety of clients data is very important for us. We use servers on Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients can store DB in their own office or in private cloud.");

            if (str.Contains("protect") && str.Contains("hacking"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Yes it is. We are using protected servers like Amazon web services, Hetzner.de or Vultr.com, and if you are using Enterpirse version you can use any server protection you like.");

            if (str.Contains("protect") && str.Contains("hacking") && str.Contains("about"))
                await context.PostAsync("Intent: CostEasyERP\n\n Answer: Of course we have one! We are using protected servers like Amazon web services, Hetzner.de or Vultr.com, and if you are using Enterpirse version you can use any server protection you like.");

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
            string str = result.Query;

            if (str.Contains("easyerp") && str.Contains("opensource"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes. You may customize the source code, but it's not allowed to change name of our product");

            if (str.Contains("opensource"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes. You may customize the source code, but it's not allowed to change name of our product");

            if (str.Contains("download") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU");

            if (str.Contains("download") && str.Contains("link"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Sure, please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU");

            if (str.Contains("demo") && (str.Contains("n`t") || str.Contains("not")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please, turn off Adblock or other web browser extensions");

            if (str.Contains("github") && (str.Contains("link")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please, follow this link https://github.com/EasyERP/EasyERP_open_source");

            if (str.Contains("download") && (str.Contains("source code")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please, follow this link https://github.com/EasyERP/EasyERP_open_source");

            if ((str.Contains("not") || str.Contains("n`t")) && ((str.Contains("work") && str.Contains("run"))))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please, send me description of your issue (if possible, with screenshots ) on norbert@easyerp.com");

            if (str.Contains("availiable") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: It's available only in English, if needed, we may translate it for you into other language");

            if (str.Contains("language") && str.Contains("supported"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: It's available only in English, if needed, we may translate it for you into other language");

            if ((str.Contains("platform") || str.Contains("operation system") || str.Contains("os")) && str.Contains("supported"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: EasyERP is available on Mac, Windows and Linux.");

            if (str.Contains("run") && (str.Contains("mac") || str.Contains("linux") || str.Contains("windows")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, you can, EasyERP is available on Mac, Windows and Linux.");

            if (str.Contains("run") && str.Contains("online"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, you can. Please follow the link http://demo.easyerp.com");

            if (str.Contains("download") && str.Contains("easyerp") && str.Contains("free"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, you can. Please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU");

            if (str.Contains("demo"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, we have. Follow the next link please http://demo.easyerp.com");

            if (str.Contains("trial"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: No, we don't. But EasyERP is open source and you can try demo online http://demo.easyerp.com");

            if (str.Contains("database"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: EasyERP uses NoSQL MongoDB database.");

            if (str.Contains("easyerp") && (str.Contains("locally") || str.Contains("localhost")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, you can. Please, follow this link https://easyerp.com/download/. It's recommended to run it on 64 bit CPU");

            if (str.Contains("long") && str.Contains("install"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: It takes about 3 minutes");

            if (str.Contains("crash") && str.Contains("lose") && str.Contains("database"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: You won't lose your data even in that case");

            if (str.Contains("assign") && str.Contains("access") && str.Contains("user"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Go to Settings -> Access profiles. Here you can manage in group what modules users can view, edit or delete. Or you can create new groups with custom privelegies");

            if (str.Contains("run") && str.Contains("erp") && (str.Contains("ipad") || str.Contains("smartphone")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: I`m affraid in current version it`s not possible, but we are looking forward working on mobile version in future.");

            if (str.Contains("implement") && str.Contains("scratch"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Implementation process takes from two to six weeks ");

            if (str.Contains("hardware") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: EasyERP is available on Mac, Windows and Linux. The system has to be 64bit system. ");

            if (str.Contains("database") && str.Contains("stored"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Database is stored in Cloud and we usually use Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients store DB in own office or in private cloud.");

            if (str.Contains("install") && str.Contains("easyerp") && str.Contains("next"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: To use EasyERP to it's full potential please read the documentaion first here https://easyerp.com/documentation/");

            if (str.Contains("use") && str.Contains("erp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: I'm affraid no, but you can mannage several market platforms such as Magento, Shopify, Etsy etc.  ");

            if (str.Contains("bug") && str.Contains("do"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Thank you, for your contribution. You can submit bugs that you have find here https://easyerp.com/contact-us/");

            if (str.Contains("send") && str.Contains("demo"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: You can download demo by yourself simply by following this link https://easyerp.com/.");

            if ((str.Contains("update") || str.Contains("new")) && str.Contains("version"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: We are currently working on it.");

            if (str.Contains("free") && (str.Contains("n`t") || str.Contains("not")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: If you have problems with installation or some other questions please left them here https://easyerp.uservoice.com/ or here https://easyerp.com/contact-us/ . Also you can try out online Demo https://demo.easyerp.com/");

            if (str.Contains("exe") && (str.Contains("n`t") || str.Contains("not")) && str.Contains("download"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: We use sourceforge.net for file storage, if the file is not available please try again later. If it doesn't help please contact us, and we will find a way to deliver this file to you  https://easyerp.com/contact-us/ ");

            if (str.Contains("customize") && str.Contains("workflow"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: To customize your workflows, please go to Settings -> Workflows");

            if (str.Contains("install") && str.Contains("language"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: I`m affraid you may not, but if needed, we may translate it for you into other language");

            if (str.Contains("demo") && str.Contains("fix"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Please clear you cookies and cache files and then refresh the page.");

            if (str.Contains("demo") && str.Contains("login"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: there is just a default login - superAdmin");

            if (str.Contains("print") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: All printable forms have a button with printer logo at the top., just print that button. For more details please read the documentation here https://easyerp.com/documentation/");

            if (str.Contains("enough") && str.Contains("easyerp") && str.Contains("standard"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: yes it is enough");

            if (str.Contains("data") && str.Contains("same"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Yes, all users see data equally.");

            if (str.Contains("demo") && str.Contains("nothing"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Try to restart loading sequence, and if it still not working contact our team: https://easyerp.com/contact-us/.");

            if (str.Contains("mobile") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: I`m affraid there is none, but we are looking forward working on mobile version in future.");

            if ((str.Contains("ipad") || str.Contains("iphone") || str.Contains("android")) && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: I`m affraid it`s not possible for now, but we are looking forward working on mobile version in future.");

            if (str.Contains("technology") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: For front-end we used Backbon.js and for back-end we used Node.js. For database we used MongoDB, API - RestAPI.");

            if (str.Contains("store") && str.Contains("data"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: We use servers on Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients can store DB in their own office or in private cloud.");

            if (str.Contains("hosting") && (str.Contains("provide") || str.Contains("use") || str.Contains("about")))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: We use servers on Amazon web services, Hetzner.de or Vultr.com. In case of on-demand our clients can store DB in their own office or in private cloud.");

            if ((str.Contains("run") || str.Contains("store")) && str.Contains("server"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: In case of on-demand our clients store DB in own office or in private cloud.");

            if (str.Contains("special") && str.Contains("hardware"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Of course not. EasyErp can be runed on nearly any system. There is only one mandatory requirement: you should install EasyERP on x64 operating system. ");

            if ((str.Contains("need") || str.Contains("special")) && str.Contains("run") && str.Contains("easyerp"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Nothing speciall.EasyErp works fine on nearly any system(offline version) and / or device(online version).There are only two requirements: \n - if you want to run desktop version of EasyERP x64 operating system is needed \n - in case you`d like to run EasyERP on your own server, obviously you have to consider server acquiring and its maintenance or proper hosting.");

            if ((str.Contains("run") || str.Contains("work")) && str.Contains("linux"))
                await context.PostAsync("Intent: AboutEasyERP\n\n Answer: Sure it will!");
            
            context.Wait(MessageReceived);
        }

        [LuisIntent("ModulesEasyERP")]
        public async Task ProcessModulesEasyERP(IDialogContext context, LuisResult result)
        {
            string str = result.Query;

            if (str.Contains("accounting purpose"))
                await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Sure thing! Specially for this case we have 'Accounting' module which makes this task as easy and smooth as possible.");

            if (str.Contains("accounting"))
                await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For accounting purposes we have whole 'Accounting' module.");

            if (str.Contains("sale"))
                await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For sales purpose we have whole 'Sales' module.");

            if (str.Contains("manage sale"))
                await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can do this in 'Sales' module right in EasyERP.");

            if (str.Contains("supply") && str.Contains("chain management"))
                await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: This section is still under development, but soon it will be fully functional.");

            if (str.Contains("dashboard") && str.Contains("crm section"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For more information about the dashboard of CRM module please read the documentation here https://easyerp.com/documentation/");

            if (str.Contains("limitation") && str.Contains("user"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: No, the number of users in EasyERP is unlimited.");

            if (str.Contains("user") && str.Contains("add"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: The number of users in EasyERP is unlimited.");

            if (str.Contains("user") && str.Contains("limited"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: No, the number of users in EasyERP is unlimited.");

            if (str.Contains("user") && str.Contains("limited"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: No, the number of users in EasyERP is unlimited.");
            
            if (str.Contains("crm feature") && str.Contains("easyerp"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: All CRM features we gathered in 'CRM' module in EasyERP where you can find all spectrum of CRM attributes you are used to and even more. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("project management") && str.Contains("easyerp"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For your project management needs we have a whole 'Project' module in EasyERP where you can fast and with ease plan and manage your projects, set up tasks and appoint your workers. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("hr feature") && str.Contains("easyerp"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For your HR management needs we have a whole 'HR' module in EasyERP where you can store all information about your employees, applications from potential employees, manage job positions, work time and days-off etc. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("finance") && str.Contains("easyerp"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Specially for finance managing we have 'Accounting', 'Payroll', 'Expenses' and 'Purchases' modules where you can fast and with ease control and manage whole spectrum of finance related issues.For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("accounting feature") && str.Contains("easyerp"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: For your accounting needs we have a whole 'Accounting' module in EasyERP where you can fast and with ease manage your accounts superwise transfers, cashflows, profits and losses. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("manage") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You are able to do this in 'Inventory' module in EasyERP. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("manage") && str.Contains("profile credential"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Yes. You can do this in 'Settings->Access profiles'.");

            if (str.Contains("profile credential"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Yes. You can do this in 'Settings->Access profiles'.");

            if (str.Contains("profile credential"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Yes. You can do this in 'Settings->Access profiles'.");

            if (str.Contains("crm module"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It`s module where you are able to manage all issues related to your sales processes. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("crm module") && (str.Contains("special") || str.Contains("exceptional")))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Our CRM module is an integral part of EasyERP ecosystem and EasyERP is made for all-in-one business management that includes also decent inventory manegement, accounting, HR modules, so you`ll benefit from using CRM with all listed above modules.");

            if (str.Contains("find") && str.Contains("lead"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it at 'CRM->Leads'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("opportunities"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it at 'CRM->Opportunities'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("person"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it at 'CRM->Persons'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("companies"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it at 'CRM->Companies'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("report"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them at 'CRM->Reports'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("order"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them at 'CRM->Orders'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("invoice"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them at 'CRM->Invoices'. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("payment"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It depends on which exactly 'payments' you are interested in. There is 'CRM->Payments' tab where information about financial payments made by your customers is stored, or 'Purchases->Payments' where information about your payments for your orders is. Also there are payment related tabs in 'Accounting', 'Payroll' and 'Expenses' modules. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation. ");

            if (str.Contains("find") && str.Contains("task"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It depends on which exactly 'tasks' you are interested in. There is 'CRM->Tasks' where you can manage your leads/clients related tasks, or 'Project->Tasks' where you can operate tasks according your projects.For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("project module") && (str.Contains("special")||str.Contains("exceptional")))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Our Project module is an integral part of EasyERP ecosystem and EasyERP is made for all-in-one business management that includes also decent inventory manegement, accounting, CRM and HR modules, so you`ll benefit from using Project module with all listed above modules.");

            if (str.Contains("project module") && str.Contains("about"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It`s module where you are able to manage all issues related to your projects. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("plan task") && str.Contains("employe"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can do this in 'Project->Tasks' tab.");

            if (str.Contains("manage tasks") && str.Contains("worker"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can do this in 'Project->Tasks' tab.");

            if (str.Contains("find") && str.Contains("planning"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Project->Planning' tab.");

            if (str.Contains("plan") && str.Contains("project"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can plan them in 'Project->Planning' tab.");

            if (str.Contains("distribute") && (str.Contains("employe") || str.Contains("worker")))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can distribute it in 'Project->Planning' tab, or in 'Project->Jobs Dashboard' tab.");

            if (str.Contains("manage") && str.Contains("project"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can manage them in 'Project->Projects' tab.");

            if (str.Contains("work") && str.Contains("project"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can work with them in 'Project->Projects' tab.");

            if (str.Contains("find") && str.Contains("contract"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Project->Contract jobs' tab.");

            if (str.Contains("find") && str.Contains("employe"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'HR->Employees' tab.");

            if (str.Contains("manage") && str.Contains("worker"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can manage your workers in 'HR' module.");

            if (str.Contains("manage") && str.Contains("employe"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can manage them in 'HR' module.");

            if (str.Contains("information") && str.Contains("worker"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: All information about your workers/employees is available in 'HR' module.");

            if (str.Contains("hr") && (str.Contains("special") || str.Contains("exceptional")))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Our HR module is an integral part of EasyERP ecosystem and EasyERP is made for all-in-one business management that includes also decent inventory manegement, accounting, CRM modules, so you`ll benefit from using HR module with all listed above modules.");

            if (str.Contains("hr module") && str.Contains("about"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It`s module where you are able to manage all issues related to your employees. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("application"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'HR->Applications' tab.");

            if (str.Contains("about") && str.Contains("purchases module"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Purchases module facilitates purchasing process, supplier/vendor and inventory management and makes them more efficient. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");
            
            if (str.Contains("do") && str.Contains("purchases module"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: In purchases module you have access to purchasing process, supplier/vendor and inventory management. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("do") && str.Contains("accounting module"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: In 'Accounting' module in EasyERP you can fast and with ease manage your accounts superwise transfers, cashflows, profits and losses. For further information be sure to acquaint yourself with our demo-EasyERP at https://easyerp.com/.");

            if (str.Contains("check") && str.Contains("bank account"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them in 'Accounting->Chart of Account'.");

            if (str.Contains("superwise") && str.Contains("cashflow"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them in 'Accounting->Cashflows'.");

            if (str.Contains("work") && str.Contains("cashflow"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can work with them in 'Accounting->Cashflows'.");

            if (str.Contains("find") && str.Contains("balance"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Accounting->Balance'.");

            if (str.Contains("work") && str.Contains("balance"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can work with it in 'Accounting->Balance'.");

            if (str.Contains("look") && str.Contains("balance"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Accounting->Balance'.");

            if (str.Contains("find") && str.Contains("profit"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Accounting->Profit and Loss'.");

            if (str.Contains("count") && str.Contains("profit"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can count it in 'Accounting->Profit and Loss'.");

            if (str.Contains("find") && str.Contains("loss"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Accounting->Profit and Loss'.");

            if (str.Contains("count") && str.Contains("profit"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can count it in 'Accounting->Profit and Loss'.");

            if (str.Contains("payroll"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Payroll' module is where all your financial issues with your employees are held. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("payout"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Payroll->Payout'.");

            if (str.Contains("find") && str.Contains("salary"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Payroll->Salary report'.");

            if (str.Contains("salary report"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Payroll->Salary report'.");

            if (str.Contains("count") && str.Contains("salaries"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can count them in 'Payroll->Salary report'.");

            if (str.Contains("count") && str.Contains("bonuses"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can count them in 'Payroll->Bonus type'.");

            if (str.Contains("find") && str.Contains("salary expense"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find it in 'Payroll->Payroll expenses'.");

            if (str.Contains("about") && str.Contains("expenses"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Expenses' module is about dealing with all your expenses issues in one place. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("do") && str.Contains("expenses"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Expenses' module is about dealing with all your expenses issues in one place. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("find") && str.Contains("expenses"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can find them in 'Expenses' module, it is about dealing with all your expenses issues in one place.");

            if (str.Contains("count") && str.Contains("expenses"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You count them in 'Expenses' module, it is meant for dealing with all your expenses issues in one place.");

            if (str.Contains("inventory") && str.Contains("about"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Inventory' module was meant for dealing with all your products mangement issues. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("inventory") && str.Contains("do"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Inventory' module was meant for dealing with all your products mangement issues. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("inventory") && str.Contains("in"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: 'Inventory' module was meant for dealing with all your products mangement issues. For further information be sure to acquaint yourself with our documentation for EasyERP at https://easyerp.com/documentation.");

            if (str.Contains("inventory") && str.Contains("work") && str.Contains("only place"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It is made to simplify product management and synchronization processes with your shops.");

            if (str.Contains("inventory") && str.Contains("stored") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: It is made to simplify product management and synchronization processes with your shops.");

            if (str.Contains("inventory") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: All your products are kept in inventory.");

            if (str.Contains("inventory") && str.Contains("type") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: All your products are kept in inventory, doesn`t matter what type they are.");

            if (str.Contains("inventory") && str.Contains("keep") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: You can keep any products your bussiness needs in inventory.");

            if (str.Contains("inventory") && str.Contains("store") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: The number of products in inventory is unlimited.");

            if (str.Contains("inventory") && str.Contains("number") && str.Contains("product"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: The number of products in inventory is unlimited.");

            if (str.Contains("add") && str.Contains("user"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Of course you can! EasyERP is as scalable and flexible as it is possible to adjust to your company`s needs. So simply contact those guys over there https://easyerp.com/contact-us and add as much users as you want and whenever you want.");

            if (str.Contains("add") && str.Contains("user") && str.Contains("possible"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: Of course it is! EasyERP is as scalable and flexible as it is possible to adjust to your company`s needs. So simply contact those guys over there https://easyerp.com/contact-us and add as much users as you want and whenever you want.");

            if (str.Contains("easyerp") && str.Contains("manage"))
            await context.PostAsync("Intent: ModulesEasyERP\n\n Answer: I`m affraid we have no complex document management instrument in easyERP. Nevertheless you are able to attach any documents you like into nearly every tab.");

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
            string str = result.Query;

            if (str.Contains("developer") && str.Contains("documentation"))             
            await context.PostAsync("Intent: SupportUsers\n\n Answer: We are working on it");

            if (str.Contains("videos") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Not yet, we are working on it");

            if (str.Contains("teach") && str.Contains("staff"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: In case of paid version we may help you with teaching your staff to work with our ERP");

            if (str.Contains("guide") || str.Contains("tutorial"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: You can read it here https://easyerp.com/documentation/ It is being updated constantly.");

            if (str.Contains("order") && str.Contains("response"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: We apologize for our inconvience, please contact us as fast as posible here  https://easyerp.com/contact-us/ ");

            if (str.Contains("send") && str.Contains("feedback"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: You can send your propositions here https://easyerp.com/contact-us/");

            if (str.Contains("accounting") && str.Contains("purchases"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: This section of technical documentation is still under development but it will be available soon.");

            if (str.Contains("support") && str.Contains("implementation"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Yes, we provide support to users who use SaaS and Enterprise versions. This includes technical, informational support and hosting. ");

            if (str.Contains("support") && str.Contains("24/7"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Currently we don`t provide 24/7 tech support, but you can leave your questions here and we will contact you ASAP.");

            if (str.Contains("training") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: If you are new to ERP or CRM systems then we have technical documentation at https://easyerp.com/documentation with a pile of interesting stuff in it, or those guys are always ready to answer you questions here or at https://easyerp.com/contact-us. And if you are the ace of ERP or CRM systems, then working with EasyERP will be as easy for you as abc, but you might find something interesting in technical documentation too.");

            if (str.Contains("knowledge") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: If you are new to ERP or CRM systems then we have technical documentation at https://easyerp.com/documentation with a pile of interesting stuff in it, or those guys are always ready to answer you questions here or at https://easyerp.com/contact-us. And if you are the ace of ERP or CRM systems, then working with EasyERP will be as easy for you as abc, but you might find something interesting in technical documentation too.");

            if (str.Contains("start") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: If you are new to ERP or CRM systems then we have technical documentation at https://easyerp.com/documentation with a pile of interesting stuff in it, or those guys are always ready to answer you questions here or at https://easyerp.com/contact-us. And if you are the ace of ERP or CRM systems, then working with EasyERP will be as easy for you as abc, but you might find something interesting in technical documentation too.");

            if (str.Contains("help") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Well you came by the right address, I`m hear to help you! Or if you have some specific questions, please ask those guys over there https://easyerp.com/contact-us. Also you can always have a glance at our technical documentation at https://easyerp.com/documentation, there is always plenty of interesting stuff in it.");

            if (str.Contains("help") && str.Contains("need"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Well you came by the right address, I`m hear to help you! Or if you have some specific questions, please ask those guys over there https://easyerp.com/contact-us. Also you can always have a glance at our technical documentation at https://easyerp.com/documentation, there is always plenty of interesting stuff in it.");
            
            if (str.Contains("training") && str.Contains("easyerp"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: I`m affraid in a meantime we don`t have such training courses.");

            if (str.Contains("training") && str.Contains("personnel"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: I`m affraid we don`t provide any training courses in a meantime.");

            if (str.Contains("train") && str.Contains("personnel"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: I`m affraid we don`t provide any training courses in a meantime. You can use technical documentation, or contact us at https://easyerp.com/contact-us for further negotiations.");

            if (str.Contains("forum"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: In a meantime we don`t have any community forum running, but we are actively working on it. In a meantime you can visit our blog here https://easyerp.com/blog/ or our support at https://easyerp.uservoice.com/ where you may find a lot of interesting stuff.");

            if (str.Contains("blog") && str.Contains("have"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Sure we have one! You can visit it at https://easyerp.com/blog/.");

            if (str.Contains("blog"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: You can visit our blog at https://easyerp.com/blog/.");

            if (str.Contains("support") && str.Contains("have"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: Sure we have! You can visit it at https://easyerp.uservoice.com/");

            if (str.Contains("support"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: You can visit our support center at https://easyerp.uservoice.com/");

            if (str.Contains("support") && str.Contains("india"))
            await context.PostAsync("Intent: SupportUsers\n\n Answer: No");

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