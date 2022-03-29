using AutoMapper;
using BraviTest.ContactListBackend.Dtos.Person;
using BraviTest.ContactListBackend.Models;

namespace BraviTest.ContactListBackend.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonDto, Person>();
            CreateMap<UpdatePersonDto, Person>();
            CreateMap<Person, GetPersonDto>();
        }
    }
}
