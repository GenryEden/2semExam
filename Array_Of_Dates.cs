using System;
// в модуле с помощью одномерного массива и курсоров реализован однонаправленный список элементов типа Date.
// напишите функцию, которая по индексу элемента удаляет его из списка
namespace Training3
{
    class Program
    {
        public static DateTime freeElement = new DateTime();

        public struct MyList
        {
            public struct DateElement
            {
                public DateTime element;
                public int nextElement;

                public DateElement(DateTime time, int nextElement)
                {
                    this.element = time;
                    this.nextElement = nextElement;
                }
            }

            public DateElement[] array;
            public int firstElement;
            public int firstFreeElement;
        }

        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.array = new MyList.DateElement[4];
            list.array[0] = new MyList.DateElement(DateTime.Now, 1);
            list.array[1] = new MyList.DateElement(DateTime.Now, 2);
            list.array[2] = new MyList.DateElement(DateTime.Now, -1);
            list.array[3] = new MyList.DateElement(freeElement, -1);
            list.firstElement = 0;
            list.firstFreeElement = 3;
            RemoveElement(ref list, 3);
            Console.ReadKey();
        }

        public static void RemoveElement(ref MyList list, int index)
        {
            try
            {
                if (list.firstElement == -1)
                {
                    Console.WriteLine("Список пустой");
                    return;
                } 
                int indexRemove;
                if (index != 0)
                {
                    int previousElement = SearchSimpleIndex(list, index - 1);
                    indexRemove = list.array[previousElement].nextElement;
                    list.array[previousElement].nextElement = list.array[indexRemove].nextElement;
                }
                else
                {
                    indexRemove = list.firstElement;
                    list.firstElement = list.array[indexRemove].nextElement;
                }
                list.array[indexRemove].element = freeElement;
                list.array[indexRemove].nextElement = list.firstFreeElement;
                list.firstFreeElement = indexRemove;
            } 
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Элемента по такому индексу не существует или список не правильно записан");
            }
        }

        private static int SearchSimpleIndex(MyList list, int index)
        {
            int simpleIndex = list.firstElement;
            int currentIndex = 0;
            while (list.array[simpleIndex].nextElement != -1 && currentIndex != index)
            {
                simpleIndex = list.array[simpleIndex].nextElement;
                currentIndex++;
            }

            if (currentIndex == index) return simpleIndex;
            else throw new IndexOutOfRangeException();
        }
    }
}
