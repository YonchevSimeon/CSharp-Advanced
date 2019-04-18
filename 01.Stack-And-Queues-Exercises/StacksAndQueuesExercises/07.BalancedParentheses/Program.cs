using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            foreach (char c in input)
            {
                switch (c)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(c);
                        break;
                    case '}':
                        if (stack.Count < 1)
                            isBalanced = false;
                        else if (stack.Pop() != '{')
                            isBalanced = false;
                        break;
                    case ')':
                        if (stack.Count < 1)
                            isBalanced = false;
                        else if (stack.Pop() != '(')
                            isBalanced = false;
                        break;
                    case ']':
                        if (stack.Count < 1)
                            isBalanced = false;
                        else if (stack.Pop() != '[')
                            isBalanced = false;
                        break;
                }
                if (!isBalanced)
                    break;
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
