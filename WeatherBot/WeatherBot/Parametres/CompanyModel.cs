using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading.Tasks;

namespace WeatherBot.Parametres
{
    [Serializable]
    public class CompanyModel
    {
        public CompanyModel()
        {
            GetDepartments();
            GetProjects();
        }

        public string Name { get; set; } = "ThinkMobiles";

        public string Founder { get; set; } = "Alexander Sokhanych";

        public double Lat { get; set; } = 48.618971;

        public double Lon { get; set; } = 22.297948;

        public string Address { get; set; } = "Uzhhorod, 47";

        public DateTime CreateDate { get; set; } = new DateTime(2011, 07, 15);

        //public List<string> Departments { get; set; } = new List<string>() { "Android", "iOS", "Unity3D", "JS", "Ruby on Rails", "Design", "CSS/Frontend", "QA", "PHP/WordPress", "PM", "HR" };
        public List<DepartmentModel> Departments { get; set; }

        public int Employees { get; set; } = 200;

        public string AboutCompany { get; set; } = "one of the largest mobile app development & outsourcing companies of Central Europe";

        public string DescriptionCompany { get; set; } = "ThinkMobiles";

        public string News { get; set; } = "Not long ago ThinkMobiles became a member of Ukrainian IT Association";

        public string Feedbacks { get; set; } = "Clients from all world are satisfied with our products";

        public string LastQuery { get; set; }

        public Dictionary<string, string> Projects { get; set; }

        internal DepartmentModel GetAndroidDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "Android";
            departmentModel.HeadOfDepartment = "Vitaliy Shuba";
            departmentModel.Skype = "mikazme";
            departmentModel.Frameworks = new List<string> { "Android SDK", "JUnit" };
            departmentModel.Languages = new List<string> { "Java" };
            departmentModel.ServicesLibraries = new List<string> { "Retrofit", "RxJava", "Realm", "Google services(map, location, g+ etc)", "fabric", "Glide", "Picasso", "AndroidAnnotation" };
            departmentModel.MinRate = 20;
            departmentModel.MaxRate = 25;
            departmentModel.AverageRate = 24;
            departmentModel.AveragePrice = 9000;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetIosDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "IOS";
            departmentModel.HeadOfDepartment = "Anatoliy Dalekorey";
            departmentModel.Skype = "d.r.i.m.f";
            departmentModel.Frameworks = new List<string> { "CoreData", "CoreBluetooth", "CoreLocation" };
            departmentModel.Languages = new List<string> { "Swift", "ObjectiveC" };
            departmentModel.ServicesLibraries = new List<string> { "a lot of" };
            departmentModel.MinRate = 20;
            departmentModel.MaxRate = 25;
            departmentModel.AverageRate = 24;
            departmentModel.AveragePrice = 9000;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetJSDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "JavaScript";
            departmentModel.HeadOfDepartment = "Roman Buchuk";
            departmentModel.Skype = "romashkabk";
            departmentModel.Frameworks = new List<string> { "SpringMVC/Data/Security", "Hibernate", "JDBC", "JUnit", "Mockito", "Jenkins", "Apache TomCat", "Express" };
            departmentModel.Languages = new List<string> { "NodeJS", "JavaScript" };
            departmentModel.ServicesLibraries = new List<string> { "a lot of" };
            departmentModel.MinRate = 20;
            departmentModel.MaxRate = 25;
            departmentModel.AverageRate = 24;
            departmentModel.AveragePrice = 9000;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetPhpDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "PHP / WordPress";
            departmentModel.HeadOfDepartment = "Alex Storojenko";
            departmentModel.Skype = "alexandr.storojenko";
            departmentModel.Frameworks = new List<string> { "Laravel", "Simfony", "CakePHP", "Phalcon", "Kohana", "Silex" };
            departmentModel.Languages = new List<string> { "PHP" };
            departmentModel.ServicesLibraries = new List<string> { "a lot of" };
            departmentModel.MinRate = 20;
            departmentModel.MaxRate = 25;
            departmentModel.AverageRate = 24;
            departmentModel.AveragePrice = 5500;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetRubyDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "Ruby";
            departmentModel.HeadOfDepartment = "Roman Babunich";
            departmentModel.Skype = "roveruz";
            departmentModel.Frameworks = new List<string> { "Rails", "Sinatra" };
            departmentModel.Languages = new List<string> { "Ruby" };
            departmentModel.ServicesLibraries = new List<string> { "a lot of" };
            departmentModel.MinRate = 20;
            departmentModel.MaxRate = 25;
            departmentModel.AverageRate = 24;
            departmentModel.AveragePrice = 5500;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetUnityDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "Unity 3D";
            departmentModel.HeadOfDepartment = "Eugen Bernikevich";
            departmentModel.Skype = "evgendavis";
            departmentModel.Frameworks = new List<string> { ".NET" };
            departmentModel.Languages = new List<string> { "C#" };
            departmentModel.ServicesLibraries = new List<string> { "a lot of" };
            departmentModel.MinRate = 25;
            departmentModel.MaxRate = 30;
            departmentModel.AverageRate = 27;
            departmentModel.AveragePrice = 6000;
            departmentModel.IsFull = true;

            return departmentModel;
        }

        internal DepartmentModel GetDesignDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "Design";
            departmentModel.HeadOfDepartment = "Sergiy Petakh";
            departmentModel.Skype = "sergii.petakh";            
            departmentModel.IsFull = false;

            return departmentModel;
        }

        internal DepartmentModel GetFrontendDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "CSS";
            departmentModel.HeadOfDepartment = "Ivan Khartov";
            departmentModel.Skype = "demarko_k062";
            departmentModel.IsFull = false;

            return departmentModel;
        }

        internal DepartmentModel GetQaDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "QA";
            departmentModel.HeadOfDepartment = "Yana Gusti";
            departmentModel.Skype = "yanochka_3007";
            departmentModel.IsFull = false;

            return departmentModel;
        }

        internal DepartmentModel GetPmDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "PM";
            departmentModel.HeadOfDepartment = "Dmytro Babilia";
            departmentModel.Skype = "dima28911";
            departmentModel.IsFull = false;

            return departmentModel;
        }

        internal DepartmentModel GetHrDepartment()
        {
            var departmentModel = new DepartmentModel();
            departmentModel.NameDepartment = "HR";
            departmentModel.HeadOfDepartment = "Irina Grab";
            departmentModel.Skype = "hr-mobilesoft365";
            departmentModel.IsFull = false;

            return departmentModel;
        }

        internal void GetProjects()
        {
            Projects = new Dictionary<string, string>();
            Projects.Add("YoVivo!", @"https://thinkmobiles.com/projects/yovivo/");
            Projects.Add("Oris4", @"https://thinkmobiles.com/projects/oris4/");
            Projects.Add("Quick Connect", @"https://thinkmobiles.com/projects/quick-connect/");
            Projects.Add("iTacit", @"https://thinkmobiles.com/projects/itacit/");
            Projects.Add("360 Camera App", @"https://thinkmobiles.com/projects/360cam/");
            Projects.Add("Hashplay", @"https://thinkmobiles.com/projects/hashplay/");
            Projects.Add("App Promotion Website Development ", @"https://thinkmobiles.com/projects/app-promotion-website-development/");
            Projects.Add("Sparkd!", @"https://thinkmobiles.com/projects/sparkd/");
            Projects.Add("Skratch", @"https://thinkmobiles.com/projects/scratch/");
            Projects.Add("WaspApp", @"https://thinkmobiles.com/projects/waspapp/");
            Projects.Add("Zombario", @"https://thinkmobiles.com/projects/zombario/");
            Projects.Add("Business Website Development - 360Cam", @"https://thinkmobiles.com/projects/business-website-development/");
            Projects.Add("SPS Control", @"https://thinkmobiles.com/projects/business-website-development/");
            Projects.Add("Move for Less ", @"https://thinkmobiles.com/projects/move-for-less/");
        }

        internal void GetDepartments()
        {
            Departments = new List<DepartmentModel>();
            Departments.Add(GetAndroidDepartment());
            Departments.Add(GetIosDepartment());
            Departments.Add(GetJSDepartment());
            Departments.Add(GetPhpDepartment());
            Departments.Add(GetRubyDepartment());
            Departments.Add(GetUnityDepartment());
            Departments.Add(GetDesignDepartment());
            Departments.Add(GetFrontendDepartment());
            Departments.Add(GetQaDepartment());
            Departments.Add(GetPmDepartment());
            Departments.Add(GetHrDepartment());
        }

        internal string ParseLuisResult(LuisResult result)
        {
            return Reply(result.Query);
        }

        public string Reply(string msg)
        {
            var a = msg.ToLower();
            LastQuery = msg;
            string result = string.Empty;

            if (a.Contains("help")) { result = "This is a thinkmobiles bot, about company dialog. Examples of commands include: When company founded?"; }
            else if (a.Contains("news") && a.Contains("about") && a.Contains("company")) { result = News; }
            else if (a.Contains("about") && a.Contains("company") && a.Contains("departments"))
            {
                result = Name + " have ";
                Departments.ForEach(i => result += i.NameDepartment + ", ");
                result = result.Substring(0, result.Length - 2) + " departments";
            }
            else if (a.Contains("about") && a.Contains("company")) { result = Name + " - " + AboutCompany; }
            else if (a.Contains("about") && a.Contains("think")) { result = "Our company - " + AboutCompany; }
            else if (a.Contains("departments") && (a.Contains("many") || a.Contains("much"))) { result = "Our company have " + Departments.Count + " departments"; }
            else if (a.Contains("departments"))
            {
                result = Name + " have ";
                Departments.ForEach(i => result += i.NameDepartment + ", ");
                result = result.Substring(0, result.Length - 2) + " departments";
            }
            else if (a.Contains("employ") && a.Contains("many")) { result = "About " + Employees + " employees"; }
            else if (a.Contains("feedback")) { result = Feedbacks; }
            else if (a.Contains("founded")) { result = Name + " was founded at " + CreateDate.ToShortDateString(); }
            
            else if (a.Contains("news")) { result = News; }
            else if (a.Contains("department") && a.Contains("head") && (a.Contains("skype") || a.Contains("contact") || a.Contains("mobile") || a.Contains("phone")))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    result = "Skype " + departmentModel.HeadOfDepartment + " : " + departmentModel.Skype;
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("about") && a.Contains("head"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    result = departmentModel.NameDepartment + ":\n\n";
                    result += "Head of department " + departmentModel.HeadOfDepartment + "\n\n";
                    result += "Skype: " + departmentModel.Skype + "\n\n";
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("head"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    result = "The head of this department " + departmentModel.HeadOfDepartment;
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("lang"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    if (!departmentModel.IsFull)
                    {
                        result = "Sorry, this department does not work with programming languages";
                    }
                    else
                    {
                        result = departmentModel.NameDepartment + " use ";
                        departmentModel.Languages.ForEach(i => result += i + ", ");
                        result = result.Substring(0, result.Length - 2) + (result.Count(i => i == ',') > 1 ? " languages" : " language");
                    }                    
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("framework"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    if (!departmentModel.IsFull)
                    {
                        result = "Sorry, this department does not work with frameworks";
                    }
                    else
                    {
                        result = departmentModel.NameDepartment + " use ";
                        departmentModel.Frameworks.ForEach(i => result += i + ", ");
                        result = result.Substring(0, result.Length - 2) + (result.Count(i => i == ',') > 1 ? " frameworks" : " framework");
                    }                    
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && (a.Contains("service") || a.Contains("libr")))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    if (!departmentModel.IsFull)
                    {
                        result = "Sorry, this department does not work with services and libraries";
                    }
                    else
                    {
                        result = departmentModel.NameDepartment + " use ";
                        departmentModel.ServicesLibraries.ForEach(i => result += i + ", ");
                        result = result.Substring(0, result.Length - 2) + " services and libraries";
                    }                    
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("price"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    if (!departmentModel.IsFull)
                    {
                        result = "Sorry, this department does not have price. Their job is invaluable!";
                    }
                    else
                        result = departmentModel.NameDepartment + " have average price " + departmentModel.AveragePrice + "$";
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("rate"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    if (!departmentModel.IsFull)
                    {
                        result = "Sorry, this department does not have rate. Their job is invaluable!";
                    }
                    else
                    {
                        if (a.Contains("min"))
                            result = departmentModel.NameDepartment + " have min rate " + departmentModel.MinRate + "$";
                        if (a.Contains("max"))
                            result = departmentModel.NameDepartment + " have max rate " + departmentModel.MaxRate + "$";
                        else
                            result = departmentModel.NameDepartment + " have average rate " + departmentModel.AverageRate + "$";
                    }                    
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("department") && a.Contains("about"))
            {
                DepartmentModel departmentModel = null;
                Departments.ForEach(i => departmentModel = a.Contains(i.NameDepartment.ToLower()) ? i : departmentModel);

                if (departmentModel != null)
                {
                    result = departmentModel.NameDepartment + " department:\n\n";
                    result += "Head of department " + departmentModel.HeadOfDepartment + "\n\n";
                    if (departmentModel.IsFull)
                    {
                        result += "Use ";
                        departmentModel.Languages.ForEach(i => result += i + ", ");
                        result = result.Substring(0, result.Length - 2) + (result.Count(i => i == ',') > 1 ? " languages\n\n" : " language\n\n");
                        result += "so ";
                        departmentModel.Frameworks.ForEach(i => result += i + ", ");
                        result = result.Substring(0, result.Length - 2) + (result.Count(i => i == ',') > 1 ? " frameworks\n\n" : " framework\n\n");
                    }                        
                }
                else
                    result = "Please specify on what department you are saying now";
            }
            else if (a.Contains("projects"))
            {
                {
                    result = Name + " made ";
                    Projects.ToList().ForEach(i => result += i.Key + "(" + i.Value + ")" + ", \n\n");
                    result = result.Substring(0, result.Length - 2) + " projects";
                }
            }
            else if (a.Contains("founder") || a.Contains("director") || a.Contains("head") || a.Contains("owner") || a.Contains("ceo")) { result = "Our founder is " + Founder; }
            else result = string.Empty;

            return result;
        }

        [Serializable]
        public class DepartmentModel
        {
            public string NameDepartment { get; set; }

            public string HeadOfDepartment { get; set; }

            public string Skype { get; set; }

            public List<string> Frameworks { get; set; }

            public List<string> Languages { get; set; }

            public List<string> ServicesLibraries { get; set; }

            public decimal MinRate { get; set; }

            public decimal MaxRate { get; set; }

            public decimal AverageRate { get; set; }

            public decimal AveragePrice { get; set; }

            public bool IsFull { get; set; }
        }
    }
}