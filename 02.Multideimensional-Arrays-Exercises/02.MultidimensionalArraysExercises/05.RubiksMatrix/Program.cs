using System;
using System.Linq;
namespace _05.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = FillTheMatrix();
            matrix = RotateMatrix(matrix);
            PrintResult(matrix);
        }

        private static void PrintResult(int[][] matrix)
        {
            int searchedNumber = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if(matrix[row][col] == searchedNumber)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rows = 0; rows < matrix.Length; rows++)
                        {
                            for (int cols = 0; cols < matrix[0].Length; cols++)
                            {
                                if(matrix[rows][cols] == searchedNumber)
                                {
                                    matrix[rows][cols] = matrix[row][col];
                                    matrix[row][col] = searchedNumber;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({rows}, {cols})");
                                    break;
                                }
                            }
                        } 
                    }
                    searchedNumber++;
                }
            }
        }

        private static int[][] RotateMatrix(int[][] matrix)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int currCommand = 0; currCommand < numberOfCommands; currCommand++)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int colOrRow = int.Parse(inputTokens[0]);
                string direction = inputTokens[1];
                int rotations = int.Parse(inputTokens[2]);
                if(direction == "up")
                {
                    matrix = RotateMatrixUp(matrix, colOrRow, rotations);
                }
                else if(direction == "down")
                {
                    matrix = RotateMatrixDown(matrix, colOrRow, rotations);
                }
                else if(direction == "left")
                {
                    matrix[colOrRow] = RotateMatrixLeft(matrix[colOrRow], rotations);
                }
                else
                {
                    matrix[colOrRow] = RotateMatrixRight(matrix[colOrRow], rotations);
                }
            }
            return matrix;
        }

        private static int[] RotateMatrixRight(int[] row, int rotations)
        {

            rotations %= row.Length;
            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int lastValue = row[row.Length - 1];
                for (int curr = row.Length - 1; curr >= 1; curr--)
                {
                    row[curr] = row[curr - 1];
                }
                row[0] = lastValue;
            }
            return row;
        }

        private static int[] RotateMatrixLeft(int[] row, int rotations)
        {

            rotations %= row.Length;
            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int firstValue = row[0];
                for (int curr = 0; curr < row.Length - 1; curr++)
                {
                    row[curr] = row[curr + 1];
                }
                row[row.Length - 1] = firstValue;
            }
            return row;
        }

        private static int[][] RotateMatrixDown(int[][] matrix, int col, int rotations)
        {

            rotations %= matrix.Length;
            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int lastColValue = matrix[matrix.Length - 1][col];
                for (int row = matrix.Length - 1; row >= 1; row--)
                {
                    matrix[row][col] = matrix[row - 1][col];
                }
                matrix[0][col] = lastColValue;
            } 
            return matrix;
        }

        private static int[][] RotateMatrixUp(int[][] matrix, int col, int rotations)
        {
            rotations %= matrix.Length;
            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int firstColValue = matrix[0][col];
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][col] = matrix[row + 1][col];
                }
                matrix[matrix.Length - 1][col] = firstColValue;
            }
            return matrix;
        }

        private static int[][] FillTheMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[][] matrix = new int[rows][];
            int filledNumber = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = filledNumber++;
                }
            }
            return matrix;
        }
    }
}
