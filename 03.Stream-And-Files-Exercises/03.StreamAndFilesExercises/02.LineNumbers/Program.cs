using System;
using System.IO;
namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //File.Delete("output.txt");
            using(StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    int line = 1;
                    string inputLine;
                    while((inputLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {line++}: {inputLine}");
                    }
                }
            }
        }
    }
}
