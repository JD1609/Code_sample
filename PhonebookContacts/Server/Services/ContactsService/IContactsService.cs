﻿using PhonebookContacts.Dto.Contact;
using PhonebookContacts.Data.Response;

namespace PhonebookContacts.Server.Services.ContactsService
{
    public interface IContactsService
    {
        Task<GenericResponse<List<ContactDto>>> GetContactsAsync(CancellationToken cancellationToken); // TODO: implement filters
        Task<GenericResponse<ContactDto>> GetContactAsync(int id, CancellationToken cancellationToken);
        Task<Response> AddContactAsync(ContactDto contact, CancellationToken cancellationToken);
        Task<Response> UpdateContactAsync(int id, ContactDto contact, CancellationToken cancellationToken);
        Task<Response> DeleteContactAsync(int id, CancellationToken cancellationToken);
    }
}