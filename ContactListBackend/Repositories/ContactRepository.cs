using BraviTest.ContactListBackend.Data;
using BraviTest.ContactListBackend.Models;

namespace BraviTest.ContactListBackend.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly BraviDbContext _braviDbContext;

        public ContactRepository(BraviDbContext braviDbContext)
        {
            _braviDbContext = braviDbContext;

            // FOR TESTING PURPOSES
            _braviDbContext.Types.Add(new ContactType() { Type = "Email" });
            _braviDbContext.Types.Add(new ContactType() { Type = "Telefone" });
            _braviDbContext.Types.Add(new ContactType() { Type = "Whatsapp" });
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _braviDbContext.Contacts;
        }

        public Contact GetContactById(int id)
        {
            return _braviDbContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            _braviDbContext.Contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _braviDbContext.Contacts.Update(contact);
        }

        public void DeleteContact(int id)
        {
            var contact = GetContactById(id);
            _braviDbContext.Remove(contact);
        }

        public void SaveChanges()
        {
            _braviDbContext.SaveChanges();
        }

        public void AddContacts(IEnumerable<Contact> contacts)
        {
            _braviDbContext.AddRange(contacts);
        }

        public IEnumerable<Contact> GetAllContacts(int personId)
        {
            return _braviDbContext.Contacts.Where(c => c.PersonId == personId);
        }
    }
}
