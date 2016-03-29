using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace JQyery_App
{
    public class DataApiController : ApiController
    {
       public JsonResult<List<dynamic>> GetData()
        {
            List<dynamic> dataList = new List<dynamic>();
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            dataList.Add(new { Id = 1, Name = "Kiran Kumar Mohanty", Age = 24, Salary = 90, Active = true });
            return Json(dataList);
        }
    }
}