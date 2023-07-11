using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Username should be minimum of 2 characters")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "Role Should be either Staff or Customer")]
        public string? Role { get; set; }
    }
}
