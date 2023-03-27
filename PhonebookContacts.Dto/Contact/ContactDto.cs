using System.ComponentModel.DataAnnotations;

namespace PhonebookContacts.Dto.Contact
{
    public class ContactDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
