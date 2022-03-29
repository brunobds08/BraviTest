using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Dtos.Person;
using FluentResults;

namespace BraviTest.ContactListBackend.Services
{
    public interface IPersonService
    {
        public GetPersonDto AddPerson(CreatePersonDto personDto);
        public Result UpdatePerson(int personId, UpdatePersonDto personDto);
        public Result DeletePerson(int personId);
        public GetPersonDto GetPersonById(int personId);
        public IEnumerable<GetPersonDto> GetPeople();
        public IEnumerable<GetContactDto> GetAllContacts(int personId);
    }
}
