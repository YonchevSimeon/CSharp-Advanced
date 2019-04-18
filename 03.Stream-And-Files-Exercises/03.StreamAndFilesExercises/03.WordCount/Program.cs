using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string inputLine;
                while((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.ToLower();
                    if (!words.ContainsKey(inputLine))
                    {
                        words[inputLine] = 0;
                    }
                }
            }
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("result.txt"))
                {
                    string inputLine;
                    while((inputLine = reader.ReadLine()) != null)
                    {
                        string[] currentLine = inputLine
                            .Split("(){}[],.:;!?- \'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(w => w.ToLower())
                            .ToArray();
                        foreach (string word in currentLine)
                        {
                            if(words.ContainsKey(word))
                                words[word]++;
                        }
                    }
                    foreach (KeyValuePair<string, int> word in words.OrderByDescending(o => o.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
