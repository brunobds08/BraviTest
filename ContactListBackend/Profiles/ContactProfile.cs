using AutoMapper;
using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Models;

namespace BraviTest.ContactListBackend.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<Contact, GetContactDto>();
        }
    }
}
