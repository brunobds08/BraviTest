using BraviTest.ContactListBackend.Dtos.Contact;
using FluentResults;

namespace BraviTest.ContactListBackend.Services
{
    public interface IContactService
    {
        public GetContactDto AddContact(int personId, CreateContactDto contactDto);
        public Result UpdateContact(int contactId, UpdateContactDto contactDto);
        public Result DeleteContact(int id);
        public GetContactDto GetContactById(int id);
        public IEnumerable<GetContactDto> GetAllContacts();
    }
}
