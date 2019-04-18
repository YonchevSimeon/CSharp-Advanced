using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = GetMatrix(); //works
            NukeMatrix(matrix); //works
            PrintMatrix(matrix); //works
        }

        private static void NukeMatrix(List<List<int>> matrix)
        {
            string inputToken;
            while ((inputToken = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] nukeTokens = inputToken
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                int nukeRow = nukeTokens[0];
                int nukeCol = nukeTokens[1];
                int nukeRadius = nukeTokens[2];
                Nuke(matrix, nukeRow, nukeCol, nukeRadius);
                ArrangeMatrix(matrix);
            }
        }

        private static void ArrangeMatrix(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if(matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static void Nuke(List<List<int>> matrix, int nukeRow, int nukeCol, int nukeRadius)
        {
            for (int row = Math.Max(0, nukeRow - nukeRadius); row <= Math.Min(nukeRow + nukeRadius, matrix.Count - 1); row++)
            {
                List<int> theRow = new List<int>();
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if(!ElementInRange(matrix, row, col, nukeRow, nukeCol, nukeRadius))
                    {
                        theRow.Add(matrix[row][col]);
                    }
                }
                matrix[row] = theRow;
            }
        }

        private static bool ElementInRange(List<List<int>> matrix, int row, int col, int nukeRow, int nukeCol, int nukeRadius)
        {
            if((row == nukeRow && col >= Math.Max(nukeCol - nukeRadius, 0) &&
                col <= Math.Min(nukeCol + nukeRadius, matrix[row].Count - 1)) || col == nukeCol)
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (List<int> row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static List<List<int>> GetMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            List<List<int>> matrix = new List<List<int>>();
            int count = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(count++);
                }
            }
            return matrix;
        }
    }
}
