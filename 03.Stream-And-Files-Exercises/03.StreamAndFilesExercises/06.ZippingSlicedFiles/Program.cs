using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
namespace _06.ZippingSlicedFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int slicePartsCount = int.Parse(Console.ReadLine());
            List<string> parts = Slice(slicePartsCount);
            Assemble(parts);
            Console.WriteLine("Done");
        }

        private static void Assemble(List<string> parts)
        {
            byte[] buffer = new byte[4096];
            using (FileStream streamWriter = new FileStream("assembled.mp4", FileMode.Create))
            {
                for (int curr = 0; curr < parts.Count; curr++)
                {
                    using (FileStream streamReader = new FileStream(parts[curr], FileMode.Open))
                    {
                        using (GZipStream decompressor = new GZipStream(streamReader, CompressionMode.Decompress, false))
                        {
                            int bytes;
                            while ((bytes = decompressor.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                streamWriter.Write(buffer, 0, bytes);
                            }
                        }
                    }
                }
            }
        }

        private static List<string> Slice(int slicePartsCount)
        {
            List<string> parts = new List<string>();
            byte[] buffer = new byte[4096];
            using (FileStream streamReader = new FileStream("sliceMe.mp4", FileMode.Open))
            {
                double sizePerFile = Math.Ceiling((double)streamReader.Length / slicePartsCount);
                for (int curr = 0; curr < slicePartsCount; curr++)
                {
                    string currFileName = $"Part-{curr}.gz";
                    parts.Add(currFileName);
                    using (FileStream streamWriter = new FileStream(currFileName, FileMode.Create))
                    {
                        using (GZipStream compressor = new GZipStream(streamWriter, CompressionMode.Compress, false))
                        {
                            int recordedBytes = 0;
                            while (recordedBytes < sizePerFile)
                            {
                                int bytes = streamReader.Read(buffer, 0, buffer.Length);
                                if (bytes == 0)
                                {
                                    break;
                                }
                                compressor.Write(buffer, 0, bytes);
                                recordedBytes += bytes;
                            }
                        }
                    }
                }
            }
            return parts;
        }
    }
}
