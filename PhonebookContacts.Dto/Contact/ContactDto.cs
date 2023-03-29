using System.ComponentModel.DataAnnotations;

namespace PhonebookContacts.Dto.Contact
{
    public class ContactDto
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "First name can not be empty.")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Last name can not be empty.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, EmailAddress(ErrorMessage = "Email must be valid."), StringLength(100, MinimumLength = 1, ErrorMessage = "Email can not be empty.")]
        public string Email { get; set; } = string.Empty;

        [Required, Phone(ErrorMessage = "Phone number must be valid.")]
        public string? PhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
