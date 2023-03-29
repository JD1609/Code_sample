using PhonebookContacts.Dto.Contact;
using System.Net.Http.Json;
using PhonebookContacts.Dto.Response;
using PhonebookContacts.Dto.Filters;

namespace PhonebookContacts.Client.Services.Contacts
{
    public class ContactsService : IContactsService
    {
        private readonly HttpClient _http;
        
        
        #region Ctor
        public ContactsService(HttpClient _http)
        {
            this._http = _http;
        }
        #endregion

        public async Task<List<ContactDto>> GetContactsAsync()
        {
            var response = await _http.GetFromJsonAsync<GenericResponse<List<ContactDto>>>($"api/contacts");

            return response?.Data ?? new List<ContactDto>();
        }

        public async Task<List<ContactDto>> GetFilteredContactsAsync(ContactsFilter filter)
        {
            var response = await _http.PostAsJsonAsync("api/contacts/filtered", filter);

            return response.Content.ReadFromJsonAsync<GenericResponse<List<ContactDto>>>().Result.Data;
        }

        public async Task<ContactDto> GetContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddContactAsync(ContactDto contact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateContactAsync(int id, ContactDto contact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
