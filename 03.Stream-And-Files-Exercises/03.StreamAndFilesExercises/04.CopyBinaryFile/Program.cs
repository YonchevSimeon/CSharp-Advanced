using System;
using System.IO;
namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("copyMe.png", FileMode.Open))
            {
                using(FileStream streamWriter = new FileStream("copyMe1.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int bytes;
                    while ((bytes = streamReader.Read(buffer, 0 , buffer.Length)) != 0)
                    {
                        streamWriter.Write(buffer, 0, bytes);
                    }
                }
            }
        }
    }
}
