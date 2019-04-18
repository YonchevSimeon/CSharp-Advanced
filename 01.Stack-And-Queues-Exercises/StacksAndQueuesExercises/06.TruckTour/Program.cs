using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int curr = 0; curr < petrolPumps; curr++)
            {
                pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }
            for (int curr = 0; curr < petrolPumps; curr++)
            {
                int tankFuel = 0;
                bool isFound = true;
                for (int index = 0; index < petrolPumps; index++)
                {
                    int[] currPump = pumps.Dequeue();
                    tankFuel += currPump[0] - currPump[1];
                    if(tankFuel < 0)
                    {
                        isFound = false;
                    }
                    pumps.Enqueue(currPump);
                }
                if (isFound)
                {
                    Console.WriteLine(curr);
                    return;
                }
                int[] origins = pumps.Dequeue();
                pumps.Enqueue(origins);
            }
        }
    }
}
