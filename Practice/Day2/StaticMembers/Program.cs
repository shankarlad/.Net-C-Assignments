using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
  
           Class1 o1 = new Class1();
            //Class1 o2 = new Class1();
            o1.i = 100;
           // o2.i = 200;
            o1.Display();






            Class1.s_i = 1234;
            Console.WriteLine(Class1.s_i);

            Class1.s_P1 = 10;
            Console.WriteLine(Class1.s_P1);

             Class1.s_Display();

            Console.ReadLine();
        }
    }

    public class Class1
    {

        //static constructor? -> initialise static members
        //called when the class is loaded into memory(either 1st object created or a static member accessed
        //implicitly called(implicitly private)
        //cannot have parameters
        //cant be overloaded

        static Class1()
        {
            Console.WriteLine("static cons");
            s_P1 = 10;
            s_i = 20;
        }

        public int i;
       
        public static int s_i;   //static variable - single copy for the class

        public void Display()
        {
            Console.WriteLine("disp");
            Console.WriteLine(i);
            Console.WriteLine(s_i);
        }
        //static method  - can be accessed directly with classname.methodname, without creating an object   
        public static void s_Display()
        {
            Console.WriteLine("static disp");
        //    Console.WriteLine(i); 
            Console.WriteLine(s_i);
        }


        // property
        private int p1;
        public int P1
        {
            set
            {
                if (value < 100)
                    p1 = value;
                else
                    Console.WriteLine("invalid P1");
            }
            get
            {
                return p1;
            }
        }

        //static property -single copy with validations
        private static int s_p1;
        public static int s_P1
        {
            set
            {
                if (value < 100)
                    s_p1 = value;
                else
                    Console.WriteLine("invalid P1");
            }
            get
            {
                return s_p1;
            }
        }
    }

    public static class s_Class1
    {
        //can only have static members
        //cannot be instantiated
        //cannot be used as a base class
    }
}
