using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст используя кириллицу: ");
            var t = Console.ReadLine();
            Console.WriteLine("Текст на языке CS: ");
            Console.WriteLine(CsTranslate(t));
            Console.ReadKey();
        }
        static string CsTranslate(String s)
        {
            return s
                .ToUpper()
                .Replace("А", "A")
                .Replace("Б", "6")
                .Replace("В", "B")
                .Replace("Г", "r")
                .Replace("Д", "D")
                .Replace("Е", "E")
                .Replace("Ё", "E")
                .Replace("Ж", "}|{")
                .Replace("З", "3")
                .Replace("И", "u")
                .Replace("Й", "u*")
                .Replace("К", "K")
                .Replace("Л", "JI")
                .Replace("М", "M")
                .Replace("Н", "N")
                .Replace("О", "O")
                .Replace("П", "n")
                .Replace("Р", "P")
                .Replace("С", "C")
                .Replace("Т", "T")
                .Replace("У", "Y")
                .Replace("Ф", "cp")
                .Replace("Х", "X")
                .Replace("Ц", "L|")
                .Replace("Ч", "4")
                .Replace("Ш", "LLI")
                .Replace("Щ", "LLL")
                .Replace("Ъ", "`b")
                .Replace("Ы", "bI")
                .Replace("Ь", "b")
                .Replace("Э", "-)")
                .Replace("Ю", "IO")
                .Replace("Я", "9I");
        }
    }
}
