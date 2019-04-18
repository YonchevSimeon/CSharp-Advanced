using System;
using System.Linq;
using System.Collections.Generic;
namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Predicate<int> isEven = n => n % 2 == 0;
            Func<List<int>, List<int>> ordered = nums => 
            {
                List<int> orderedEvenNums = new List<int>();
                List<int> otherNums = new List<int>();
                foreach (int num in nums)
                {
                    if (isEven(num))
                    {
                        orderedEvenNums.Add(num);
                    }
                    else
                    {
                        otherNums.Add(num);
                    }
                }
                orderedEvenNums = orderedEvenNums.OrderBy(x => x).ToList();
                foreach (int num in otherNums.OrderBy(x => x))
                {
                    orderedEvenNums.Add(num);
                }
                return orderedEvenNums;
            };
            Console.WriteLine(string.Join(" ", ordered(numbers)));
        }
    }
}
