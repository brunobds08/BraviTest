using System.ComponentModel.DataAnnotations;

namespace BraviTest.ContactListBackend.Models
{
    public class ContactType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
