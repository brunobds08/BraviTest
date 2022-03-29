using BraviTest.ContactListBackend.Dtos.Contact;

namespace BraviTest.ContactListBackend.Dtos.Person
{
    public class UpdatePersonDto
    {
        public string Name { get; set; }
        public IEnumerable<UpdateContactDto> Contacts { get; set; }
    }
}
