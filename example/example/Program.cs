using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 42;       // Явно указан тип "int"
            string text = "Привет"; // Явно указан тип "string"
            Console.WriteLine(number.GetType().Name);
            Console.WriteLine(text.GetType().Name);

            var number1 = 42;       // Тип "int" задается автоматически
            var text1 = "Привет";   // Тип "string" задается автоматически
            Console.WriteLine(number1.GetType().Name);
            Console.WriteLine(text1.GetType().Name);

            int number2 = 42;
            double result = number2; // Неявная конверсия int -> double
            Console.WriteLine(number2.GetType().Name);
            Console.WriteLine(result.GetType().Name);

            double number3 = 42.58;
            int result1 = (int)number3; // Явная конверсия double -> int
            Console.WriteLine(result1); // Вывод: 42 (дробная часть отбрасывается)
            Console.WriteLine(number3.GetType().Name); 
            Console.WriteLine(result1.GetType().Name);

            string numberStr = "123";
            int number4 = Convert.ToInt32(numberStr); // Преобразование строки в число
            

            double value = 3.14;
            string valueStr = value.ToString(); // Преобразование числа в строку
            

            Console.WriteLine(number4);  // Вывод: 123
            Console.WriteLine(valueStr); // Вывод: "3.14"
            Console.WriteLine(number4.GetType().Name);
            Console.WriteLine(valueStr.GetType().Name);

            var rnd = new Random();
            Console.WriteLine(rnd);

            string input = "456";
            if (int.TryParse(input, out int result2))
            {
                Console.WriteLine($"Успешное преобразование: {result2}");
            }
            else
            {
                Console.WriteLine("Ошибка преобразования.");
            }
            Console.ReadKey();
        }
    }
}
