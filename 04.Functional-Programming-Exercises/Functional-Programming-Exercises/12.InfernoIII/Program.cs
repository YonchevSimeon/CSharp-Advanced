using System;
using System.Linq;
using System.Collections.Generic;
namespace _12.InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            HashSet<string> commands = GetCommands();
            Console.WriteLine(string.Join(" ", FilteredGems(gems, commands)));
        }

        private static List<int> FilteredGems(List<int> gems, HashSet<string> commands)
        {
            List<int> filteredGems = new List<int>();
            for (int index = 0; index < gems.Count; index++)
            {
                bool isGood = true;
                foreach (string command in commands)
                {
                    string[] commandTokens = command
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string type = commandTokens[0];
                    int model = int.Parse(commandTokens[1]);
                    Dictionary<string, Func<int, int>> filters = new Dictionary<string, Func<int, int>>();
                    filters["Sum Right"] = n => gems[n] + (n == gems.Count - 1 ? 0 : gems[n + 1]);
                    filters["Sum Left"] = n => gems[n] + (n == 0 ? 0 : gems[n - 1]);
                    filters["Sum Left Right"] = n => filters["Sum Left"](n) + filters["Sum Right"](n) - gems[n];
                    int sum = 0;
                    if (filters.ContainsKey(type))
                        sum = filters[type](index);
                    if (sum == model)
                    {
                        isGood = false;
                        break;
                    }
                }
                if (isGood)
                {
                    filteredGems.Add(gems[index]);
                }
            }
            return filteredGems;
        }

        private static HashSet<string> GetCommands()
        {
            HashSet<string> commands = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                string[] inputTokens = input
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputTokens[0];
                string type = inputTokens[1];
                string model = inputTokens[2];
                if (command == "Exclude")
                {
                    commands.Add(type + ";" + model);
                }
                else
                {
                    commands.Remove(type + ";" + model);
                }
            }
            return commands;
        }
    }
}

