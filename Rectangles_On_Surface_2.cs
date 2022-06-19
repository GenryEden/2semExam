using System;
// напишите объявление структуры, которая бы описывала прямоугольник на плоскости (стороны параллельны осям).
// напишите функцию, которая получает одномерный массив прямоугольников и возвращает количество охватывающих прямоугольников для определенной точки на плоскости

namespace ConsoleApp45
{
    class Program
    {
        public struct Rectangle
        {
            public double xUpLeft;
            public double yUpLeft;
            public double xDownRight;
            public double yDownRight;
            public Rectangle(double newxUpLeft, double newyUpLeft, double newxDownRight, double newyDownRight)
            {
                xUpLeft = newxUpLeft;
                yUpLeft = newyUpLeft;
                xDownRight = newxDownRight;
                yDownRight = newyDownRight;
            }
        }
        static void Main(string[] args)
        {
            Rectangle[] rectangles = new Rectangle[4];
            rectangles[0] = new Rectangle(10, 10, 12, 5);
            rectangles[1] = new Rectangle(-2, 4, 8, 2);
            rectangles[2] = new Rectangle(6, 4, 11, 1);
            Console.WriteLine("Количество пересечений: " + Search(rectangles));
        }
        public static void GetRec(Rectangle[] rectangles, Rectangle recResult, Rectangle recNew, int result, ref int max, int c)
        {
            if (!(recResult.yDownRight > recNew.yUpLeft || recResult.yUpLeft < recNew.yDownRight || recResult.xUpLeft > recNew.xDownRight || recResult.xDownRight < recNew.xUpLeft))
            {
                recResult.xUpLeft = Math.Max(recResult.xUpLeft, recNew.xUpLeft);
                recResult.yUpLeft = Math.Min(recResult.yUpLeft, recNew.yUpLeft);
                recResult.xDownRight = Math.Min(recResult.xDownRight, recNew.xDownRight);
                recResult.yDownRight = Math.Max(recResult.yDownRight, recNew.yDownRight);
                result++;
                c++;
                for (int k = c; k < rectangles.Length; k++)
                {
                    GetRec(rectangles, recResult, rectangles[k], result, ref max, k);
                }
                if ((c == rectangles.Length) && (result > max)) max = result;
            }
            else
            {
                if (result > max) max = result;
            }
        }
        public static int Search(Rectangle[] rectangles)
        {
            int max = 0;
            for (int j = 0; j < rectangles.Length; j++)
            {
                for (int i = j + 1; i < rectangles.Length; i++)
                {
                    GetRec(rectangles, rectangles[j], rectangles[i], 1, ref max, i);
                }
            }
            return max;
        }
    }
}
