using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contact_Management_MVC.Models
{
    public class EntityContactManagerRepository:IContactManagerRepositiory
    {
        private ContactManagerDBEntities GetContactManagerDbEntities()
        {
            return new ContactManagerDBEntities();
        }
        public Contact CreateContact(Contact contactToCreate)
        {
            using(ContactManagerDBEntities _entities=GetContactManagerDbEntities())
            {
                _entities.Contacts.Add(contactToCreate);
                _entities.SaveChanges();
                return contactToCreate;
            }
        }

        public int DeleteContact(Contact Contact)
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                _entities.Contacts.Attach(Contact);
                _entities.Entry(Contact).State = EntityState.Deleted;
                return _entities.SaveChanges();
            }
        }

        public Contact EditContact(Contact contactToUpdate)
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                _entities.Contacts.Attach(contactToUpdate);
                _entities.Entry(contactToUpdate).State = EntityState.Modified;
                return contactToUpdate;
            }
        }

        public Contact GetContact(int id)
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                Contact contact = (from c in _entities.Contacts
                                   where c.Id == id
                                   select c).FirstOrDefault();
                return contact;
            }
        }

        public IEnumerable<Contact> GetContactList()
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                return (from c in _entities.Contacts
                        select c).ToList();
            }
        }


        public IEnumerable<Group> ListGroups()
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                return _entities.Groups.ToList();
            }
        }

        public Group GetFirstGroup()
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                return _entities.Groups.Include(c=>c.Contacts).FirstOrDefault();
            }
        }

        public Group GetGroup(int id)
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                return (from g in _entities.Groups.Include(c=>c.Contacts)
                        where g.Id == id
                        select g).FirstOrDefault();
            }
        }

        public void DeleteGroup(Group groupToDelete)
        {
            using (ContactManagerDBEntities _entities = GetContactManagerDbEntities())
            {
                _entities.Groups.Attach(groupToDelete);
                _entities.Entry(groupToDelete).State = EntityState.Deleted;
                _entities.SaveChanges();
            }

        }


        public Group CreateGroup(Group groupToCreate)
        {
            throw new NotImplementedException();
        }
    }
}