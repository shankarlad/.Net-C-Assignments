using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student Details Accepting
            Student[] s = new Student[3];
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("Enter the Details of Student {0} :", i + 1);
                s[i] = new Student();
                s[i].getdata();
            }

            Console.WriteLine();

            //show student data
            Console.WriteLine("===========================");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("Details of Student {0} ", i + 1);
                Console.WriteLine("Roll NO : {0}", s[i].rollNo);
                Console.WriteLine("Name : {0}", s[i].name);
                Console.WriteLine("Marks : {0}", s[i].marks);
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine("===========================");
            Console.ReadLine();
        }
    }
    public struct Student
    {
        public string name;
        public int rollNo;
        public decimal marks;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    name = value;
                else
                    Console.WriteLine("Invalid");
            }
        }
        public int RollNo
        {
            get
            {
                return rollNo;
            }
            set
            {
                if (value > 0)
                    rollNo = value;
                else
                    Console.WriteLine("Invalid");
            }
        }

        public int Marks
        {
            get 
            { 
                return (int)marks;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Invalid");
                else
                    marks = value;
            }
        }
        public Student(int RollNo = 0, string Name = null,decimal Marks = 0)
        {
            rollNo = RollNo;
            name = Name;
            marks = Marks;
        }
        public void getdata()
        {
            Console.WriteLine("Enter the roll no");
            RollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the marks");
            Marks = Convert.ToInt32(Console.ReadLine());   
        }

    }

}