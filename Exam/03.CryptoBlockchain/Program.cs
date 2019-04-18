namespace _03.CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"\[[^0-9]*(?<number>[0-9]+)[^0-9]*\]|\{[^0-9]*(?<number>[0-9]+)[^0-9]*\}";
            Regex regex = new Regex(pattern);
            int numberOfLines = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();
            for (int line = 0; line < numberOfLines; line++)
            {
                builder.Append(Console.ReadLine());
            }
            string theLine = builder.ToString();
            List<char> chars = new List<char>();
            MatchCollection matches = regex.Matches(theLine);
            foreach (Match match in matches)
            {
                int matchLength = match.Length;
                string theNumber = match.Groups["number"].ToString();
                if (theNumber.Length % 3 == 0)
                {

                    for (int index = 0; index < theNumber.Length; index += 3)
                    {
                        string character = string.Empty;
                        character += theNumber[index];
                        character += theNumber[index + 1];
                        character += theNumber[index + 2];
                        int t = int.Parse(character);

                        //Console.WriteLine(t - matchLength);
                        chars.Add((char)(t - matchLength));

                    }
                }
            }
            Console.WriteLine(string.Join("", chars));
        }
    }
}
