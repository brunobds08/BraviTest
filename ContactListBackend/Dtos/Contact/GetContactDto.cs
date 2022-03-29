namespace BraviTest.ContactListBackend.Dtos.Contact
{
    public class GetContactDto
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int PersonId { get; set; }
    }
}
