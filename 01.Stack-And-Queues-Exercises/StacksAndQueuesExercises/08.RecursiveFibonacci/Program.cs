using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] fib;
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            fib = new long[input];
            Console.WriteLine(GetFibonacci(input - 1));
        }

        private static long GetFibonacci(int v)
        {
            if (v <= 1)
                return 1;
            if (fib[v] == 0)
                fib[v] = GetFibonacci(v - 1) + GetFibonacci(v - 2);
            return fib[v];
        }
    }
}
