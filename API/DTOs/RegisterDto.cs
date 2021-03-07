using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be between 4 to 8 character inclussive combining digits, lower case letter, uppercase letter and alpha numeric character")]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}