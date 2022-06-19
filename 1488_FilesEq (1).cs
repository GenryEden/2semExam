using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BiggerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var path1 = @"C:\Users\Семён\Desktop\Студент\Лабы";
            var path2 = @"C:\Users\Семён\Desktop\Лабы";

            var res = DirectoryEquals(path1, path2);
            Console.WriteLine(res);

            Console.ReadLine();
        }

        class Pair
        {
            //Колво файла в первой папке
            public int ACount { get; set; }
            //Колво файла во второй
            public int BCount { get; set; }
        }

        static bool DirectoryEquals(string path1, string path2)
        {
            var answer = true;

            //Файл - его колво в первой и второй папке
            var fileslib = new Dictionary<string, Pair>();

            //База файлов первой папки
            FillLib(path1, fileslib);

            Foo(path2);
            void Foo(string path)
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    //Для короткого выхода из Foo
                    if (!answer)
                    {
                        return;
                    }

                    var filename = Path.GetFileName(file);

                    //Если файл из второй папки есть в первой увеличиваем его колво 
                    if (fileslib.ContainsKey(filename))
                    {
                        fileslib[filename].BCount++;
                    }
                    else //Если файла нет папки не иквалс
                    {
                        answer = false;
                        return;
                    }
                }

                foreach (var dir in Directory.GetDirectories(path))
                {
                    Foo(dir);
                }
            }

            //Смотрим колво каждого файла - на  случай когда все файлы совпали а колво нет
            foreach (var pair in fileslib.Values)
            {
                if (pair.ACount != pair.BCount)
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }

        static void FillLib(string path, Dictionary<string, Pair> fileslib)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                var filename = Path.GetFileName(file);

                if (fileslib.ContainsKey(filename))
                {
                    fileslib[filename].ACount++;
                }
                else
                {
                    fileslib.Add(filename, new Pair() { ACount = 1, BCount = 0 }); ;
                }
            }

            foreach (var dir in Directory.GetDirectories(path))
            {
                FillLib(dir, fileslib);
            }
        }
    }
}