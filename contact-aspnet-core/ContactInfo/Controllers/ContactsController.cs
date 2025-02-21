using ContactInfo.Data;
using ContactInfo.Dtos;
using ContactInfo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactInfoDbContext dbContext;

        public ContactsController(ContactInfoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //end point retrive all contacts from database
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var EntityContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Number = request.Number,
                Favoutite = request.Favoutite
            };

            dbContext.Contacts.Add(EntityContact);
            dbContext.SaveChanges();
            return Ok(EntityContact);

        }
    }
}
