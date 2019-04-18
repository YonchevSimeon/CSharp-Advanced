using System;
using System.Linq;
namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> minValue = (numbers) => { return numbers.Min(); };
            Console.WriteLine(minValue(inputTokens));
        }
    }
}
