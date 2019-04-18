using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commandTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] inputTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            int queueSize = commandTokens[0];
            int dequeuedElements = commandTokens[1];
            int wantedNumber = commandTokens[2];
            for (int index = 0; index < queueSize; index++)
                queue.Enqueue(inputTokens[index]);
            for (int curr = 0; curr < dequeuedElements; curr++)
                queue.Dequeue();
            if (queue.Contains(wantedNumber))
                Console.WriteLine("true");
            else if (queue.Count < 1)
                Console.WriteLine(0);
            else
                Console.WriteLine(queue.Min());

        }
    }
}
