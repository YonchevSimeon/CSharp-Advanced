using System;
using System.Linq;
namespace _10.TheHeiganDance_Naxxramas
{
    class Program
    {
        private static int[] playerPosition;
        static void Main(string[] args)
        {

            decimal playerHealthPoints = 18500;
            decimal heiganHealthPoints = 3000000;
            playerPosition = new int[] { 7, 7 };
            int damageOverTime = 0;
            string lastCastSpell = string.Empty;


            decimal playerAttackDamage = decimal.Parse(Console.ReadLine());

            while (true)
            {
                heiganHealthPoints -= playerAttackDamage;
                playerHealthPoints -= damageOverTime;
                damageOverTime = 0;

                if (IsSomeoneDead(playerHealthPoints, heiganHealthPoints))
                {
                    PrintResult(heiganHealthPoints, playerHealthPoints, lastCastSpell);
                    return;
                }

                string[] heiganTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                lastCastSpell = heiganTokens[0];
                int spellRow = int.Parse(heiganTokens[1]);
                int spellCol = int.Parse(heiganTokens[2]);
                lastCastSpell = lastCastSpell == "Cloud" ? "Plague Cloud" : lastCastSpell;
                if (CalculateIfHeiganDoesDamage(spellRow, spellCol))
                {
                    playerHealthPoints = HeiganDoesDamage(playerHealthPoints, lastCastSpell);
                    if (lastCastSpell == "Plague Cloud")
                    {
                        damageOverTime = 3500;
                    }
                }
                

                if (IsSomeoneDead(playerHealthPoints, heiganHealthPoints))
                {
                    PrintResult(heiganHealthPoints, playerHealthPoints, lastCastSpell);
                    return;
                }
            }
            
        }

        private static decimal HeiganDoesDamage(decimal playerHealthPoints, string lastCastSpell)
        {
            if (lastCastSpell == "Plague Cloud")
                playerHealthPoints -= 3500;
            else
                playerHealthPoints -= 6000;
            return playerHealthPoints;
        }

        private static bool CalculateIfHeiganDoesDamage(int spellRow, int spellCol)
        {
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];
            if(!IsPlayerInHeiganRange(playerRow, playerCol, spellRow, spellCol))
            {
                return false;
            }
            if(CanPlayerEscape(playerRow - 1, playerCol, spellRow, spellCol))
            {
                return false;
            }
            if(CanPlayerEscape(playerRow, playerCol + 1, spellRow, spellCol))
            {
                return false;
            }
            if (CanPlayerEscape(playerRow + 1, playerCol, spellRow, spellCol))
            {
                return false;
            }
            if (CanPlayerEscape(playerRow, playerCol - 1, spellRow, spellCol))
            {
                return false;
            }
            return true;
        }

        private static bool CanPlayerEscape(int playerRow, int playerCol, int spellRow, int spellCol)
        {
            if(IsInsideMatrx(playerRow, playerCol) && !IsPlayerInHeiganRange(playerRow, playerCol, spellRow, spellCol))
            {
                playerPosition[0] = playerRow;
                playerPosition[1] = playerCol;
                return true;
            }
            return false;
        }

        private static bool IsInsideMatrx(int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < 15 && playerCol >= 0 && playerCol < 15;
        }

        private static bool IsPlayerInHeiganRange(int playerRow, int playerCol, int spellRow, int spellCol)
        {
            if ((spellRow - 1 <= playerRow && playerRow <= spellRow + 1) &&
                (spellCol -1 <= playerCol && playerCol <= spellCol + 1))
                return true;
            return false;
        }

        private static void PrintResult(decimal heiganHealthPoints, decimal playerHealthPoints, string lastCastSpell)
        {
            if(heiganHealthPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHealthPoints:f2}");
            }
            if(playerHealthPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastCastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealthPoints}");
            }
            Console.WriteLine($"Final position: {string.Join(", ", playerPosition)}");
        }

        private static bool IsSomeoneDead(decimal playerHealthPoints, decimal heiganHealthPoints)
        {
            return playerHealthPoints <= 0 || heiganHealthPoints <= 0;
        }
    }
}
