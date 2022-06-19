using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// в текстовом файле содержится лог ошибок от различных датчиков.
// записи сделаны в следующем формате
// функция получает имя файла и возвращает упорядоченный по алфавиту список датчиков, в которых были обнаружены ошибки
namespace BiggerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Семён\Desktop\LOG.txt";
            var result = GetLogs(path);

            foreach(var c in result)
            {
                Console.WriteLine($"Id: {c.Id, -5}; Code: {c.Code, -20}; Correct log: {c.Correct}");
            }

            Console.ReadLine();
        }

        class Log
        {
            public string Id;
            public string Code;
            public bool Correct;

            public Log(string id, string code, bool correct)
            {
                Id = id;
                Code = code;
                Correct = correct;
            }
        }

        static List<Log> GetLogs(string path)
        {
            var logs = new List<Log>();

            using(var reader = new StreamReader(path))
            {
                var log = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                for(int i = 0; i < log.Length; i++)
                {
                    //Вырезать айди
                    var id = log[i].Substring(0, log[i].IndexOf(':'));
                    //Вырезать коды ошибок
                    var code = log[i].Substring(log[i].IndexOf(':') + 1, log[i].Length - log[i].IndexOf(':') - 1);
                    //Проверить является ли лог корректным
                    var correct = id.All(c => c >= 'А' && c <= 'я') && code.All(c => char.IsDigit(c) || c == ',' || c == ' ');

                    //Создать лог и записать
                    logs.Add(new Log(id, code, correct));
                }
            }

            //Сортировка по алфавиту относительно id
            logs = logs.OrderBy(c => c.Id).ToList();
            return logs;
        }
    }
}