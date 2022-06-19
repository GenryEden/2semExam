using System;
// в модуле с помощью одномерного массива и курсоров реализован однонаправленный список элементов типа Date.
// напишите функцию, которая по индексу элемента удаляет его из списка
namespace listRemove
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

            public void removeElement(int index)
            {
                int nowElement = firstElement;
                int nowIndex = 0;
                if (index == 0)
                {
                    firstElement = array[firstElement].nextElement;
                    array[0].nextElement = firstFreeElement;
                    firstFreeElement = 0;
                    return;
                }
                int prevElement = 0;
                while (index != nowIndex)
                {
                    prevElement = nowElement;
                    nowElement = array[nowElement].nextElement;
                    nowIndex += 1;
                }

                array[prevElement].nextElement = array[nowElement].nextElement;

                array[nowElement].nextElement = firstFreeElement;
                firstFreeElement = nowElement;

            }
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
            list.removeElement(2);
            Console.ReadKey();
        }

    }
}