using System;
using System.Collections.Generic;
// Подпрограмме подается информация о студентах в разных группах в виде списка, элементы которого являются стеками объектов типа Stack<SStudent>
// SStudent - структура, которая описывает студента с помощью двух полей - ФИО и рост
// Все элементы в каждом стеке находятся по взорастанию значения роста, т.е. на вершине каждого стека человек с максимальным ростом
// Необходимо, чтобы подпрограмма формировала новый стек из всех студентов всех групп, которые должны быть упорядочены по убыванию роста
namespace student
{
    class Program
    {
        public struct SStudent
        {
           public string fio;
           public double height;
        }
        static void Main(string[] args)
        {
            List < Stack < SStudent >> groups = new List<Stack<SStudent>>();
            Stack<SStudent> result = Spisok(groups);
        }

        private static Stack<SStudent> Spisok(List<Stack<SStudent>> groups)
        {
            Stack<SStudent> result = new Stack<SStudent>();

            int temp = 0;
            double maxOFmax = groups[0].Peek().height;
            while (groups.Count!=0)
                { 
                for (int i = 1; i < groups.Count; i++)
                {
                    double maxTemp = groups[i].Peek().height;
                    if (maxOFmax < maxTemp)
                    {
                        maxOFmax = maxTemp;
                        temp = i;
                    }

                }
                try
                {
                    result.Push(groups[temp].Pop());
                }
                catch
                {
                    groups.RemoveAt(temp);
                }
            }
            return result;
        }

 
    }
}