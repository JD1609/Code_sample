using PhonebookContacts.Dto.Filters;
using PhonebookContacts.Dto.Contact;
using PhonebookContacts.Dto.Response;

namespace PhonebookContacts.Client.Services.Contacts
{
    public interface IContactsService
    {
        Task<List<ContactDto>?> GetContactsAsync();
        Task<List<ContactDto>?> GetFilteredContactsAsync(ContactsFilter filter);
        Task<ContactDto?> GetContactAsync(int id);
        Task<(Response, bool)> AddContactAsync(ContactDto contact);
        Task<(Response, bool)> UpdateContactAsync(ContactDto contact);
        Task<(Response, bool)> DeleteContactAsync(int id);
    }
}
