﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        { 
            Stack<int> numbers = new Stack<int>(
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
