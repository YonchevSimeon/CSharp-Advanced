using System;
using System.Linq;
namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, int> sumOfChars = name => name.ToCharArray().Sum(x => x);
            Func<string, int, bool> isItsSumEqualOrLarger = (name, sum) => sumOfChars(name) >= sum;
            string theName = names.FirstOrDefault(name => isItsSumEqualOrLarger(name, number));
            Console.WriteLine(theName);
        }
    }
}
