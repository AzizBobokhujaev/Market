using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 6)]
        public string Password { get; set; }
    }
}