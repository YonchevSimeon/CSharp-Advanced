namespace _02.Sneaking
{
    using System;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            int boardRows = int.Parse(Console.ReadLine());
            char[][] board = new char[boardRows][];
            for (int row = 0; row < boardRows; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }
            char[] samMoves = Console.ReadLine().ToCharArray();


            int[] samCoordiantes = GetSamCoordinates(board);
            for (int move = 0; move < samMoves.Length; move++)
            {

                for (int row = 0; row < boardRows; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        if (board[row][col] == 'b' || board[row][col] == 'd')
                        {
                            if (board[row][col] == 'b')
                            {
                                if (col + 1 < board[row].Length)
                                {
                                    board[row][col] = '.';
                                    board[row][col + 1] = 'b';
                                }
                                else
                                {
                                    board[row][col] = 'd';
                                }
                                break;
                            }
                            else
                            {
                                if (col - 1 >= 0)
                                {
                                    board[row][col] = '.';
                                    board[row][col - 1] = 'd';
                                }
                                else
                                {
                                    board[row][col] = 'b';
                                }
                                break;
                            }
                            row++;
                        }
                    }
                }
                for (int left = 0; left < samCoordiantes[1]; left++)
                {
                    if (board[samCoordiantes[0]][left] == 'b')
                    {
                        board[samCoordiantes[0]][samCoordiantes[1]] = 'X';
                        Console.WriteLine($"Sam died at {samCoordiantes[0]}, {samCoordiantes[1]}");
                        foreach (char[] row in board)
                        {
                            Console.WriteLine(string.Join("", row));
                        }
                        return;
                    }
                }
                for (int right = samCoordiantes[1] + 1; right < board[samCoordiantes[0]].Length; right++)
                {
                    if (board[samCoordiantes[0]][right] == 'd')
                    {
                        board[samCoordiantes[0]][samCoordiantes[1]] = 'X';
                        Console.WriteLine($"Sam died at {samCoordiantes[0]}, {samCoordiantes[1]}");
                        foreach (char[] row in board)
                        {
                            Console.WriteLine(string.Join("", row));
                        }
                        return;
                    }
                }

                char directon = samMoves[move];
                switch (directon)
                {
                    case 'U':
                        board[samCoordiantes[0]][samCoordiantes[1]] = '.';
                        board[samCoordiantes[0] - 1][samCoordiantes[1]] = 'X';
                        samCoordiantes[0] = samCoordiantes[0] - 1;
                        break;
                    case 'D':
                        board[samCoordiantes[0]][samCoordiantes[1]] = '.';
                        board[samCoordiantes[0] + 1][samCoordiantes[1]] = 'X';
                        samCoordiantes[0] = samCoordiantes[0] + 1;
                        break;
                    case 'L':
                        board[samCoordiantes[0]][samCoordiantes[1]] = '.';
                        board[samCoordiantes[0]][samCoordiantes[1] - 1] = 'X';
                        samCoordiantes[1] = samCoordiantes[1] - 1;
                        break;
                    case 'R':
                        board[samCoordiantes[0]][samCoordiantes[1]] = '.';
                        board[samCoordiantes[0]][samCoordiantes[1] + 1] = 'X';
                        samCoordiantes[1] = samCoordiantes[1] + 1;
                        break;
                    case 'W': break;
                    default: break;
                }
                for (int col = 0; col < board[samCoordiantes[0]].Length; col++)
                {
                    if (board[samCoordiantes[0]][col] == 'N')
                    {
                        board[samCoordiantes[0]][col] = 'X';
                        board[samCoordiantes[0]][samCoordiantes[1]] = 'S';
                        Console.WriteLine("Nikoladze killed!");
                        foreach (char[] row in board)
                        {
                            Console.WriteLine(string.Join("", row));
                        }
                        return;
                    }
                }

                for (int left = 0; left < samCoordiantes[1]; left++)
                {
                    if (board[samCoordiantes[0]][left] == 'b')
                    {
                        board[samCoordiantes[0]][samCoordiantes[1]] = 'X';
                        Console.WriteLine($"Sam died at {samCoordiantes[0]}, {samCoordiantes[1]}");
                        foreach (char[] row in board)
                        {
                            Console.WriteLine(string.Join("", row));
                        }
                        return;
                    }
                }
                for (int right = samCoordiantes[1] + 1; right < board[samCoordiantes[0]].Length; right++)
                {
                    if (board[samCoordiantes[0]][right] == 'd')
                    {
                        board[samCoordiantes[0]][samCoordiantes[1]] = 'X';
                        Console.WriteLine($"Sam died at {samCoordiantes[0]}, {samCoordiantes[1]}");
                        foreach (char[] row in board)
                        {
                            Console.WriteLine(string.Join("", row));
                        }
                        return;
                    }

                }

            }
        }

        private static int[] GetSamCoordinates(char[][] board)
        {
            int[] samCoordinates = new int[2];
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'S')
                    {
                        samCoordinates[0] = row;
                        samCoordinates[1] = col;
                        return samCoordinates;
                    }
                }
            }
            return samCoordinates;
        }
    }
}
