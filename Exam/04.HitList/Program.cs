namespace _04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> persons = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, int> personsInfo = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] inputTokens = input.Split(new char[] { ':', ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = inputTokens[0];
                for (int index = 1; index < inputTokens.Length; index += 2)
                {

                    string key = inputTokens[index];
                    string value = inputTokens[index + 1];
                    int infoValue = key.Length + value.Length;
                    if (!persons.ContainsKey(name))
                    {
                        persons[name] = new Dictionary<string, string>();
                    }
                    if (!personsInfo.ContainsKey(name))
                    {
                        personsInfo[name] = 0;
                    }
                    if (!persons[name].ContainsKey(key))
                    {
                        personsInfo[name] += infoValue;
                        persons[name][key] = string.Empty;
                    }
                    else
                    {
                        int currentInfoValue = persons[name][key].Length;
                        personsInfo[name] -= currentInfoValue;
                        personsInfo[name] += infoValue;

                    }
                    persons[name][key] = value;

                }
            }
            string[] killPerson = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string killName = killPerson[1];
            Console.WriteLine($"Info on {killName}:");
            foreach (KeyValuePair<string, string> item in persons[killName].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
            }
            Console.WriteLine($"Info index: {personsInfo[killName]}");
            if (personsInfo[killName] >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - personsInfo[killName]} more info.");
            }
        }
    }
}
