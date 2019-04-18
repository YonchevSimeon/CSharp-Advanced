using System;
using System.Linq;
namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[squareMatrixSize][];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[rows] = currRow;
            }
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                primaryDiagonal += matrix[rows][rows];
                secondaryDiagonal += matrix[rows][matrix.Length - 1 - rows];
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
