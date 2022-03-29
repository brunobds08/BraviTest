using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Dtos.Person;
using BraviTest.ContactListBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BraviTest.ContactListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _personService.GetPeople();

            if (people == null)
            {
                return NoContent();
            }
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NoContent();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson(CreatePersonDto personDto)
        {
            var person = _personService.AddPerson(personDto);

            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpPut]
        public IActionResult UpdatePerson(int personId, [FromBody]UpdatePersonDto personDto)
        {
            var result = _personService.UpdatePerson(personId, personDto);
            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletePerson(int personId)
        {
            var result = _personService.DeletePerson(personId);
            if (result.IsFailed)
            {
                return NoContent();
            }
            return Ok();
        }
    }
}
