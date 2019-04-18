using System;
using System.Linq;
using System.Collections.Generic;
namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Predicate<string> isAllowedLength = name => name.Length <= maxLength;
            Func<List<string>, List<string>> allowedNames = list => 
            { return list.Where(name => isAllowedLength(name)).ToList(); };
            Console.WriteLine(string.Join(Environment.NewLine, allowedNames(names)));
        }
    }
}
