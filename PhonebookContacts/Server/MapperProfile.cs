using AutoMapper;
using PhonebookContacts.Data.Contact;
using PhonebookContacts.Dto.Contact;

namespace PhonebookContacts.Server
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ContactData, ContactDto>()
                .ReverseMap();
        }
    }
}