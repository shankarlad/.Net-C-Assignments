using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples1
{
    class Program
    {
        static void Main1()
        {
            //BaseClass o = new BaseClass();
            
            //DerivedClass o1 = new DerivedClass();
           
            
        }
    }

    public class BaseClass
    {
        public int a;

    }
    public class DerivedClass : BaseClass
    {
        public int b;

    }
}

namespace InheritanceExamples2
{
    class Program
    {
        static void Main()
        {
           // BaseClass o = new BaseClass();
           
           // AccessSpecifiers.BaseClass o = new AccessSpecifiers.BaseClass();
           
           // DerivedClass o = new DerivedClass();
          

        }
    }
    //public -> everywhere
    //private -> same class
    //protected -> same class, derived class
    //internal -> same class, same assembly
    //protected internal -> same class, derived class, same assembly

    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;


    }
    public class DerivedClass : AccessSpecifiers.BaseClass    //: BaseClass
    {

        void DoNothing()
        {
            //this.

        }
    }
}

