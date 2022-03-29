using AutoMapper;
using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Models;
using BraviTest.ContactListBackend.Repositories;
using FluentResults;

namespace BraviTest.ContactListBackend.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public ContactService(IContactRepository contactRepository, 
            IPersonRepository personRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public GetContactDto AddContact(int personId, CreateContactDto contactDto)
        {
            var person = _personRepository.GetPersonById(personId);
            GetContactDto getContactDto = null;

            if (person != null)
            {
                var contact = _mapper.Map<Contact>(contactDto);
                contact.PersonId = personId;
                _contactRepository.AddContact(contact);
                _contactRepository.SaveChanges();

                getContactDto = _mapper.Map<GetContactDto>(contact);
            }

            return getContactDto;
        }

        public Result DeleteContact(int id)
        {
            try
            {
                _contactRepository.DeleteContact(id);
                _contactRepository.SaveChanges();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public IEnumerable<GetContactDto> GetAllContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            return _mapper.Map<List<GetContactDto>>(contacts);
        }

        public GetContactDto GetContactById(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            return _mapper.Map<GetContactDto>(contact);
        }

        public Result UpdateContact(int contactId, UpdateContactDto contactDto)
        {
            var contact = _contactRepository.GetContactById(contactId);
            if (contact == null)
            {
                return Result.Fail("Contact not found");
            }

            _mapper.Map(contactDto, contact);
            _contactRepository.SaveChanges();
            return Result.Ok();
        }
    }
}
