using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// напишите функцию, которая получает на вход два слова. Необходимо, чтобы подпрограммая возвращала только те буквы слов, которые встречаются в одном слове, но не в обоих
namespace BiggerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "процессор";
            var str2 = "информация";

            var res = UnrepeatLetters(str1, str2);
            foreach(var c in res)
            {
                Console.Write(c + " ");
            }

            Console.ReadLine();
        }

        static List<char> UnrepeatLetters(string str1, string str2)
        {
            var letters = new List<char>();

            var inx1 = 0;
            var inx2 = 0;
            while (inx1 < str1.Length || inx2 < str2.Length)
            {
                if(inx1 < str1.Length && !str2.Contains(str1[inx1++]))
                {
                    letters.Add(str1[inx1 - 1]);
                }
                if(inx2 < str2.Length && !str1.Contains(str2[inx2++]))
                {
                    letters.Add(str2[inx2 - 1]);
                }
            }

            //Удалить повторяющиеся символы 
            letters = letters.Distinct().ToList();
            return letters;
        }
    }
}