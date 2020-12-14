using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethodAndLambda
{
    class Program
    {
        static void Main1(string[] args)
        {
            // Action => it ias use to call the void methods which does not have return type,
            // and its is call by using delegate method i.e.(Action)

            Action o = Display;
            o();

            Action<string> o2 = Display;
            o2("Shankar");

            Action<string, int> o3 = Display;
            o3("Shankar",104);

            Console.ReadLine();
        }

        static void Main2()
        {
            // use to cALL methods with return type

            Func<int, int, int> o1 = Add;
            Console.WriteLine(o1(100, 200));

            Func<string, short, int> o2 = DoSomething;
            Console.WriteLine(o2("Shankar",4));

            Func<int, bool> o3 = IsEven;
            Console.WriteLine(o3(11));

            Predicate<int> o4 = IsEven;
            Console.WriteLine(o4(12));

            Console.ReadLine();
        }


        static void Main3()
        {
           /*
            int i = 10;
            Action o = delegate { Console.WriteLine("AnonymousMethod Called"); };
            o();
            

            Action o1 = delegate()
            {
                 Console.WriteLine("Display");
                 ++i;
            };
            o1();
            Console.WriteLine(i);
           */

            Func<int,int,int> o = delegate(int a,int b)
            {
                return a + b;
            };
            Console.WriteLine(o(10, 20));

            Func<int, bool> o1 = delegate (int a)
             {
                 return a % 2 == 0;
             };
            Console.WriteLine(o1(10));
            Console.WriteLine(o1(5));

            Console.ReadLine();
        }
        static bool IsEven(int a)
        {
            return a % 2 == 0;
        }
        static int Add(int a, int b)
        {
            return a + b;

        }
        static int DoSomething(string a, short b)
        {
            return 1;

        }
        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display " + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display " + s + i);
        }
    }
}

namespace Lambdas
{
    class Program
    {
        static void Main()
        {
            //x is the parameter of the func
            //=> is the lambda operator
            //x *2 is the return value
            // Func<int, int> o = (x) => x * 2;
            Func<int, int> o = x => x * 2;
            //Func<int, int> o2 = delegate(int a)
            //{
            //    return a * 2;
            //};
            Console.WriteLine(o(10));
            Func<int, int, int> o2 = (a, b) => a + b;
            Console.WriteLine(o2(10, 20));

            Func<int, int, int, int> o3 = (a, b, c) =>
            {
                //multiple lines of code
                return a + b + c;
            };

            Console.ReadLine();

        }
       
    }
}
