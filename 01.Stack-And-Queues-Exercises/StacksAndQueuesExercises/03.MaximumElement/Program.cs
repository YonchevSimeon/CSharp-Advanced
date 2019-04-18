using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            Stack<int> max = new Stack<int>();
            
            for (int curr = 0; curr < queries; curr++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (tokens[0])
                {
                    case 1:
                        numbers.Push(tokens[1]);
                        if (max.Count == 0 || max.Peek() < tokens[1])
                            max.Push(tokens[1]);
                        break;
                    case 2:
                        if(numbers.Count > 0)
                        {
                            int removed = numbers.Pop();
                            if(max.Count > 0 && max.Peek() == removed)
                            {
                                max.Pop();
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(max.Peek());
                        break;
                    default: break;
                }
            }
        }
    }
}

