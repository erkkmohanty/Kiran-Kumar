using Contact_Management_MVC.Models.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Contact_Management_MVC.Models
{
    public class ContactManagerService : IContactManagerService
    {
        private IValidationDictionary _validationDictionary;
        private IContactManagerRepositiory _repository;
        public ContactManagerService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new EntityContactManagerRepository())
        { }
        public ContactManagerService(IValidationDictionary validationDictionary, IContactManagerRepositiory repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }
        public bool CreateContact(Contact contactToCreate)
        {
            if (!ValidateContact(contactToCreate))
                return false;
            try
            {
                _repository.CreateContact(contactToCreate);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteContact(Contact contactToDelete)
        {
            try
            {
                _repository.DeleteContact(contactToDelete);
            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }

        public bool EditContact(Contact contactToEdit)
        {
            if (!ValidateContact(contactToEdit))
                return false;
            try
            {
                _repository.EditContact(contactToEdit);
            }
            catch (Exception)
            {

                return false ;
            }
            return true;
        }

        public Contact GetContact(int id)
        {
            try
            {
               return _repository.GetContact(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable ListContacts()
        {
            try
            {
               return _repository.GetContactList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public IEnumerable ListGroups()
        {
            try
            {
                return _repository.ListGroups();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool CreateGroup(Group groupToCreate)
        {
            if (!ValidateGroup(groupToCreate))
                return false;
            try
            {
                 _repository.CreateGroup(groupToCreate);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public void DeleteGroup(Group groupToDelete)
        {
            try
            {
                _repository.DeleteGroup(groupToDelete);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool ValidateContact(Contact contactToValidate)
        {
            if (contactToValidate.FirstName == null || contactToValidate.FirstName.Trim().Length == 0)
                _validationDictionary.AddError("FirstName", "First Name is required");
            if (contactToValidate.Lastname == null || contactToValidate.Lastname.Trim().Length == 0)
                _validationDictionary.AddError("Lastname", "Last Name is required");
            if (contactToValidate.Phone == null || !Regex.IsMatch(contactToValidate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
                _validationDictionary.AddError("Phone", "Phone is required");
            if (contactToValidate.Email == null || !Regex.IsMatch(contactToValidate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                _validationDictionary.AddError("Email", "Email is required");
            return _validationDictionary.IsValid;
        }

        public bool ValidateGroup(Group groupToValidate)
        {
            if (groupToValidate.Name == null || groupToValidate.Name.Trim().Length <= 0)
                _validationDictionary.AddError("Name", "Name is required.");
            return _validationDictionary.IsValid;
        }


        public Group GetGroup(int id)
        {
            throw new NotImplementedException();
        }
    }
}