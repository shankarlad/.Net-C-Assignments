using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    class Program
    {
        static void Main1(string[] args)
        {
            class1 o = new class1();    // creating object of class1

            //// 1 Without using setter getter
            //o.i = 100;  // Assigning value to the public member of class1
            //Console.WriteLine(o.i); // printing the value



            //// 2 Using setter getter
            //o.SetI(100);
            //Console.WriteLine(o.GetI());
            //o.SetI(50);
            //Console.WriteLine(o.GetI());


            //// 3 Properties and Validation in .net
            //o.P1 = 111;
            //Console.WriteLine(o.P1);
            //o.P1 = 50;
            //Console.WriteLine(o.P1);


            //// 4 String properties
            //o.S1 = "Shankar";
            //Console.WriteLine(o.S1);


            //// 5 Read only Property
            //Console.WriteLine(o.S2);


            //// 6 Auto properties
            //o.P2 = 100;
            //Console.WriteLine(o.P2);

            //o.P3 = "shankar";
            //Console.WriteLine(o.P3);


            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            class2 o = new class2();    // creating object of class1
            Console.WriteLine(o.P1);


            class2 o2 = new class2(99);
            Console.WriteLine(o2.P1);

            o = null;
            o2 = null;
            GC.Collect();

            Console.ReadLine();
        }
    }

  
 
    public class class1
    {
        //// 1 Without using setter getter 
        //public int i;



        //// 2 Using setter getter
        //private int i;
        //public void SetI(int x) 
        //{
        //    if (x < 100)
        //        i = x;
        //    else
        //        Console.WriteLine("Invalid Number");
        //}

        //public int GetI()
        //{
        //    return i;
        //}


        //// 3 Properties and Validation in .net

        //private int p1;
        //public int P1
        //{
        //    set  //gets called when   o.P1 = 10;
        //    {
        //        //passed value is available as 'value'
        //        if (value < 100)
        //            p1 = value;
        //        else
        //            Console.WriteLine("invalid P1");
        //    }
        //    get  //gets called when Console.WriteLine(o.P1);
        //    {
        //        return p1;
        //    }
        //}



        //// 4 String properties
        //private string s1;
        //public string S1
        //{
        //    set { s1 = value; }
        //    get { return s1; }
        //}



        //// 5 Read only property
        //private string s2 = "Lad";
        //public string S2
        //{
        //    get { return s2; }
        //}


        //// 6 Auto properties
        //public int P2 { get; set; }
        //public string P3 { get; set; }


    }


    public class class2
    {
        public class2()
        {
            Console.WriteLine("0 param constructor");
            P1 = 5;
        }

        public class2(int P1)
        {
            Console.WriteLine("1 param constructor");
            this.P1 = P1;
        }


        ~class2()
        {
            Console.WriteLine("DESTRUCTOR");
        }


        //property
        private int p1;
        public int P1
        {
            set  //gets called when   o.P1 = 10;
            {
                //passed value is available as 'value'
                if (value < 100)
                    p1 = value;
                else
                    Console.WriteLine("invalid P1");
            }
            get  //gets called when Console.WriteLine(o.P1);
            {
                return p1;
            }
        }

    }
}
