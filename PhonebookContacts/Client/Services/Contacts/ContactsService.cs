using PhonebookContacts.Dto.Contact;
using System.Net.Http.Json;
using PhonebookContacts.Dto.Response;
using PhonebookContacts.Dto.Filters;
using System.Text;
using Newtonsoft.Json;

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

        public async Task<List<ContactDto>?> GetContactsAsync()
        {
            var response = await _http.GetAsync($"api/contacts");

            if (response.IsSuccessStatusCode)
                return response.Content.ReadFromJsonAsync<GenericResponse<List<ContactDto>>>().Result!.Data!;

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result!;
            Console.WriteLine(failedResponse.Message);

            return null;
        }

        public async Task<List<ContactDto>?> GetFilteredContactsAsync(ContactsFilter filter)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("api/contacts/filtered", stringContent);

            if (response.IsSuccessStatusCode)
                return response.Content.ReadFromJsonAsync<GenericResponse<List<ContactDto>>>().Result!.Data!;

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result!;
            Console.WriteLine(failedResponse.Message);

            return null;
        }

        public async Task<ContactDto?> GetContactAsync(int id)
        {
            var response = await _http.GetAsync($"api/contacts/{id}");

            if (response.IsSuccessStatusCode)
                return response.Content.ReadFromJsonAsync<GenericResponse<ContactDto>>().Result!.Data;

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result!;
            Console.WriteLine(failedResponse.Message);

            return null;
        }

        public async Task<(Response, bool)> AddContactAsync(ContactDto contact)
        {
            var response = await _http.PostAsJsonAsync("api/contacts", contact);

            if (response.IsSuccessStatusCode)
                return (response.Content.ReadFromJsonAsync<Response>().Result!, true);

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result!;
            Console.WriteLine(failedResponse.Message);

            return (failedResponse, false);
        }

        public async Task<(Response, bool)> UpdateContactAsync(ContactDto contact)
        {
            var response = await _http.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);

            if (response.IsSuccessStatusCode)
                return (response.Content.ReadFromJsonAsync<Response>().Result!, true);

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result;
            Console.WriteLine(failedResponse!.Message);

            return (failedResponse, false);
        }

        public async Task<(Response, bool)> DeleteContactAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/contacts/{id}");

            if (response.IsSuccessStatusCode)
                return (response.Content.ReadFromJsonAsync<Response>().Result!, true);

            var failedResponse = response.Content.ReadFromJsonAsync<Response>().Result;
            Console.WriteLine(failedResponse!.Message);

            return (failedResponse, false);
        }
    }
}
