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
            double y = Value(x);
            Console.WriteLine("Результат: " + y);
            Console.ReadKey();

            static double Value(double a)
            {
                return (Math.Sqrt((2 * a + Math.Sin(Math.Abs(3 * a))) / 3.56));
            }
            
        }
    }
}
