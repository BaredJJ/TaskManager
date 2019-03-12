using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class LogIn
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUri { get; set; } = "/";
    }
}
