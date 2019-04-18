using System;
using System.Linq;
namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printWithSir = (names) => { Console.WriteLine(string.Join(Environment.NewLine,
                names.Select(x => x = "Sir " + x))); };
            printWithSir(inputTokens);
        }
    }
}
