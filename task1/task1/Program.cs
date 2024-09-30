using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Гимн России");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Россия - священная наша держава,");
            Console.WriteLine("Россия - любимая наша страна.");
            Console.WriteLine("Могучая воля, великая слава -");
            Console.WriteLine("Твое достоянье на все времена!");

            Console.ReadKey();

            Console.ResetColor();
            Console.Clear();

            Console.WriteLine("Гимн России");
            Console.WriteLine();
            Console.WriteLine("Россия - священная наша держава,");
            Console.WriteLine("Россия - любимая наша страна.");
            Console.WriteLine("Могучая воля, великая слава -");
            Console.WriteLine("Твое достоянье на все времена!");

            Console.ReadKey();
        }
    }
}