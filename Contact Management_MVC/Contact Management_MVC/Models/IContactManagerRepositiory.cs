using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Management_MVC.Models
{
    public interface IContactManagerRepositiory
    {
        Contact CreateContact(Contact contactToCreate);
        int DeleteContact(Contact Contact);
        Contact EditContact(Contact contactToUpdate);
        Contact GetContact(int id);
        IEnumerable<Contact> GetContactList();
        // Group methods
        Group CreateGroup(Group groupToCreate);
        IEnumerable<Group> ListGroups();
        Group GetGroup(int groupId);
        Group GetFirstGroup();
        void DeleteGroup(Group groupToDelete);
    }
}
