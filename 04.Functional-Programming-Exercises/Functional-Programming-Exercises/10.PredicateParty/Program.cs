using System;
using System.Linq;
using System.Collections.Generic;
namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input;
            while((input = Console.ReadLine()) != "Party!")
            {
                string[] inputTokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = inputTokens[0];
                string type = inputTokens[1];
                string model = inputTokens[2];
                if(command == "Remove")
                {
                    if(type == "StartsWith")
                    {
                        guests = guests.Where(x => !x.StartsWith(model)).ToList();
                    }
                    else if(type == "EndsWith")
                    {
                        guests = guests.Where(x => !x.EndsWith(model)).ToList();
                    }
                    else
                    {
                        int modelLength = int.Parse(model);
                        guests = guests.Where(x => x.Length != modelLength).ToList();
                    }
                }
                else
                {
                    if (type == "StartsWith")
                    {
                        for (int index = 0; index < guests.Count; index++)
                        {
                            if (guests[index].StartsWith(model))
                            {
                                guests.Insert(++index, guests[index - 1]);
                            }
                        }
                    }
                    else if (type == "EndsWith")
                    {
                        for (int index = 0; index < guests.Count; index++)
                        {
                            if (guests[index].EndsWith(model))
                            {
                                guests.Insert(++index, guests[index - 1]);
                            }
                        }
                    }
                    else
                    {
                        int modelLength = int.Parse(model);
                        for (int index = 0; index < guests.Count; index++)
                        {
                            if(guests[index].Length == modelLength)
                            {
                                guests.Insert(++index, guests[index - 1]);
                            }
                        }
                    }
                }
            }
            if(guests.Count > 0)
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }
    }
}
