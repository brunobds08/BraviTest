using BraviTest.ContactListBackend.Data;
using BraviTest.ContactListBackend.Models;

namespace BraviTest.ContactListBackend.Repositories
{
    public interface IContactRepository
    {
        public IEnumerable<Contact> GetAllContacts();
        public IEnumerable<Contact> GetAllContacts(int personId);
        public Contact GetContactById(int id);
        public void AddContact(Contact contact);
        public void AddContacts(IEnumerable<Contact> contacts);
        public void UpdateContact(Contact contact);
        public void DeleteContact(int id);
        public void SaveChanges();
    }
}
