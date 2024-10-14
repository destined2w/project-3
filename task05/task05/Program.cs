using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double y = Value(2+Value(3+Value(4+Value(5))));
            Console.WriteLine("Результат: " + Math.Round(y, 3));
            Console.ReadKey();

            static double Value(double x)
            {
                return (Math.Sqrt(x));

            }

        }
    }
}
