using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmet__2
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
            this.EmpName = EmpName;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
            EmpNo = lastEmpNo++;
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

    // Interfaces
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public class Manager : Employee, IDbFunctions
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
                    basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }

            get { return basic; }
        }
      

        public override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 5000;
            return sal;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }


    public class GeneralManager : Manager, IDbFunctions
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
                if (value > 50000 && value < 100000)
                    basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return basic; }
        }

        public GeneralManager(string EmpName = null, short DeptNo = 0, decimal Basic = 0, string Designation = null, string Perks = null) : base(EmpName, DeptNo, Basic,Designation)
        {
            this.Perks = Perks;
        }

        public override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 10000;
            return sal;
        }
    }

    public class CEO : Employee, IDbFunctions
    {
        public override decimal Basic
        {
            set
            {
                if (value > 100000)
                    basic = value;
                else
                    Console.WriteLine("Invalid Salary !!!");
            }
            get { return basic; }
        }

        public CEO(string EmpName = null, short DeptNo = 0, decimal Basic = 0) : base(EmpName, DeptNo,Basic)
        {
            this.Basic = Basic;
        }

        public sealed override decimal CalcNetSalary()
        {
            decimal sal;
            sal = Basic + 20000;
            return sal;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Manager
            //Manager o = new Manager("shankar",101,15000,"SM");
            Manager o = new Manager("shankar", 101, 25000, "SM");
            Console.WriteLine(o.EmpNo + " " + o.EmpName + " " + o.DeptNo + " " + o.Designation + " " + o.Basic + " " + o.CalcNetSalary());

            //GeneralManager o1 = new GeneralManager("Shankar", 102, 15000, "GM", "ALL");
            GeneralManager o1 = new GeneralManager("Shankar", 102,55000, "GM", "ALL");
            Console.WriteLine(o1.EmpNo + " " + o1.EmpName + " " + o1.DeptNo + " " + o1.Designation + " " + o1.Basic + " " + o1.Perks + " " + o1.CalcNetSalary());

            //CEO o2 = new CEO("shankar",103,80000);
            CEO o2 = new CEO("shankar", 103,110000);
            Console.WriteLine(o2.EmpNo + " " + o2.EmpName + " " + o2.DeptNo + " "+ o2.Basic + " " + o2.CalcNetSalary());

            Console.ReadLine();
        }
    }
}
