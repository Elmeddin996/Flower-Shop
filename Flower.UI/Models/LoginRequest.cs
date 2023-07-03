using System.ComponentModel.DataAnnotations;

namespace Flowers.UI.Models
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
