using System;
using System.Linq;
namespace _08.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] map = GetMap(); //works
            char[] commandArgs = Console.ReadLine().ToCharArray(); // works
            int[] playerCoordinates = GetPlayerCoordinates(map); //works
            ExecuteCommands(map, commandArgs, playerCoordinates); //works
        }

        private static int[] GetPlayerCoordinates(char[][] map)
        {
            int[] playerCoordinates = new int[2];
            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    if(map[row][col] == 'P')
                    {
                        playerCoordinates[0] = row;
                        playerCoordinates[1] = col;
                        return playerCoordinates;
                    }
                }
            }
            return playerCoordinates;
        }

        private static void ExecuteCommands(char[][] map, char[] commandArgs, int[] playerCoordinates)
        {
            int playerRow = playerCoordinates[0];
            int playerCol = playerCoordinates[1];
            bool won = false;
            bool died = false;
            foreach (char command in commandArgs)
            {
                switch (command)
                {
                    case 'U':
                        if(playerRow == 0)
                        {
                            won = true;
                            map[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if(map[playerRow - 1][playerCol] == 'B')
                            {
                                died = true;
                            }
                            else
                            {
                                map[playerRow - 1][playerCol] = 'P';
                                map[playerRow][playerCol] = '.';
                            }
                            playerRow--;
                        }
                        break;
                    case 'D':
                        if(playerRow == map.Length - 1)
                        {
                            won = true;
                            map[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if(map[playerRow + 1][playerCol] == 'B')
                            {
                                died = true;
                            }
                            else
                            {
                                map[playerRow + 1][playerCol] = 'P';
                                map[playerRow][playerCol] = '.';
                            }
                            playerRow++;
                        }
                        break;
                    case 'L':
                        if(playerCol == 0)
                        {
                            won = true;
                            map[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if(map[playerRow][playerCol - 1] == 'B')
                            {
                                died = true;
                            }
                            else
                            {
                                map[playerRow][playerCol - 1] = 'P';
                                map[playerRow][playerCol] = '.';
                            }
                            playerCol--;
                        }
                        break;
                    case 'R':
                        if(playerCol == map[playerRow].Length - 1)
                        {
                            won = true;
                            map[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if(map[playerRow][playerCol + 1] == 'B')
                            {
                                died = true;
                            }
                            else
                            {
                                map[playerRow][playerCol + 1] = 'P';
                                map[playerRow][playerCol] = '.';
                            }
                            playerCol++;
                        }
                        break;
                }
                MultiplyBunnies(map);
                if(map[playerRow][playerCol] == 'B')
                {
                    died = true;
                }
                if(won || died)
                {
                    string condition = won ? "won" : "dead";
                    PrintMap(map);
                    Console.WriteLine($"{condition}: {playerRow} {playerCol}");
                    return;
                }
            }
        }

        private static void PrintMap(char[][] map)
        {
            foreach (char[] row in map)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MultiplyBunnies(char[][] map)
        {
            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] != 'B')
                        continue;
                    AddBunny(map, row - 1, col);
                    AddBunny(map, row + 1, col);
                    AddBunny(map, row, col - 1);
                    AddBunny(map, row, col + 1);
                }
            }
            ReplaceSmallBunnies(map);
        }

        private static void ReplaceSmallBunnies(char[][] map)
        {
            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    if(map[row][col] == 'b')
                    {
                        map[row][col] = 'B';
                    }
                }
            }
        }

        private static void AddBunny(char[][] map, int row, int col)
        {
            if(IsInside(map, row, col))
            {
                if(map[row][col] != 'B')
                {
                    map[row][col] = 'b';
                }
            }
        }

        private static bool IsInside(char[][] map, int row, int col)
        {
            return row >= 0 && row < map.Length && col >= 0 && col < map[row].Length;
        }

        private static char[][] GetMap()
        {
            int[] inputTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = inputTokens[0];
            int cols = inputTokens[1];
            char[][] map = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                map[row] = Console.ReadLine().ToCharArray();
            }
            return map;
        }
    }
}
