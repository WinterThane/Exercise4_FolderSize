using System;
using System.IO;
using System.Linq;

namespace Exercise4_FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(@"C:\Tutorials");
            long directorySize = DirectorySize(dirInfo, true);

            Console.WriteLine("Directory size in B:  {0:N0} Bytes", directorySize);
            Console.WriteLine("Directory size in KB: {0:N2} KB", ((double)directorySize) / 1024);
            Console.WriteLine("Directory size in MB: {0:N2} MB", ((double)directorySize) / (1024 * 1024));
            Console.ReadLine();
        }

        private static long DirectorySize(DirectoryInfo dirInfo, bool includeSubDir)
        {
            long size = dirInfo.EnumerateFiles().Sum(file => file.Length);

            if(includeSubDir)
            {
                size += dirInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
            }

            return size;
        }
    }
}
