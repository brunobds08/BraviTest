using BraviTest.ContactListBackend.Dtos.Contact;

namespace BraviTest.ContactListBackend.Dtos.Person
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public IEnumerable<CreateContactDto> Contacts { get; set; } = null;
    }
}
