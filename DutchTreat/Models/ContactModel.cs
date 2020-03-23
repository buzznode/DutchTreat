using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class ContactModel
    {
        [MinLength(5)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [MaxLength(250, ErrorMessage = "Message is too long")]
        [Required]
        public string Message { get; set; }
    }
}
