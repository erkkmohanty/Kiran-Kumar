using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
            ViewModel vm = new ViewModel();
            vm.TodayDate = new DateTime();
            string[] data = { "1", "2", "3", "4", "5" };
            TempData["Data"] = data;
            return View(vm);
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

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            List<string> listData = new List<string>();
            if(TempData["MyData"]!=null)
            {
                string[] strData = (string[])TempData["MyData"];
                foreach(var d in strData)
                {
                    listData.Add(d);
                }
            }
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                return RedirectToRoutePermanent("KK");
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("DynamicControl");
        }
        [ChildActionOnly]

        public PartialViewResult PartView(int id)
        {
            return PartialView();
        }
        public ActionResult AjaxAction(int id)
        {
            ViewModel vm = new ViewModel();
            vm.TodayDate = DateTime.Now;
            vm.AjaxAction = true;
            vm.Param = id;
            return PartialView(vm);
        }
    }

    public class ViewModel
    {
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime TodayDate;

        public bool AjaxAction = false;

        public int Param;
    }
}