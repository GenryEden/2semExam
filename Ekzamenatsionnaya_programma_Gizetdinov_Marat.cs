using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamQuest
{
    public struct Rectangle
    {
        //Скрытые переменные
        private double[] upperRight, bottomLeft;
        //Конструктор структуры
        public Rectangle(double xUR, double yUR, double xBL, double yBL)
        {
            upperRight = new double[2] { xUR, yUR };
            bottomLeft = new double[2] { xBL, yBL };
        }
        //Методы для вывода значений
        public double GetxUR()
        {
            return upperRight[0];
        }
        public double GetyUR()
        {
            return upperRight[1];
        }
        public double GetxBL()
        {
            return bottomLeft[0];
        }
        public double GetyBL()
        {
            return bottomLeft[1];
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle firtsRect = new Rectangle(4, 4, 2, 2);
            Rectangle secondRect = new Rectangle(3, 3, -1, -1);
            Rectangle thirdRect = new Rectangle(3,5,0,2);
            Rectangle[] testArrOfRects = new Rectangle[3] { firtsRect, secondRect, thirdRect };
            Console.WriteLine(SpanningRectangles(testArrOfRects));
            Console.ReadKey();
        }
        static int SpanningRectangles(Rectangle[] arrOfRectangles)
        {
            int amount = 0;
            Dictionary<int, int> copyOfInputArr = new Dictionary<int, int>();
            for (int i = 0; i < arrOfRectangles.Length; i++)
            {
                copyOfInputArr.Add(i, 1);
            }
            for (int i = 0; i < arrOfRectangles.Length-1; i++)
            {
                //Если есть пересечение
                if (arrOfRectangles[i].GetxBL() <= arrOfRectangles[i + 1].GetxUR() && arrOfRectangles[i].GetyBL() <= arrOfRectangles[i + 1].GetyUR())
                {
                    Rectangle newRect = new Rectangle(arrOfRectangles[i + 1].GetxUR(), arrOfRectangles[i + 1].GetyUR(), arrOfRectangles[i].GetxBL(), arrOfRectangles[i].GetyBL());
                    arrOfRectangles[i + 1] = newRect;
                    copyOfInputArr[i + 1]++;
                }
                //Пересечение другого рода
                else if (arrOfRectangles[i].GetxBL() <= arrOfRectangles[i + 1].GetxUR()&& arrOfRectangles[i].GetyBL() <= arrOfRectangles[i + 1].GetyUR())
                {
                    Rectangle newRect = new Rectangle(arrOfRectangles[i+1].GetxUR(), arrOfRectangles[i].GetyUR(), arrOfRectangles[i].GetxBL(), arrOfRectangles[i+1].GetyBL());
                    arrOfRectangles[i + 1] = newRect;
                    copyOfInputArr[i + 1]++;
                }
            }
            foreach (KeyValuePair<int,int> pair in copyOfInputArr)
            {
                if (pair.Value > amount) amount = pair.Value;
            }
            return amount;
        }
    }
}
