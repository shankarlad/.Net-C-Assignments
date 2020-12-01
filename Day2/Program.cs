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
        // Data members
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
        public Employee(string empName = null, decimal basic = 0, short deptNo = 0)
        {
            this.empName = empName;
            this.basic = basic;
            this.deptNo = deptNo;
            //empNo = Employee.EMPNO;
            empNo = cnt++;
        }
        #endregion

        #region Properties
        public int EMPNO
        {
            get 
            {
                return empNo;            
            }
        }

        public string EMPNAME
        {
            set
            {
                if (value == null)
                    Console.WriteLine("Name is Mandetory !!!");
                else
                    empName = value;
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
                if (value > 15000 && value < 50000)
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
            //Employee e = new Employee("Shankar",20000,101);
            //e.Display();
            //Employee e1 = new Employee("Lad", 20000, 102);
            //e1.Display();
            //Employee e2 = new Employee("Shanky",20000,103);
            //e2.Display();


            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465,0);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o4.EMPNO);

            Console.WriteLine();

            Console.WriteLine(o4.EMPNO);
            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o1.EMPNO);

            Console.ReadLine();
        }
    }

   
}
