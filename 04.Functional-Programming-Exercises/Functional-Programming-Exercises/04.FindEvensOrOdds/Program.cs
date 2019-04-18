using System;
using System.Linq;
using System.Collections.Generic;
namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeBounds = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
            string type = Console.ReadLine().ToLower();
            Predicate<int> isEven = number => number % 2 == 0;
            List<int> numbers = GetListOfIntegers(rangeBounds, type, isEven);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> GetListOfIntegers(int[] rangeBounds, string type, Predicate<int> isEven)
        {
            List<int> list = new List<int>();
            int startNumber = rangeBounds[0];
            int endNumber = rangeBounds[1];
            for (int num = startNumber; num <= endNumber; num++)
            {
                if ((!isEven(num) && type == "odd") || (isEven(num) && type == "even"))
                    list.Add(num);
            }
            return list;
        }
    }
}
