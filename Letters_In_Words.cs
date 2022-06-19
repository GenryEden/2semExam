using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два слова");
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();
            Console.WriteLine(DifferentLetters(word1, word2));
            Console.ReadKey();
        }
        static string DifferentLetters(string word1, string word2)
        {
            word1 = new string(word1.Distinct().ToArray());
            word2 = new string(word2.Distinct().ToArray());
            string answer = word1 + word2;
            foreach (char letter in word1)
            {
                if(word2.Contains(letter))
                {
                    answer = answer.Remove(answer.IndexOf(letter), 1);
                    answer = answer.Remove(answer.IndexOf(letter), 1);
                }
            }
            return (answer);
        }
    }
}
