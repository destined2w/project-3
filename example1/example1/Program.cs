using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isAdult = true;
            bool hasPermission = false; // Примеры значений данных типа bool

            // Пример логического И
            bool isRegistered = true;
            bool hasPaid = false;
            bool canAccess = isRegistered && hasPaid;
            Console.WriteLine(canAccess); // false

            // Пример логического ИЛИ
            bool isAdmin = true;
            bool isModerator = false;
            bool hasAccess = isAdmin || isModerator; // hasAccess = true
            Console.WriteLine(hasAccess); 

            // Пример логического НЕ
            bool isBlocked = false;
            bool canLogin = !isBlocked;
            Console.WriteLine(canLogin); 

            // Пример исключающего ИЛИ
            bool a = true;
            bool b = false;
            bool result = a ^ b; // result = true
            Console.WriteLine(result);

            // Пример, где учитывается приоритет:
            bool a1 = true;
            bool b1 = false;
            bool c1 = true;
            bool result1 = a1 || b1 && !c1;
            Console.WriteLine(result1);

            // Пример использования в условии
            int age = 16;
            bool isMember = true;
            if (age >= 18 && isMember)
            {
                Console.WriteLine("Доступ разрешен.");
            }
            else
            {
                Console.WriteLine("Доступ запрещен.");
            }
            Console.ReadKey();
        }
    }
}
