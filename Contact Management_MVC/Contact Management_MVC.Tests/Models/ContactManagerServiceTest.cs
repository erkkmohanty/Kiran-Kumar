using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contact_Management_MVC.Models;
using Moq;
using Contact_Management_MVC.Models.Validation;
using System.Web.Mvc;

namespace Contact_Management_MVC.Tests.Models
{
    [TestClass]
    public class ContactManagerServiceTest
    {
        private Mock<IContactManagerRepositiory> _mockRepository;
        private ModelStateDictionary _modelState;
        private IContactManagerService _service;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IContactManagerRepositiory>();
            _modelState = new ModelStateDictionary();
            _service = new ContactManagerService(new ModelStateWrapper(_modelState), _mockRepository.Object);
        }
        [TestMethod]
        public void CreateContact()
        {
            var contact = new Contact { Id = -1, FirstName = "Stephen", Lastname = "Walther", Phone = "555-5555", Email = "steve@somewhere.com" };
            var result = _service.CreateContact(contact);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FirstNameIsRequired()
        {
            var contact = new Contact { Id = -1, FirstName = string.Empty, Lastname = "Walther", Phone = "555-5555", Email = "steve@somewhere.com" };
            var result = _service.CreateContact(contact);
            Assert.IsFalse(result);
            var error = _modelState["FirstName"].Errors[0];
            Assert.AreEqual("First Name is required", error.ErrorMessage);
        }

        [TestMethod]
        public void LastNameRequired()
        {
            var contact = new Contact { Id = -1, FirstName = "Steve", Lastname = string.Empty, Phone = "555-5555", Email = "steve@somewhere.com" };
            var result = _service.CreateContact(contact);
            Assert.IsFalse(result);
            var error = _modelState["Lastname"].Errors[0];
            Assert.AreEqual("Last Name is required", error.ErrorMessage);
        }
        [TestMethod]
        public void IsValidPhone()
        {
            var contact = new Contact { Id = -1, FirstName = "Steve", Lastname = "Walther", Phone = "5555555", Email = "steve@somewhere.com" };
            var result = _service.CreateContact(contact);
            Assert.IsFalse(result);
            var error = _modelState["Phone"].Errors[0];
            Assert.AreEqual("Phone is required", error.ErrorMessage);
        }
        [TestMethod]
        public void IsValidEmail()
        {
            var contact = new Contact { Id = -1, FirstName = "Steve", Lastname = "Walther", Phone = "555-5555", Email = "steve.somewhere.com" };
            var result = _service.CreateContact(contact);
            Assert.IsFalse(result);
            var error = _modelState["Email"].Errors[0];
            Assert.AreEqual("Email is required", error.ErrorMessage);
        }
       
    }
}
