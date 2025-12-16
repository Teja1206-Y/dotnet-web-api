using System.ComponentModel.DataAnnotations;

namespace Officeworkflows.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; } = "Employee"; // Admin / Employee
    }
}
