using System;
using System.Linq;
using System.Text;

namespace _01.MatrixOfPalindromes
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
            string[][] matrix = new string[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];
                for (int col = 0; col < cols; col++)
                {
                    char first = (char)('a' + row);
                    char second = (char)(first + col);
                    StringBuilder palindrome = new StringBuilder();
                    palindrome.Append(first).Append(second).Append(first);
                    matrix[row][col] = palindrome.ToString();
                }
            }
            foreach (string[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
