using Microsoft.AspNetCore.Mvc;
using PhonebookContacts.Dto.Contact;
using PhonebookContacts.Data.Response;
using PhonebookContacts.Server.Services.Contacts;

namespace PhonebookContacts.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : BaseController<ContactController>
    {
        private readonly IContactsService _contactsService;


        #region Ctor
        public ContactController(IContactsService contactsService, ILogger<ContactController> logger) : base(logger)
        {
            _contactsService = contactsService;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<List<ContactDto>>))]
        public async Task<ActionResult<GenericResponse<List<ContactDto>>>> GetContactsAsync(CancellationToken cancellationToken)
        {
            return await CallSafe(async () =>
            {
                return await _contactsService.GetContactsAsync(cancellationToken);
            });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<ContactDto>))]
        public async Task<ActionResult<GenericResponse<ContactDto>>> GetContactAsync(int id, CancellationToken cancellationToken)
        {
            return await CallSafe(async () =>
            {
                return await _contactsService.GetContactAsync(id, cancellationToken);
            });
        }

        [HttpPost]
        public async Task<ActionResult<Response>> AddContactAsync(ContactDto contact, CancellationToken cancellationToken)
        {
            return await CallSafe(async () =>
            {
                return await _contactsService.AddContactAsync(contact, cancellationToken);
            });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response>> UpdateContactAsync(int id, ContactDto contact, CancellationToken cancellationToken)
        {
            return await CallSafe(async () =>
            {
                return await _contactsService.UpdateContactAsync(id, contact, cancellationToken);
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response>> DeleteContactAsync(int id, CancellationToken cancellationToken)
        {
            return await CallSafe(async () =>
            {
                return await _contactsService.DeleteContactAsync(id, cancellationToken);
            });
        }
    }
}
