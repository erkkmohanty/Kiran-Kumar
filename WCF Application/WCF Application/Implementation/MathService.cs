using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Application.Contract;

namespace WCF_Application.Implementation
{
    class MathService:IMathService
    {
        public int Sum(Model.CompositeType compositeType)
        {
            if (compositeType == null)
                throw new ArgumentNullException("compositeType", "Parameter cannot be null");
            return compositeType.Value1 + compositeType.Value2;
        }

        public int Subtract(Model.CompositeType compositeType)
        {
            if (compositeType == null)
                throw new ArgumentNullException("compositeType", "Parameter cannot be null");
            return compositeType.Value1 - compositeType.Value2;
        }

        public int Multiply(Model.CompositeType compositeType)
        {
            if (compositeType == null)
                throw new ArgumentNullException("compositeType", "Parameter cannot be null");
            return compositeType.Value1 * compositeType.Value2;
        }

        public int Divide(Model.CompositeType compositeType)
        {
            if (compositeType == null)
                throw new ArgumentNullException("compositeType", "Parameter cannot be null");
            return compositeType.Value1 / compositeType.Value2;
        }
    }
}
