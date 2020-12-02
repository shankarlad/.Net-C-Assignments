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
        private decimal basic;
        
        private static int lastEmpNo = 1;

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

        public Employee(string EmpName = null,short DeptNo = 0,decimal Basic = 0)
        {
            EmpNo = lastEmpNo++;
            this.EmpName = EmpName;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
        }

        public abstract decimal CalcNetSalary();

        //public override string ToString()
        //{
        //    return EmpNo + " " + EmpName + " " + DeptNo;
        //}

    }

    public class Manager : Employee
    {
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
                if (value > 20000)
                    Basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return Basic; }
        }

        public Manager(string EmpName = null, short DeptNo = 0, decimal Basic = 0,string Designation = null):base(EmpName,DeptNo,Basic)
        {
            this.Designation = Designation;
        }

        public override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 5000;
            return sal;
        }

        //public override string ToString()
        //{
        //    return base.ToString() + " " + Designation + " " +CalcNetSalary();
        //}
    }

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

        public GeneralManager(string EmpName = null, short DeptNo = 0, decimal Basic = 0, string Designation = null,string Perks = null): base(EmpName, DeptNo, Basic, Designation)
        {
            this.Perks = Perks;
        }

        public override decimal CalcNetSalary()
        {
            return base.CalcNetSalary() + 10000;
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

        public CEO(string EmpName = null, short DeptNo = 0, decimal Basic = 0) : base(EmpName,DeptNo,Basic)
        {

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

    class Program
    {
        static void Main(string[] args)
        {
            CEO o = new CEO("Shankar",101,110000);
            Console.WriteLine(o.EmpNo + " " + o.EmpName + " " + o.DeptNo + o.CalcNetSalary());
            Console.ReadLine();
        }
    }
}
