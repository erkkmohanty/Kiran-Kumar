using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class ClassInherit : I1, I2
    {
        static ClassInherit()
        {
            Console.WriteLine("ClassInherit Static Constructor");
        }
        public ClassInherit()
        {
            Console.WriteLine("ClassInherit Constructor");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }

        public void Method3()
        {
            Console.WriteLine("Method 3");
        }
        ~ClassInherit()
        {
            Console.WriteLine("ClassInherit Detructor.....................................1");
        }
    }
}