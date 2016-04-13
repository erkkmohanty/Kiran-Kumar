using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Application_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeServices" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeServices
    {
        [OperationContract]
        public List<Employee> GetEmployeeList();
        [OperationContract]
        public int AddEmployee(Employee employee);
    }
}
