using AutoMapper;
using KiksApp.Core.Entities;
using KiksApp.Core.Services;
using KiksApp.Dto.Dtos;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace KiksApp.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetContacts()
        {
            List<Contact> contacts = await _contactService.GetAllAsync();

            List<ContactDto> contactDtos = new List<ContactDto>();
            
            Mapper.Map(contacts, contactDtos);
            
            return Ok(contactDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetContact(int id)
        {
            Contact contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            ContactDto contactDto = new ContactDto();

            Mapper.Map(contact, contactDto);

            return Ok(contactDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutContact(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactDto.Id)
            {
                return BadRequest();
            }

            try
            {
                contactDto.Id = id;

                Contact contact = await _contactService.GetByIdAsync(id);

                Mapper.Map(contactDto, contact);

                await _contactService.UpdateAsync(contact);
              
                return Ok(contactDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostContact(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact contact = new Contact();
            
            Mapper.Map(contactDto, contact);

            contact.ApplicationUserId = User.Identity.GetUserId();

            contact = await _contactService.AddAsync(contact);
            contactDto.Id = contact.Id;

            return CreatedAtRoute("ApiRoute", new { id = contactDto.Id }, contactDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            Contact contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            await _contactService.DeleteAsync(contact);

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return _contactService.GetByIdAsync(id) != null;
        }
    }
}