// Функция получает на вход два списка (тип List). Один список содержит информационные элементы - это числа типа Integer.
// Второй список содержит информацию об операциях, которые были выполнены с элементами первого списка. 
// Возможные операции: удаление элемента, добавление элемента в определенную позицию, изменение значения элемента.
// необходимо, чтобы ваша функция вернула список в исходное состояние, отменив выполненные с ним действия
namespace reverseGroundMeat
{
    internal class Program
    {
        public enum OperationsName {
            Delete,
            Add,
            Replace
        }

        public struct Operation
        {
            public OperationsName name;
            public int whichElement;
            public int placeOfElement;
            public int toWhichElement;
        }
        static void Main(string[] args)
        {
            List<int> toReverse = new List<int>() { 1, 3, 2, 6, 5 };
            List<Operation> operations = new List<Operation>() {
                new Operation {
                    name=OperationsName.Delete,
                    placeOfElement=2,
                    whichElement=3
                },
                new Operation
                {
                    name=OperationsName.Replace,
                    placeOfElement=2,
                    whichElement=4,
                    toWhichElement=6
                },
                new Operation {
                    name =OperationsName.Add,
                    whichElement=3,
                    placeOfElement=1
                }
            };

            List<int> reversed = reverse(toReverse, operations);

            foreach (int elt in reversed)
            {
                Console.Write($"{elt} ");
            }
            Console.WriteLine();
        }

        static public List<int> reverse(List<int> toReverse, List<Operation> operations)
        {
            List<int> ans = new List<int>(toReverse);
            for (int i = operations.Count-1; i >= 0; i--)
            {
                if (operations[i].name == OperationsName.Delete)
                {
                    ans.Insert(operations[i].placeOfElement, operations[i].whichElement);
                }

                if (operations[i].name == OperationsName.Replace)
                {
                    ans[operations[i].placeOfElement] = operations[i].whichElement;
                }

                if (operations[i].name == OperationsName.Add)
                {
                    ans.RemoveAt(operations[i].placeOfElement);
                }
            }

            return ans;
        }
    }
}