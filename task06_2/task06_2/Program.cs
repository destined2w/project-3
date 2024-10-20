using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task06_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var word = "трос";
            var word1 = new string(word.Reverse().ToArray());
            var word2 = word.Remove(0, 1) + word.Remove(1, 3); 
            Console.WriteLine("Исходное слово: " + word);
            Console.WriteLine("Первое преобразованное слово: " + word1);
            Console.WriteLine("Второе преобразованное слово: " + word2);
            Console.ReadKey();
        }
    }
}
