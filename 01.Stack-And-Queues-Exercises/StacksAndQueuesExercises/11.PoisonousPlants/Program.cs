using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] originalPlants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] days = new int[numberOfPlants];
            Stack<int> plants = new Stack<int>();
            plants.Push(0);
            for (int index = 1; index < numberOfPlants; index++)
            {
                int maxDays = 0;
                while(plants.Count != 0 && originalPlants[plants.Peek()] >= originalPlants[index])
                {
                    maxDays = Math.Max(maxDays, days[plants.Pop()]);
                }
                if(plants.Count != 0)
                {
                    days[index] = maxDays + 1;
                }
                plants.Push(index);
            }
            Console.WriteLine(days.Max());
        }
    }
}
