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
            //Employee Details Accepting
            Employee[] e = new Employee[3];
            for (int i = 0; i < e.Length; i++)
            {
                Console.WriteLine("Enter the Details of Employee {0} :", i+1);
                e[i] = new Employee();
                e[i].getdata();
            }

            Console.WriteLine();

            //employee with the heighest salary
            Console.WriteLine("===========================");
            decimal maxSalary = e[0].empSalary;
            string maxSalaryEmpName = null;
            for (int i = 1; i < e.Length; i++)
            {
                if (e[i].empSalary > maxSalary)
                {
                    maxSalary = e[i].empSalary;
                    maxSalaryEmpName = e[i].empName;
                }

            }
            Console.WriteLine("Employee Name : {0} ", maxSalaryEmpName);
            Console.WriteLine("Employee Salary : {0} ", maxSalary);
            Console.WriteLine("===========================");

            Console.WriteLine();

            //Empployee Search
            Console.WriteLine("===========================");
            Console.WriteLine("Enter the Employee No : ");
            int eno = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < e.Length; i++)
            {
                if (eno == e[i].empNo)
                {
                    Console.WriteLine("Employee No : {0}", e[i].empNo);
                    Console.WriteLine("Employee Name : {0}", e[i].empName);
                    Console.WriteLine("Employee Salary : {0} ", e[i].empSalary);
                }
            }
            Console.WriteLine("===========================");
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int empNo;
        public string empName;
        public decimal empSalary;

        public void getdata()
        {
            Console.WriteLine("Enter the Emp Number:");
            empNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Emp Name:");
            empName = Console.ReadLine();
            Console.WriteLine("Enter the Emp Salary:");
            empSalary = Convert.ToInt32(Console.ReadLine());
        }

    }
}