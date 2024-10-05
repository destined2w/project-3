using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] time = { 0, 65, 130, 195, 260, 325, 390, 455, 520, 585, 650, 715 };
            Console.WriteLine("Введите часы: ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите минуты: ");
            int n = int.Parse(Console.ReadLine());
            int t = m * 60 + n;
            foreach (int i in time)
            {
                if (i > t) {
                    Console.WriteLine("Стрелки совпадут через: " + (i - t) + " минут");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
