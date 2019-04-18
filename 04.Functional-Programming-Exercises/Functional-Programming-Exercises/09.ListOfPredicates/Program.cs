using System;
using System.Linq;
using System.Collections.Generic;
namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.Parse(Console.ReadLine());
            List<int> predicates = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();
            List<int> numbers = GetNumbers(maxNum, predicates);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> GetNumbers(int maxNum, List<int> predicates)
        {
            List<int> numbers = new List<int>();
            for (int num = 1; num <= maxNum; num++)
            {
                bool divisble = true;
                foreach (int predicate in predicates)
                {
                    //Predicate<int> isDivisible = n => n % predicate == 0;
                    if (num % predicate != 0)
                    {
                        divisble = false;
                        break;
                    }
                }
                if(divisble)
                numbers.Add(num);
            }
            return numbers;
        }
    }
}
