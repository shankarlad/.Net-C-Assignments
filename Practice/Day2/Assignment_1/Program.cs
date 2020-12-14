using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{

    public class Employee
    {
        #region DataMembers
        // data members
        private int empNo;
        private string empName;
        private decimal basic;
        private short deptNo;
        #endregion

        #region staticmember
        // Static data member
        public static int cnt = 1;
        #endregion

        #region constructor
        // Parameterised constructor
        public Employee(string EMPNAME = null, decimal BASIC = 0, short DEPTNO = 0)
        {
            this.EMPNAME = EMPNAME;
            this.BASIC = BASIC;
            this.DEPTNO = DEPTNO;
            //empNo = Employee.EMPNO;
            //empNo = cnt++;
            EMPNO = cnt++;
        }
        #endregion

        #region Properties
        public int EMPNO
        {
            get
            {
                return empNo;
            }
            private set
            {
                empNo = value;
            }
        }

        public string EMPNAME
        {
            set
            {
                if (value != null)
                    empName = value;
                else
                    Console.WriteLine("Name is Mandetory !!!");
            }

            get
            {
                return empName;
            }
        }

        public decimal BASIC
        {
            set
            {
                if (value > 25000)
                    basic = value;
                else
                    Console.WriteLine("Invalid Basic Salary !!!");
            }

            get
            {
                return basic;
            }
        }
        public short DEPTNO
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Departnment No should be greater than Zero !!!");
            }

            get
            {
                return deptNo;
            }

        }
        #endregion

        #region SalaryCalculation
        public decimal GetNetSalary()
        {
            decimal sal = 0;
            sal = sal + 5000;
            return sal;
        }
        #endregion
        public void Display()
        {
            Console.WriteLine(empNo + " " + empName + " " + deptNo + " " + (basic + GetNetSalary()));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Employee e = new Employee("Shankar", 35000, 101);
            //e.Display();
            //Console.WriteLine();
            //Employee e1 = new Employee("Lad", 40000);
            //e1.Display();
            //Console.WriteLine();
            //Employee e2 = new Employee(null,20000, 103);
            //e2.Display();
            //Console.WriteLine();
            //Employee e3 = new Employee("Shanky", 103);
            //e3.Display();

            Employee o1 = new Employee("Amol", 123465, 10);
            Console.WriteLine();
            Employee o2 = new Employee("Amol", 123465);
            Console.WriteLine();
            Employee o3 = new Employee("Amol");
            Console.WriteLine();
            Employee o4 = new Employee();

            //Employee o1 = new Employee();
            //Employee o2 = new Employee();
            //Employee o3 = new Employee();

            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o3.EMPNO);
          //  Console.WriteLine(o4.EMPNO);

            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o1.EMPNO);
          //  Console.WriteLine(o4.EMPNO);

            Console.ReadLine();
        }
    }


}