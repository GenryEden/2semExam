using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// напишите объявление структуры, которая бы описывала прямоугольник на плоскости (стороны параллельны осям).
// напишите функцию, которая получает одномерный массив прямоугольников и возвращает количество охватывающих прямоугольников для определенной точки на плоскости
namespace BiggerNumber
{
    class Program
    {
        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public struct Polygon
        {
            public Point PointA;
            public Point PointB;

            public Polygon(Point pointa, Point pointb)
            {
                PointA = pointa;
                PointB = pointb;
            }
        }

        static void Main(string[] args)
        {
            var rects = new List<Polygon>();
            rects.Add
            (
                new Polygon
                (
                        new Point(0, 0),
                        new Point(5, 5)
               )
            );
            rects.Add
            (
                new Polygon
                (
                        new Point(0, 0),
                        new Point(4, 4)
               )
            );
            rects.Add
            (
                new Polygon
                (
                        new Point(0, 0),
                        new Point(3, 3)
               )
            );
            rects.Add
            (
                new Polygon
                (
                        new Point(6, 0),
                        new Point(12, 6)
               )
            );

            var depth = DepthOfNestedRectangle(rects);
            Console.WriteLine($"Max Depth: {depth}");

            Console.ReadLine();
        }

        public static int DepthOfNestedRectangle(List<Polygon> rects)
        {
            var maxdepth = -1;

            for (int i = 0; i < rects.Count; i++)
            {
                var freerects = rects;
                var current = rects[i];
                var depth = 1;

                int inx;
                while ((inx = freerects.FindIndex(c => IsNested(current, c))) != -1)
                {
                    freerects.RemoveAt(inx);
                    depth++;
                }

                maxdepth = (maxdepth < depth) ? depth : maxdepth;
            }

            return maxdepth;
        }

        public static bool IsNested(Polygon main, Polygon sub)
        {
            return (sub.PointA.X <= main.PointA.X && main.PointB.X <= sub.PointB.X && sub.PointA.Y <= main.PointA.Y && main.PointB.Y <= sub.PointB.Y ? true : false);
        }
    }
}