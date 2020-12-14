using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunctions
{
    class Program
    {

        static void Main()
        {
            Employee e = new Employee();

            // Simple Interset
            Func<decimal, decimal, decimal, decimal> f1 = (p, n, r) => p * n * r / 100;
            Console.WriteLine("Simple Interest : " + f1(50000,10,5));

            Console.WriteLine();

            // Is Greater
            Func<int, int, bool> f2 = (x, y) => (x > y);
            Console.WriteLine("x is Greater than y : " + f2(100,200));

            Func<int, int, bool> f3 = (x, y) => (x > y);
            Console.WriteLine("x is Greater than y : " + f3(300, 200));

            Console.WriteLine();

            // Employee Get Basic
            Func<Employee, decimal> f4 = (emp) => emp.Basic;
            Console.WriteLine("Employee Basic : " + f4(e));

            Console.WriteLine();

            // Is Even
            Predicate<int> f5 = x => x % 2 == 0;
            Console.WriteLine("x is even : " + f5(26));

            Console.WriteLine();
            // is Greater than 10000
            Predicate<Employee> f6 = emp => emp.Basic > 10000;
            Console.WriteLine("Employee salary is greater than 10000 : " + f6(e));

            Console.ReadLine();
        }

       
    }

    class Employee
    {
        private decimal basic = 55000;

        public decimal Basic
        {
            set
            {
                basic = value;
            }
            get
            {
                return basic;
            }
        }

      
    }
}
    

