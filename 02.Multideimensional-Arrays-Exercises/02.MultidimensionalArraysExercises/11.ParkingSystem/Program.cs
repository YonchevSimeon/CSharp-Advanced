using System;
using System.Linq;
using System.Collections.Generic;
namespace _11.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();
            int[] parkingSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = parkingSize[0];
            int cols = parkingSize[1];
            string input;
            while((input = Console.ReadLine()) != "stop")
            {
                int[] carTokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int entryRow = carTokens[0];
                int desiredSpotRow = carTokens[1];
                int desiredSpotCol = carTokens[2];
                if(!DesiredSpotFree(parking, desiredSpotRow, desiredSpotCol))
                {
                    TakeTheSpot(parking, desiredSpotRow, desiredSpotCol);
                    Console.WriteLine(DistanceTravelled(entryRow, desiredSpotRow, desiredSpotCol));
                }
                else
                {
                    desiredSpotCol = GetFreeSpot(parking[desiredSpotRow], desiredSpotCol, cols);
                    if(desiredSpotCol == 0)
                    {
                        Console.WriteLine($"Row {desiredSpotRow} full");
                    }
                    else
                    {
                        TakeTheSpot(parking, desiredSpotRow, desiredSpotCol);
                        Console.WriteLine(DistanceTravelled(entryRow, desiredSpotRow, desiredSpotCol));
                    }
                }
            }
        }

        private static int GetFreeSpot(HashSet<int> row, int desiredSpotCol, int cols)
        {
            int newCol = 0;
            int minimal = int.MaxValue;
            if(row.Count == cols - 1)
            {
                return newCol;
            }
            for (int col = 1; col < cols; col++)
            {
                int curr = Math.Abs(desiredSpotCol - col);
                if (!row.Contains(col) && curr < minimal)
                {
                    newCol = col;
                    minimal = curr;
                }
            }
            return newCol;
        }

        private static long DistanceTravelled(int entryRow, int desiredSpotRow, int desiredSpotCol)
        {
            return Math.Abs(desiredSpotRow - entryRow) + desiredSpotCol + 1;
        }

        private static void TakeTheSpot(Dictionary<int, HashSet<int>> parking, int desiredSpotRow, int desiredSpotCol)
        {
            if (!parking.ContainsKey(desiredSpotRow))
                parking[desiredSpotRow] = new HashSet<int>();
            parking[desiredSpotRow].Add(desiredSpotCol);
        }

        private static bool DesiredSpotFree(Dictionary<int, HashSet<int>> parking, int desiredSpotRow, int desiredSpotCol)
        {
            return parking.ContainsKey(desiredSpotRow) && parking[desiredSpotRow].Contains(desiredSpotCol);
        }
    }
}
