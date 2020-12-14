using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClassConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            class1 o = new class1();
            o.display();
            o.display("Shankar");

            Console.WriteLine(o.add(10,20,30,40));
            Console.WriteLine(o.add(10, 20, 30));
            Console.WriteLine(o.add(10, 20));
            Console.WriteLine(o.add(10));
            Console.WriteLine(o.add());
            Console.WriteLine("=================");

            // Named Parameters
            Console.WriteLine(o.add(d:40));
            Console.ReadLine();
        }
    }

    public class class1
    {
        public void display()
        {
            System.Console.WriteLine("Hello World");
        }
        public void display(string s)
        {
            System.Console.WriteLine("Hello " + s);
        }

        public int add(int a = 0, int b = 0, int c = 0, int d)
        {
            return a + b + c + d;
        }
    }
}
