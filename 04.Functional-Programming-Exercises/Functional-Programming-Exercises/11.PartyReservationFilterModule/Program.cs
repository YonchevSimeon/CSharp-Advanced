using System;
using System.Linq;
using System.Collections.Generic;
namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            HashSet<string> filters = GetFilters();
            List<string> filteredGuests = GetFilteredGuests(guests, filters);
            Console.WriteLine(string.Join(" ", filteredGuests));
        }

        private static List<string> GetFilteredGuests(List<string> guests, HashSet<string> filters)
        {
            List<string> filteredGuests = new List<string>();
            foreach (string guest in guests)
            {
                bool isGoodEnoughForTheParty = true;
                foreach (string filter in filters)
                {
                    string[] filterTokens = filter.Split(';');
                    string type = filterTokens[0];
                    string model = filterTokens[1];
                    switch (type)
                    {
                        case "Starts with":
                            if (guest.StartsWith(model))
                                isGoodEnoughForTheParty = false;
                            break;
                        case "Ends with":
                            if (guest.EndsWith(model))
                                isGoodEnoughForTheParty = false;
                            break;
                        case "Length":
                            if (guest.Length == int.Parse(model))
                                isGoodEnoughForTheParty = false;
                            break;
                        case "Contains":
                            if (guest.Contains(model))
                                isGoodEnoughForTheParty = false;
                            break;
                        default: break;
                    }
                    if(isGoodEnoughForTheParty == false)
                    {
                        break;
                    }
                }
                if (isGoodEnoughForTheParty)
                    filteredGuests.Add(guest);
            }
            return filteredGuests;
        }

        private static HashSet<string> GetFilters()
        {
            HashSet<string> filters = new HashSet<string>();
            string input;
            while((input = Console.ReadLine()) != "Print")
            {
                string[] inputTokens = input
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputTokens[0];
                string type = inputTokens[1];
                string model = inputTokens[2];
                if(command == "Add filter")
                {
                    filters.Add(type + ";" + model);
                }
                else
                {
                    filters.Remove(type + ";" + model);
                }
            }
            return filters;
        }
    }
}
