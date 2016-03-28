using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference_Test
{
    public class Wrapper<T>
    {
        public T Value { get; set; }
    }
    public class MyClass
    {
        public string name { get; set; }
    }
}
