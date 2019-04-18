using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateSequenceWIthQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(input);
            long currentS = input;
            int skipped = 0;
            for (int curr = 0; curr < 49; curr++)
            {
                if (curr % 3 == 0)
                {
                    currentS = queue.ToArray().Skip(skipped).Take(1).ToArray()[0];
                    queue.Enqueue(currentS + 1);
                    skipped++;
                }
                else if (curr % 3 == 1)
                {
                    queue.Enqueue(2 * (currentS) + 1);
                }
                else if (curr % 3 == 2)
                {
                    queue.Enqueue(currentS + 2);
                }
            }
            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
