using BraviTest.ContactListBackend.Dtos.Contact;
using BraviTest.ContactListBackend.Dtos.Person;
using BraviTest.ContactListBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BraviTest.ContactListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult AddContact([FromQuery] int personId, [FromBody]CreateContactDto contactDto)
        {
            var contact = _contactService.AddContact(personId, contactDto);
            if (contact == null)
            {
                return NoContent();
            }
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return Ok(contact);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactService.GetAllContacts();
            if (contacts == null)
            {
                return NoContent();
            }

            return Ok(contacts);
        }

        [HttpPut("{contactId}")]
        public IActionResult UpdateContact(int contactId, [FromBody]UpdateContactDto contactDto)
        {
            var result = _contactService.UpdateContact(contactId, contactDto);
            if (result.IsFailed)
            {
                return NoContent();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteContact(int contactId)
        {
            var result = _contactService.DeleteContact(contactId);
            if (result.IsFailed)
            {
                return NoContent();
            }
            return Ok();
        }
    }
}
