using ContactInfo.Data;
using ContactInfo.Dtos;
using ContactInfo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                Favorite = request.Favorite
            };

            dbContext.Contacts.Add(EntityContact);
            dbContext.SaveChanges();
            return Ok(EntityContact);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbContext.Contacts.Find(id);

            if(contact is not null)
            {
                dbContext.Contacts.Remove(contact);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
