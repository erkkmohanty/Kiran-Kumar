using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections;
using Contact_Management_MVC.Controllers;
using Contact_Management_MVC.Models;
using System.Collections.Generic;
using Contact_Management_MVC.Tests.Models;
using Contact_Management_MVC.Models.Validation;

namespace Contact_Management_MVC.Tests.Controller
{
    [TestClass]
    public class GroupControllerTest
    {
        private IContactManagerRepositiory _repository;
        private IContactManagerService _service;
        private ModelStateDictionary _modelState;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new FakeContactManagerRepository();
            _modelState = new ModelStateDictionary();
            _service = new ContactManagerService(new ModelStateWrapper(_modelState),_repository);
        }

        [TestMethod]
        public void Index()
        {
            var groupController = new GroupController(_service);
            var result = (ViewResult)groupController.Index();
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable));
        }
        [TestMethod]
        public void Create()
        {
            var groupController = new GroupController(_service);
            var groupToCreate = new Group();
            groupToCreate.Name = "Kiran";
            groupController.Create(groupToCreate);
            var result = (ViewResult)groupController.Index();
            var groups = (List<Group>)result.ViewData.Model;
            CollectionAssert.Contains(groups, groupToCreate);
        }

        [TestMethod]
        public void CreateRequireName()
        {
            var groupController = new GroupController(_service);
            var groupToCreate = new Group();
            groupToCreate.Name = string.Empty;
            var result = (ViewResult)groupController.Create(groupToCreate);
            var errors = _modelState["Name"].Errors[0];
            Assert.AreEqual("Name is required.", errors.ErrorMessage);
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
