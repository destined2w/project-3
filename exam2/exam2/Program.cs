using System;
using System.Numerics;


namespace exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Roundness(20, 2));

            Console.WriteLine("R(10!)" + TotalRoundness(10));
            Console.WriteLine("R(13!) = " + TotalRoundness(13));
            Console.WriteLine("R(15!) = " + TotalRoundness(15));
            Console.WriteLine("R(20!) = " + TotalRoundness(20));
            Console.WriteLine("R(30!) = " + TotalRoundness(30));
            Console.ReadKey();
        }
        static int Roundness(BigInteger n, int b)
        {
            int count = 0;
            while (n % b == 0)
            {
                count++;
                n /= b;
            }
            return count;
        }
        static BigInteger Factorial(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static int TotalRoundness(int n)
        {
            BigInteger fact = Factorial(n);
            int total = 0;
            for (int b = 2; b <= fact; b++)
            {
                
                total += Roundness(fact, b);
            }
            return total;
        }
    }
}
