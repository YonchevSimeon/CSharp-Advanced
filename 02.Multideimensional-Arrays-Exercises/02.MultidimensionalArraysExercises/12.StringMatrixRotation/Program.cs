using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = GetDegrees();
            char[][] matrix = GetMatrix();
            switch (degrees)
            {
                case 0: Print0(matrix); break;
                case 90: Print90(matrix); break;
                case 180: Print180(matrix); break;
                case 270: Print270(matrix); break;
            }
        }

        private static void Print270(char[][] matrix)
        {
            for (int col = matrix[0].Length - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void Print180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                Console.WriteLine(string.Join("", matrix[row].Reverse()));
            }
        }

        private static void Print90(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void Print0(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] GetMatrix()
        {
            List<string> words = new List<string>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                words.Add(input);
            }
            int rows = words.Count();
            int cols = words.Select(col => col.Count()).Max();
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                StringBuilder builder = new StringBuilder(words[row]);
                builder.Append(new string(' ', cols - words[row].Length));
                matrix[row] = builder.ToString().ToCharArray();
            }
            return matrix;
        }

        private static int GetDegrees()
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(tokens[1]) % 360;
            if (degrees < 0)
                degrees += 360;
            return degrees;
        }
    }
}
