using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Application.Model;

namespace WCF_Application.Contract
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int Sum(CompositeType compositeType);
        [OperationContract]
        int Subtract(CompositeType compositeType);
        [OperationContract]
        int Multiply(CompositeType compositeType);
        [OperationContract]
        int Divide(CompositeType compositeType);
    }
}
