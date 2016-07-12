using Contact_Management_MVC.Models;
using Contact_Management_MVC.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact_Management_MVC.Controllers
{
    public class GroupController : Controller
    {
        private IList<Group> _groupList = new List<Group>();
        private IContactManagerService _service;
        public GroupController()
        {
            _service = new ContactManagerService(new ModelStateWrapper(this.ModelState));
        }

        public GroupController(IContactManagerService service)
        {
            _service = service;
        }
        //
        // GET: /Group/
        public ActionResult Index()
        {
            return View(_service.ListGroups());
        }

        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Group groupToCreate)
        {
            if (_service.CreateGroup(groupToCreate))
                return RedirectToAction("Index");
            return View("Create");
        }

        public ActionResult Delete(int id)
        {
            return View(_service.GetGroup(id));
        }
        [HttpPost]
        public ActionResult Delete(Group groupToDelete)
        {
            _service.DeleteGroup(groupToDelete);
            return RedirectToAction("Index");
        }
    }
}