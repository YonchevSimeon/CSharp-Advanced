using System;
using System.IO;
namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int line = 1;
                string inputLine;
                while((inputLine = reader.ReadLine()) != null)
                {
                    if(line % 2 == 0)
                    {
                        Console.WriteLine(inputLine);
                    }
                    line++;
                }
            }
        }
    }
}
