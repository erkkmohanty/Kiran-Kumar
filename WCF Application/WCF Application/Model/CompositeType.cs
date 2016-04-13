using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Application.Model
{
    [DataContract]
    public class CompositeType
    {
        int value1, value2;
        [DataMember]
        public int Value1
        {
            get { return value1; }
            set { value1 = value; }
        }
        [DataMember]

        public int Value2
        {
            get { return value2; }
            set { value2 = value; }
        }
    }
}
