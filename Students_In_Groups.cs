using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eks
{
    class Program
    {
        public static Dictionary<string, List<string>> FIOgroups = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            string[] students = { "Пирожков Артур Иванович", "Проигожин Алексей Игоревич", "Путин Антон Иванович", "Полуэктов Александр Алексеевич", "Плинтусов Андрей Андреевич" };
            FIOgrouping(students);
            foreach (KeyValuePair<string, List<string>> Group in FIOgroups)
            {
                foreach (string person in Group.Value)
                {
                    Console.WriteLine(Group.Key + " - " + person);
                }
            }
            Console.ReadKey();
        }

        private static void FIOgrouping(string[] students)
        {
            string fio = "";
            foreach (string student in students)
            {
                string[] words = student.Split(' ');
                fio = (words[0].Substring(0, 1) + words[1].Substring(0, 1) + words[2].Substring(0, 1));
                if (FIOgroups.ContainsKey(fio))
                {
                    FIOgroups[fio].Add(student);
                }
                else
                {
                    FIOgroups.Add(fio, new List<string>());
                    FIOgroups[fio].Add(student);
                }
            }
        }
    }
}
