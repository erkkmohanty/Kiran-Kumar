using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Inheritance
    {
        
        public void Print()
        {
            //I1 i1 = new ClassInherit();
            //i1.Method2();
            //((ClassInherit)(i1)).Method3();

            //ClassInherit cs = new ClassInherit();
            //cs.Method3();
            ClassInherit cs2 = new ClassInherit2();
            cs2.Method2();
        }
    }
}
