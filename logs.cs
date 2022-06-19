// в текстовом файле содержится лог ошибок от различных датчиков.
// записи сделаны в следующем формате
// функция получает имя файла и возвращает упорядоченный по алфавиту список датчиков, в которых были обнаружены ошибки

namespace logs
{
    internal class Program
    {
        public struct sensor
        {
            public string name;
            public List<int> errors;

        }
        static void Main(string[] args)
        {
            string nameOfFile = "log.txt";
            List<sensor> ans = getListOfSensors(nameOfFile);
            Console.WriteLine();
        }

        public static List<sensor> getListOfSensors(String nameOfFile)
        {
            List<sensor> ans = new List<sensor>();
            StreamReader sr = new StreamReader(nameOfFile);

            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                String[] splitted = line.Split(":,".ToCharArray());
                String name = splitted[0];
                List<int> errors = new List<int>();
                for (int i = 1; i < splitted.Length; i++)
                {
                    errors.Add(int.Parse(splitted[i]));
                }

                if (errors.Count == 0) continue;

                int position = binarySearch(ans, name);

                if (ans.Count > position && ans[position].name == name)
                {
                    ans[position].errors.AddRange(errors);
                } else
                {
                    ans.Insert(position,
                        new sensor()
                        {
                            name = name,
                            errors = errors
                        }
                    );
                }

                
                
            }
            sr.Close();
            return ans;
        }

        static int binarySearch(List<sensor> ans, String name)
        {
            int left = 0;
            int right = ans.Count;
            
            while (left < right - 1)
            {
                int mid = (left + right) / 2;
                String current = ans[mid].name;
                int compared = current.CompareTo(name);

                if (compared == 0)
                {
                    return mid;
                } else if (compared < 0)
                {
                    left = mid;
                } else
                {
                    right = mid;
                }

            }
            return right;
        } 
    }
}