using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commandTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] inputTokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int stackSize = commandTokens[0];
            int poppedElements = commandTokens[1];
            int wantedNumber = commandTokens[2];
            for (int curr = 0; curr < stackSize; curr++)
                stack.Push(inputTokens[curr]);
            for (int curr = 0; curr < poppedElements; curr++)
                stack.Pop();
            if (stack.Contains(wantedNumber))
                Console.WriteLine("true");
            else if(stack.Count < 1)
                Console.WriteLine(0);
            else
                Console.WriteLine(stack.Min());
        }
    }
}
