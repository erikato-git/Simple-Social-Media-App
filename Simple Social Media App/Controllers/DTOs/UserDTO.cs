using System.ComponentModel.DataAnnotations;

namespace Simple_Social_Media_App.Controllers.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Full_Name { get; set; } = string.Empty;
    }
}
