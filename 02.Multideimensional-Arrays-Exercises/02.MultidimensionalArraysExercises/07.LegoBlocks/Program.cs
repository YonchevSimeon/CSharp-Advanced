using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());
            int[][] firstArray = FillJaggedArray(arraySize);
            int[][] secondArray = FillJaggedArray(arraySize);
            bool areArraysFitting = CheckForFitting(firstArray, secondArray);
            if (areArraysFitting)
            {
                PrintFittedArrays(firstArray, secondArray);
            }
            else
            {
                PrintNumberOfCells(firstArray, secondArray);
            }
        }

        private static void PrintFittedArrays(int[][] firstArray, int[][] secondArray)
        {
            for (int row = 0; row < firstArray.Length; row++)
            {
                List<int> curr = new List<int>();
                curr.AddRange(firstArray[row]);
                curr.AddRange(secondArray[row].Reverse());
                Console.WriteLine($"[{string.Join(", ", curr)}]");
            }
        }

        private static void PrintNumberOfCells(int[][] firstArray, int[][] secondArray)
        {
            int counter = 0;
            counter += GetNumberOfCells(firstArray);
            counter += GetNumberOfCells(secondArray);
            Console.WriteLine($"The total number of cells is: {counter}");
        }

        private static int GetNumberOfCells(int[][] arr)
        {
            int counter = 0;
            for (int row = 0; row < arr.Length; row++)
            {
                for (int col = 0; col < arr[row].Length; col++)
                {
                    counter++;
                }
            }
            return counter;
        }

        private static bool CheckForFitting(int[][] firstArray, int[][] secondArray)
        {
            int count = firstArray[0].Length + secondArray[0].Length;
            for (int row = 1; row < firstArray.Length; row++)
            {
                if (firstArray[row].Length + secondArray[row].Length != count)
                {
                    return false;
                }
            }
            return true;
        }

        private static int[][] FillJaggedArray(int arraySize)
        {
            int[][] arr = new int[arraySize][];
            for (int row = 0; row < arraySize; row++)
            {
                arr[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            return arr;
        }
    }
}
