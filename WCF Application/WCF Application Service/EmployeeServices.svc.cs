using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Application_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeServices.svc or EmployeeServices.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeServices : IEmployeeServices
    {
        private MINDEntities _mindEntities = new MINDEntities();
        public List<Employee> GetEmployeeList()
        {
            return _mindEntities.Employees.ToList();
        }

        public int AddEmployee(Employee employee)
        {
            _mindEntities.Employees.Add(employee);
            _mindEntities.Entry<Employee>(employee).State = EntityState.Added;
            return _mindEntities.SaveChanges(); 
        }
    }
}
