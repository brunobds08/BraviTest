using AutoMapper;
using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Dtos.Person;
using BraviTest.ContactListBackend.Models;
using BraviTest.ContactListBackend.Repositories;
using FluentResults;

namespace BraviTest.ContactListBackend.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, 
            IContactRepository contactRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public GetPersonDto AddPerson(CreatePersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _personRepository.AddPerson(person);
            _personRepository.SaveChanges();

            var personCreated = _mapper.Map<GetPersonDto>(person);

            if (personDto.Contacts != null)
            {
                var contacts = _mapper.Map<List<Contact>>(personDto.Contacts);
                contacts.ForEach(c => c.PersonId = person.Id);

                _contactRepository.AddContacts(contacts);
                _contactRepository.SaveChanges();

                personCreated.Contacts = _mapper.Map<List<GetContactDto>>(contacts);
            }

            return personCreated;
        }

        public Result DeletePerson(int personId)
        {
            try
            {
                _personRepository.DeletePerson(personId);
                _personRepository.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }

        public IEnumerable<GetContactDto> GetAllContacts(int personId)
        {
            var contactsList = _contactRepository.GetAllContacts(personId);

            return _mapper.Map<List<GetContactDto>>(contactsList);
        }

        public IEnumerable<GetPersonDto> GetPeople()
        {
            var people = _personRepository.GetAllPeople();
            var peopleDto = _mapper.Map<List<GetPersonDto>>(people);
            
            foreach (GetPersonDto person in peopleDto)
            {
                var contactsList = _contactRepository.GetAllContacts(person.Id);
                person.Contacts = _mapper.Map<List<GetContactDto>>(contactsList);
            }

            return peopleDto;
        }

        public GetPersonDto GetPersonById(int personId)
        {
            var person = _personRepository.GetPersonById(personId);
            GetPersonDto personDto = null;
            if (person != null)
            {
                personDto = _mapper.Map<GetPersonDto>(person);

                var contactsList = _contactRepository.GetAllContacts()
                    .Where(p => p.PersonId == personDto.Id);
                personDto.Contacts = _mapper.Map<List<GetContactDto>>(contactsList);
            }

            return personDto;
        }

        public Result UpdatePerson(int personId, UpdatePersonDto personDto)
        {
            var person = _personRepository.GetPersonById(personId);

            if (person == null)
            {
                return Result.Fail("Person not found");
            }
            _mapper.Map(personDto, person);
            // _personRepository.UpdatePerson(person);
            _personRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
