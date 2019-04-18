using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            long maxSum = long.MinValue;
            Stack<int[]> matrixSums = new Stack<int[]>();
            for (int row1 = 0; row1 < rows - 2; row1++)
            {
                for (int col1 = 0; col1 < cols - 2; col1++)
                {
                    long currSum = 0;
                    for (int r = row1; r < row1 + 3; r++)
                    {
                        currSum += matrix[r].Skip(col1).Take(3).Sum();
                    }
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        matrixSums.Push(new[] { row1, col1 });
                    }
                }
            }
            int[] wantedRowOfTheMatrix = matrixSums.Pop();
            int finalRow = wantedRowOfTheMatrix[0];
            int finalCol = wantedRowOfTheMatrix[1];
            Console.WriteLine($"Sum = {maxSum}");
            for (int r = finalRow; r < finalRow + 3; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r].Skip(finalCol).Take(3)));
            }
        }
    }
}
