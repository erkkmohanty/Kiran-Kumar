using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQyery_App.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DynamicControl()
        {
            string[] data = { "1", "2", "3", "4", "5" };
            TempData["Data"] = data;
            return View();
        }
        [HttpPost]
        public ActionResult DynamicControl(FormCollection formCollection)
        {
            string[] dd = Request.Form.GetValues("textbox");
            string[] data = (string[])TempData["Data"];
            foreach (var d in data)
            {
                Response.Write(d);
            }
            return View();
        }
        public JsonResult Delete()
        {
            return Json("Deleted Successfully");
        }
        public ActionResult DynamicTable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DynamicTable(FormCollection collection)
        {
            NameValueCollection data = Request.Form;
            return View();
        }
        [HttpGet]
        public JsonResult GetData()
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
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowForm()
        {
            return View();
        }
        public ActionResult IsUserExists(string userName)
        {
            List<string> UserNameList = new List<string> { 
            "kiran.mohanty1992@gmail.com","hello@hello.com","kiran.mohanty@commdel.net","abc@abc.com","kk@kk.com","a@a.com",""
            };
            var data = UserNameList.Aggregate(userName, (a, b) =>
            {
                return a;
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}