using System.ComponentModel.DataAnnotations;

namespace BraviTest.ContactListBackend.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int ContactTypeId { get; set; }
        
        public virtual ContactType ContactType { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
