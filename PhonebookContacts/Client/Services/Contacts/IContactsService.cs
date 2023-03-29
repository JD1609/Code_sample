using PhonebookContacts.Dto.Filters;
using PhonebookContacts.Dto.Contact;

namespace PhonebookContacts.Client.Services.Contacts
{
    public interface IContactsService
    {
        Task<List<ContactDto>> GetContactsAsync();
        Task<List<ContactDto>> GetFilteredContactsAsync(ContactsFilter filter);
        Task<ContactDto> GetContactAsync(int id);
        Task<bool> AddContactAsync(ContactDto contact);
        Task<bool> UpdateContactAsync(int id, ContactDto contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
