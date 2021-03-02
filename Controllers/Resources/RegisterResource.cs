using System.ComponentModel.DataAnnotations;

namespace Controllers.Resources
{
    public class RegisterResource
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}