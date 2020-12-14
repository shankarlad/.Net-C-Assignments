using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no. of batches : ");
            int batches = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[batches][];

            Console.WriteLine("no of batches: " + arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter no of students of batch {0} ", i+1);
                int sizeStd = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("size of std: " + sizeStd);
                int[] marks = new int[sizeStd];

                Console.WriteLine("Enter marks of students of batch {0} ", i+1);
                for (int j = 0; j < sizeStd; j++)
                {
                    marks[j] = Convert.ToInt32(Console.ReadLine());
                }
                arr[i] = marks;

            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine(arr[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
