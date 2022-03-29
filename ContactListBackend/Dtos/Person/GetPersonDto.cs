using BraviTest.ContactListBackend.Dtos.Contact;

namespace BraviTest.ContactListBackend.Dtos.Person
{
    public class GetPersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetContactDto> Contacts { get; set; }
    }
}
