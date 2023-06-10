using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
