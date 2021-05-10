using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var numeros = Enumerable.Range(1, 1000);
            var filterNumber = (from n in numeros.AsParallel() //aqui hagomi ejecucion paralela
                                where isValid(n)
                                select n
                                ).ToList();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }

        public static bool isValid(int num)
        {
            Thread.Sleep(10);
            if (num % 2 != 0) return false;
            if (num % 5 != 0) return false;

            return true;
        }
    }
}
