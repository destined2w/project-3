using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n: ");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine("Результат: " + IsStatementTrue(n));
            Console.ReadKey();
            
        }
        static bool IsStatementTrue(double i)
        {
            return (i % 5 == 0) && (i % 7 != 0);
        }
    }
}
