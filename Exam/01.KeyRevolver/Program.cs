namespace _01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int spendPriceForBullets = 0;
            int counter = 0;
            while (true)
            {
                int bullet = bullets.Peek();
                int locker = locks.Peek();
                if (bullet <= locker)
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }
                spendPriceForBullets++;
                counter++;
                if (counter == sizeOfTheGunBarrel && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
                if (bullets.Count <= 0 || locks.Count <= 0)
                {
                    break;
                }


            }
            if (bullets.Count >= 0 && locks.Count == 0)
            {
                int safeValue = valueOfIntelligence - (pricePerBullet * spendPriceForBullets);
                if (safeValue < 0)
                    safeValue = 0;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${safeValue}");
            }
            else if (bullets.Count == 0 && locks.Count >= 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}