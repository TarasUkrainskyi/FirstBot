using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "a b c";
            var a = MostFequently(str);
            foreach (char c in a)
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();

        }

        public static List<char> MostFequently(string str)
        {
            var list = new List<char>();
            int maxCount = 0;
            str = Regex.Replace(str, @"\s+", "");

            foreach (char c in str.Distinct())
            {
                int count = str.Where(item => item == c).Count();

                if (count == maxCount)
                {
                    list.Add(c);
                }
                else if (count > maxCount)
                {
                    maxCount = count;
                    list.Clear();
                    list.Add(c);
                }
            }

            return list;
        }
    }
}
