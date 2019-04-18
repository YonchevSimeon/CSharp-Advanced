﻿using System;
using System.Linq;
namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = FillMatrix();
            matrix = ShotFired(matrix);
            matrix = Gravity(matrix);
            PrintMatrix(matrix);
        }

        private static char[,] Gravity(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int emptyRows = 0;
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if(emptyRows > 0)
                    {
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] ShotFired(char[,] matrix)
        {
            int[] shot = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = shot[0];
            int col = shot[1];
            int radius = shot[2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int ro = row - r;
                    int co = col - c;
                    double distance = Math.Sqrt(ro * ro + co * co);
                    if(distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static char[,] FillMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();

            int rows = matrixSize[0];
            int cols = matrixSize[1];
            char[,] matrix = new char[rows, cols];

            bool isGoingLeft = true;
            int snakeIndex = 0;
            for (int row = rows - 1; row >= 0; row--)
            {
                int index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;
                int increment = isGoingLeft ? -1 : 1;
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, index] = snake[snakeIndex++];
                    if(snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                    index += increment;
                }
                isGoingLeft = !isGoingLeft;
            }
            return matrix;
        }
    }
}
