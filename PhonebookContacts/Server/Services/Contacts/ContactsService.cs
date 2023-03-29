using AutoMapper;
using PhonebookContacts.Data.Contact;
using PhonebookContacts.Dto.Contact;
using PhonebookContacts.Dto.Response;
using System.Data;
using PhonebookContacts.Data.Exceptions;
using PhonebookContacts.Dto.Filters;

namespace PhonebookContacts.Server.Services.Contacts
{
    public class ContactsService : IContactsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsService> _logger;


        #region Ctor
        public ContactsService(DataContext context, IMapper mapper, ILogger<ContactsService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        public async Task<GenericResponse<List<ContactDto>>> GetContactsAsync(CancellationToken cancellationToken)
        {
            var response = new GenericResponse<List<ContactDto>>();

            var contacts = await _context.Contacts.ToListAsync(cancellationToken);

            if (contacts == null)
                return response;

            // Mapping can be used already when loading from DB but for possible work with objects I do it here
            var contactsDto = contacts
                .Select(p => _mapper.Map<ContactDto>(p))
                .ToList();

            response.Data = contactsDto;


            return response;
        }

        public async Task<GenericResponse<List<ContactDto>>> GetFilteredContactsAsync(ContactsFilter filter, CancellationToken cancellationToken)
        {
            var response = new GenericResponse<List<ContactDto>>();

            var contacts = await _context.Contacts
                // Name filter
                .Where(c => string.IsNullOrEmpty(filter.Name) 
                    ? true 
                    : (c.FirstName.ToLower() + " " + c.LastName.ToLower()).Contains(filter.Name) || (c.LastName.ToLower() + " " + c.FirstName.ToLower()).Contains(filter.Name))
                // Phone filter
                .Where(c => string.IsNullOrEmpty(filter.Phone)
                    ? true
                    : c.PhoneNumber.Replace(" ", string.Empty).Replace("-", string.Empty).Contains(filter.Phone.Replace(" ", string.Empty).Replace("-", string.Empty)))
                // Birth from filter
                .Where(c => filter.BirthFrom == null
                    ? true
                    : c.BirthDate >= filter.BirthFrom)
                // Birth to filter
                .Where(c => filter.BirthTo == null
                    ? true
                    : c.BirthDate <= filter.BirthTo)
                // IsActive filter
                .Where(c => filter.IsActive ? c.IsActive : true)
                .ToListAsync(cancellationToken);

            if (contacts == null)
                return response;

            // Mapping can be used already when loading from DB but for possible work with objects I do it here
            var contactsDto = contacts
                .Select(p => _mapper.Map<ContactDto>(p))
                .ToList();

            response.Data = contactsDto;


            return response;
        }

        public async Task<GenericResponse<ContactDto>> GetContactAsync(int id, CancellationToken cancellationToken)
        {
            var response = new GenericResponse<ContactDto>();

            var contacts = await _context.Contacts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (contacts == null)
                throw new KeyNotFoundException("Contact not found");

            // Mapping can be used already when loading from DB but for possible work with objects I do it here
            var contactDto = _mapper.Map<ContactDto>(contacts);

            response.Data = contactDto;


            return response;
        }

        public async Task<Response> AddContactAsync(ContactDto contactDto, CancellationToken cancellationToken)
        {
            var response = new Response();

            var contact = _mapper.Map<ContactData>(contactDto);

            await _context.Contacts.AddAsync(contact, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            response.Message = "Contact successfully created.";
            return response;
        }

        public async Task<Response> UpdateContactAsync(int id, ContactDto contactDto, CancellationToken cancellationToken)
        {
            var response = new Response();

            if (id != contactDto.Id)
                throw new BadRequestException("Route ID and object ID are not the same");

            if (!_context.Contacts.Any(c => c.Id == id))
                throw new KeyNotFoundException("Contact not found");


            _context.Contacts.Entry(_mapper.Map<ContactData>(contactDto)).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);


            response.Message = "Contact successfully updated.";
            return response;
        }

        public async Task<Response> DeleteContactAsync(int id, CancellationToken cancellationToken)
        {
            var response = new Response();

            var contact = await _context.Contacts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (contact == null)
                throw new KeyNotFoundException("Contact not found");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync(cancellationToken);


            response.Message = "Contact successfully deleted.";
            return response;
        }
    }
}
