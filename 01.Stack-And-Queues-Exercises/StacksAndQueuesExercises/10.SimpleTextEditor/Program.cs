using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> stack = new Stack<string>();
            for (int curr = 0; curr < numberOfOperations; curr++)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int typeOfOperation = int.Parse(inputTokens[0]);
                switch (typeOfOperation)
                {
                    case 1:
                        stack.Push(text);
                        text += inputTokens[1];
                        break;
                    case 2:
                        stack.Push(text);
                        int eraseCount = int.Parse(inputTokens[1]);
                        text = text.Substring(0, text.Length - eraseCount);
                        break;
                    case 3:
                        int index = int.Parse(inputTokens[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = stack.Pop();
                        break;
                    default: break;
                }
            }
        }
    }
}
