using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main1()
        {
            Class1 obj = new Class1();

            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch
            {
                Console.WriteLine("Exception occurred");
            }
            Console.ReadLine();
        }

        static void Main2()
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException occurred");
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void Main3()
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            //catch (ArithmeticException ex)
            //catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void Main4()
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            //catch (DivideByZeroException ex) 
            //catch (ArithmeticException ex) 
            catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            //finally runs when Exception does not occur, or Exception occurs and is handled or or Exception occurs and is NOT handled 
            finally
            {
                Console.WriteLine("finally");

            }
            Console.ReadLine();
        }

        static void Main5()
        {
            Class1 obj = new Class1();
            try
            {
               // obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                try
                {
                    Console.WriteLine("FormatException occurred. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    obj.P1 = 100 / x;
                    Console.WriteLine(obj.P1);
                }
                catch
                {
                    Console.WriteLine("nested try catch example");
                }
                finally
                {
                    Console.WriteLine("nested try finally example");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");

            }
            Console.ReadLine();
        }

    }

    public class Class1
    {
        private int p1;
        public int P1
        {
            set
            {
                p1 = value;
            }
            get
            {
                return p1;
            }
        }
    }
}


namespace ExceptionHandling2
{
    class Program
    {
        static void Main()//try with multiple catch blocks
        {
            Class1 obj = new Class1();
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (InvalidP1Exception ex)
            {
                //Console.WriteLine("Invalid input");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }

    public class Class1
    {
        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //Console.WriteLine("invalid P1"); dont EVER do this

                    Exception ex;
                    //ex = new Exception();
                    //ex = new Exception("Invalid P1");
                    ex = new InvalidP1Exception("Invalid P1");

                    throw ex;
                }
            }
        }
    }
    public class InvalidP1Exception : ApplicationException
    {
        public InvalidP1Exception(string message) : base(message)
        {

        }
    }


}