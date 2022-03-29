using BraviTest.ContactListBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BraviTest.ContactListBackend.Data
{
    public class BraviDbContext : DbContext
    {
        public BraviDbContext(DbContextOptions<BraviDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> Types { get; set; }
    }
}
