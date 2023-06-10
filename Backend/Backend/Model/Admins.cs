using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Admins
    {
        [Key]
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
