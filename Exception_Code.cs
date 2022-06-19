using System;
using System.Collections.Generic;
using System.IO;

// в текстовом файле содержится лог ошибок от различных датчиков.
// записи сделаны в следующем формате
// функция получает имя файла и возвращает упорядоченный по алфавиту список датчиков, в которых были обнаружены ошибки

namespace Zapupa
{

    class Program
    {
        public static void Main()
        {
            string adress = @"C:\Users\Admin\Desktop\jij.txt";
            List<string> spisop = new List<string>();
            spisop = ShchhukaMraz(adress);
            foreach (string str in spisop)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();

        }

        public static List<string> ShchhukaMraz(string fileName)
        {
            List<string> finalList = new List<string>();
            string line;

            if (File.Exists(fileName))
            {
                string subStr;
                StreamReader sr = new StreamReader(fileName);
                while ((line = sr.ReadLine()) != null)
                {
                    subStr = line.Substring(0, line.IndexOf(':'));
                    finalList.Add(subStr);
                }
                Sorting(finalList);
                //finalList.Sort();
                return finalList;
            }

            return null;
        }

        public static void Sorting(List<string> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                string cur = list[i];
                int j = i;
                while (j > 0 && String.Compare(cur, list[j - 1]) < 1)
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = cur;
            }
        }
    }
}