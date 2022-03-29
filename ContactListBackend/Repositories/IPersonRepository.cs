using BraviTest.ContactListBackend.Models;

namespace BraviTest.ContactListBackend.Repositories
{
    public interface IPersonRepository
    {
        public IEnumerable<Person> GetAllPeople();
        public Person GetPersonById(int id);
        public void AddPerson(Person person);
        public void UpdatePerson(Person person);
        public void DeletePerson(int id);
        public void SaveChanges();
    }
}
