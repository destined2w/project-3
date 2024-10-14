using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x:");

            double x = double.Parse(Console.ReadLine());
            double y = Math.Sqrt((2 * x + Math.Sin(Math.Abs(3 * x))) / 3.56);

            Console.WriteLine("Результат: " + y);
            Console.ReadKey();
        }
    }
}
