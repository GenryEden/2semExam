using System;
using System.Collections.Generic;
// подпрограмма получает на вход ступенчатый массив. Необходимо, чтобы она возвращала измененный ступенчатый массив,
// в котором вложенные массивы упорядочены по их длине 
namespace ConsoleApp1
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            int[][] arr = new int[7][];
            arr[0] = new int[6];
            arr[1] = new int[3];
            arr[2] = new int[5];
            arr[3] = new int[8];
            arr[4] = new int[3];
            arr[5] = new int[2];
            arr[6] = new int[4];
            Sort(arr);
            foreach(int[] a in arr)                                                                                                П
            {
                Console.WriteLine(a.Length);
            }
            Console.ReadKey();
        }

        private static int[][] Sort(int[][] arr)
        {
            int j;
            for(int i=1; i<arr.GetLength(0); i++)
            {
                j = i;
                while (j > 0 && arr[j].Length < arr[j - 1].Length)
                {
                    Swap(ref arr[j], ref arr[j - 1]);
                    j--;
                }
            }
            return arr;
        }

        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
