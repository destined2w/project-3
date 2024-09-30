using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika3009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину ребра куба:");
            double rebro = double.Parse(Console.ReadLine());
            double size = Math.Pow(rebro, 3);
            double length = rebro * Math.Sqrt(3);
            Console.WriteLine("Объем куба: " + size);
            Console.WriteLine("Длина диагонали куба: " + length);


            Console.ReadKey();
        }
    }
}
