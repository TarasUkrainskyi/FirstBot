using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(10));
            Console.WriteLine(Factorial1(10));
            Console.ReadLine();
        }

        public static int Factorial(int n)
        {
            int l = 1;
            while (n != 0) { l *= n--; }
            return l;
        }

        public static int Factorial1(int n)
        {
            var a = Enumerable.Range(1, n).Aggregate((acc, x) => acc * x);
            
            return a;
        }

    }
}
