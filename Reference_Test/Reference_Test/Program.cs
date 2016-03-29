using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper<MyClass> cl1 = new Wrapper<MyClass>();
            cl1.Value = new MyClass();
            Wrapper<MyClass> cl2 = cl1;
            cl1.Value = null;
            Console.ReadLine();
        }
    }
}
