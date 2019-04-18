using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = "../../../Streams-Resources/";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Dictionary<string, Dictionary<string, long>> files = new Dictionary<string, Dictionary<string, long>>();
            string[] dirFiles = Directory.GetFiles(dirPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in dirFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                string ex = fileInfo.Extension;
                string name = fileInfo.Name;
                long length = fileInfo.Length;
                if (!files.ContainsKey(ex))
                    files[ex] = new Dictionary<string, long>();
                if (!files[ex].ContainsKey(name))
                    files[ex][name] = length;
            }
            using(StreamWriter streamWriter = new StreamWriter($"{desktopPath}/report.txt"))
            {
                foreach (KeyValuePair<string, Dictionary<string, long>> file in files
                    .OrderByDescending(c => c.Value.Count)
                    .ThenBy(n => n.Key))
                {
                    streamWriter.WriteLine(file.Key);
                    foreach (KeyValuePair<string, long> item in file.Value
                        .OrderByDescending(s => s.Value))
                    {
                        streamWriter.WriteLine($"--{item.Key} - {(double)item.Value / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
