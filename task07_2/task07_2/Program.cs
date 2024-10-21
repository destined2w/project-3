using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число x: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите число y: ");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Результат: " + IsStatementTrue(x, y));
            Console.ReadKey();

        }
        static bool IsStatementTrue(double x, double y)
        {
            return (x >= 2 && y >= 0) || (x >= 1 && y <= -1);
        }
    }
}