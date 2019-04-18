using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printNames = (names) => { Console.WriteLine(string.Join(Environment.NewLine, names)); };
            printNames(inputTokens);
        }
    }
}
