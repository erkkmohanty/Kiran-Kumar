using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class ClassInherit2: ClassInherit
    {

        static ClassInherit2()
        {
            Console.WriteLine("Static ClassInherit2 Constructor");
        }
        public ClassInherit2()
        {
            Console.WriteLine("ClassInherit2 Constructor");
        }
        ~ClassInherit2()
        {
            Console.WriteLine("ClassInherit2 Destructor...............................................2");
        }
    }
}
