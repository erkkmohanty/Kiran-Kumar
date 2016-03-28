using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contact_Management_MVC.Models;
using Moq;
using Contact_Management_MVC.Controllers;
using System.Web.Mvc;

namespace Contact_Management_MVC.Tests.Controller
{
    [TestClass]
    public class ContactControllerTest
    {
        private Mock<IContactManagerService> _service;
        [TestInitialize]
        public void Initialize()
        {
            _service = new Mock<IContactManagerService>();
        }

        [TestMethod]
        public void CreateValidContact()
        {
            var contact = new Contact();
            _service.Setup(s => s.CreateContact(contact)).Returns(true);
            var controller = new ContactController(_service.Object);
            var result = (RedirectToRouteResult)controller.Create(contact);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalidContact()
        {
            var contact = new Contact();
            _service.Setup(s => s.CreateContact(contact)).Returns(false);
            var controller = new ContactController(_service.Object);
            var result = (ViewResult)controller.Create(contact);
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
