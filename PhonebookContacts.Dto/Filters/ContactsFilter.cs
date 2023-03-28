using System.ComponentModel.DataAnnotations;

namespace PhonebookContacts.Dto.Filters
{
    public class ContactsFilter
    {
        private string? _name;
        private string? _phone;

        public string? Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    _name = null;
                else
                    _name = value.Trim().ToLower();
            }
        }

        [Phone]
        public string? Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _phone = null;
                else
                    _phone = value.Trim();
            }
        }

        public DateTime? BirthFrom { get; set; }
        public DateTime? BirthTo { get; set; }
        public bool IsActive { get; set; }
    }
}
