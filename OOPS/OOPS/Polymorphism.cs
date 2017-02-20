using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Polymorphism
    {
       public void Print()
        {
            A a = new A();
            a.Method1();
            A a1 = new B();
            a1.Method1();
           // B b = (B)new A();
            //b.Method1();
            B b1 = new B();
            b1.Method1();
        }
    }
}
