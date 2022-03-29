using System.ComponentModel.DataAnnotations;

namespace BraviTest.ContactListBackend.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
