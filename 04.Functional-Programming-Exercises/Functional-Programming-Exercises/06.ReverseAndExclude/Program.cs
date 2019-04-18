using System;
using System.Linq;
using System.Collections.Generic;
namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divisibleNumber = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = number => number % divisibleNumber == 0;
            Func<List<int>, List<int>> notDivisible = nums => { return nums.Where(x => !isDivisible(x)).Reverse().ToList(); };
            Console.WriteLine(string.Join(" ", notDivisible(numbers)));
        }
    }
}
