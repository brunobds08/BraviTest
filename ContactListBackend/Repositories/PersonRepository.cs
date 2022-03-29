using BraviTest.ContactListBackend.Data;
using BraviTest.ContactListBackend.Models;
using BraviTest.ContactListBackend.Repositories;

namespace BraviTest.ContactListBackend.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BraviDbContext _braviDbContext;

        public PersonRepository(BraviDbContext braviDbContext)
        {
            _braviDbContext = braviDbContext;
        }

        public void AddPerson(Person person)
        {
            _braviDbContext.Add(person);
        }

        public void DeletePerson(int id)
        {
            var person = GetPersonById(id);
            _braviDbContext.Remove(person);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _braviDbContext.People;
        }

        public Person GetPersonById(int id)
        {
            return _braviDbContext.People.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _braviDbContext.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _braviDbContext.Update(person);
        }
    }
}
