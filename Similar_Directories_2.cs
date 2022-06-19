using System;
using System.Collections.Generic;
using System.IO;

namespace Training1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dirsNames = Console.ReadLine().Split();
            Console.WriteLine(IsEqual(dirsNames[0], dirsNames[1]));
            Console.ReadKey();
        }

        public static bool IsEqual(string Dir1, string Dir2)
        {
            List<string> filesNamesDir1 = new List<string>();
            List<string> filesNamesDir2 = new List<string>();

            GetFullFilesNames(Dir1, ref filesNamesDir1);
            GetFullFilesNames(Dir2, ref filesNamesDir2);

            foreach (string file in filesNamesDir1)
            {
                if (!filesNamesDir2.Contains(file)) return false;
            }

            return filesNamesDir1.Count == filesNamesDir2.Count;
        }

        private static void GetFullFilesNames(string path, ref List<string> filesNames)
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    filesNames.Add(Path.GetFileName(file));
                }

                foreach (string dir in Directory.EnumerateDirectories(path))
                {
                    GetFullFilesNames(dir, ref filesNames);
                }

            } catch (Exception) { }
        }
    }
}
