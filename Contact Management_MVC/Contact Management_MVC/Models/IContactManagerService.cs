using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact_Management_MVC.Models
{
    public interface IContactManagerService
    {
        bool CreateContact(Contact contactToCreate);
        bool DeleteContact(Contact contactToDelete);
        bool EditContact(Contact contactToEdit);
        Contact GetContact(int id);
        IEnumerable ListContacts();
        bool CreateGroup(Group groupToCreate);
        IEnumerable ListGroups();
        void DeleteGroup(Group groupToDelete);

        Group GetGroup(int id);
    }
}