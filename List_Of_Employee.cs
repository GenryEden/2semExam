using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// напишите функцию, которая получает на вход список списков (тип List), которые состоят из строк
// внутренние списки содержат строки - фамилии сотрудников различных подразделений, упорядоченные (фамилии) по алфавиту
// главный список содержит ссылки на внутренние списки - подразделения
// функция должна осуществлять поиск сотрудника по фамилии и возвращать номер подразделения

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> people = new List<List<string>>(4);
            people.Add(new List<string>());
            people.Add(new List<string>());
            people.Add(new List<string>());
            people.Add(new List<string>());
            people[0].Add("Комарова");
            people[0].Add("Комарова");
            people[0].Add("Щукин");
            people[1].Add("Комарова");
            people[1].Add("Щукин");
            people[2].Add("Комарова");
            people[3].Add("Комарова");
            people[3].Add("Комарова");
            people[3].Add("Комарова");
            people[3].Add("Щукин");
            List<int> result = SearchTogoSamogo(people, "Щукин");
            foreach (int group in result)
            {
                Console.WriteLine(group);
            }
            Console.ReadKey();
        }
        static List<int> SearchTogoSamogo(List<List<string>> vsePeople, string totSamiy)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < vsePeople.Count(); i++)
            {
                if (BinarySearch(vsePeople[i], totSamiy)) 
                {
                    result.Add(i);
                }
            }
            return result;
        }
        static bool BinarySearch(List<string> group,  string totSamiy)
        {
            int left = 0;
            int right = group.Count() - 1;
            int mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (group[mid].Equals(totSamiy))
                {
                    return true;
                }
                if (String.Compare(group[mid],totSamiy) < 0)
                {
                    left = mid + 1;
                } else
                {
                    right = mid - 1; 
                }
            }
            return false;
        }
    }
}
