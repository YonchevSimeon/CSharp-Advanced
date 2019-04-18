using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(input));
        }

        private static long GetFibonacci(int input)
        {
            Stack<long> fib = new Stack<long>(new[] { 0, 1l});
            for (int curr = 0; curr < input - 1; curr++)
            {
                long firstFib = fib.Pop();
                long secondFib = fib.Peek();
                fib.Push(firstFib);
                fib.Push(firstFib + secondFib);
            }
            return fib.Peek();
        }
    }
}
