using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{

    public abstract class Employee
    {
        private int empNo;
        private string empName;
        private short deptNo;
        protected decimal basic;
        
        private static int lastEmpNo = 1;

        public Employee(string EmpName = null, short DeptNo = 0, decimal Basic = 0)
        {
            EmpNo = lastEmpNo++;
            this.EmpName = EmpName;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
        }


        public int EmpNo
        {
            private set { empNo = value; }
            get { return empNo; }
        }

        public string EmpName
        {
            set
            {
                if (value != null)
                    empName = value;
                else
                    Console.WriteLine("Please Enter valid Name !!!");
            }
            get { return empName; }
        }
      
        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Please Enter Valid department No !!!");
            }
            get { return deptNo; }
        }

        public abstract decimal Basic
        {
            set;
            get;
        }

        public abstract decimal CalcNetSalary();

    }

    public class Manager : Employee
    {
        public Manager(string EmpName = null, short DeptNo = 0, decimal Basic = 0, string Designation = null) : base(EmpName, DeptNo, Basic)
        {
            this.Designation = Designation;
        }

        private string designation;
        public string Designation
        {
            set
            {
                if (value != null)
                    designation = value;
                else
                    Console.WriteLine("Please Enter valid designation !!!");
            }
            get
            {
                return designation;
            }
        }
        public override decimal Basic
        { 
            set
            {
                if (value > 20000 && value < 50000)
                    Basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return Basic; }
        }


        public override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 5000;
            return sal;
        }
    }
    /*
    public class GeneralManager : Manager
    {
        private string perks;
        public string Perks
        {
            set { perks = value; }
            get { return perks; }
        }

        public override decimal Basic
        {
            set
            {
                if (value > 30000)
                    Basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return Basic; }
        }

        public GeneralManager(string EmpName = null, short DeptNo = 0, decimal Basic = 0, string Designation = null,string Perks = null): base(EmpName, DeptNo,Designation)
        {
            this.Perks = Perks;
            this.Basic = Basic;
        }

        public override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 10000;
            return sal;
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic
        {
            set
            {
                if (value > 100000)
                    Basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return Basic; }
        }

        public CEO(string EmpName = null, short DeptNo = 0,decimal Basic = 0) : base(EmpName,DeptNo)
        {
            this.Basic = Basic;
        }

        public sealed override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 20000;
            return sal;
        }

        //public override string ToString()
        //{
        //    return base.ToString() + " " + CalcNetSalary();
        //}
    }
    */
    class Program
    {
        static void Main(string[] args)
        {
            Manager o = new Manager("Shankar",101,25000,"GM");
            // Console.WriteLine(o.EmpNo + " " + o.EmpName + " " + o.DeptNo + " " + o.Designation + " " + o.CalcNetSalary());
            Console.WriteLine(o.CalcNetSalary());
            Console.ReadLine();
        }
    }
}
