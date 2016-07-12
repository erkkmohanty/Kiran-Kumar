using Contact_Management_MVC.Models;
using Contact_Management_MVC.Models.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Contact_Management_MVC.Controllers
{
    public class ContactController : Controller
    {
        private IContactManagerService _service;

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(_service.ListContacts());
        }
        public ContactController(IContactManagerService service)
        {
            _service = service;
        }

        public ContactController()
        {
            _service = new ContactManagerService(new ModelStateWrapper(this.ModelState));
        }


        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Contact contactToCreate)
        {
            if (_service.CreateContact(contactToCreate))
                return RedirectToAction("Index");
            return View("Create");
        }



        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetContact(id));
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (_service.EditContact(contact))
                return RedirectToAction("Index");
            return View();
        }

        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.GetContact(id));
        }

        //
        // POST: /Home/Delete/5
        [HttpPost]
        public ActionResult Delete(Contact contact)
        {

            if (_service.DeleteContact(contact))
                return RedirectToAction("Index");
            return View();
        }
    }
}
