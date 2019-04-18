using System;
using System.Linq;
namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int[]> add = nums => { return nums.Select(x => x = x + 1).ToArray(); };
            Func<int[], int[]> multiply = nums => { return nums.Select(x => x = x * 2).ToArray(); };
            Func<int[], int[]> subtract = nums => { return nums.Select(x => x = x - 1).ToArray(); };
            string input;
            while((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default: break;
                }
            }
        }
    }
}
