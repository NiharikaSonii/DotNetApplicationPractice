using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Passangers
    {
        [Key]
        public int PassangerId { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Mobile { get; set; }

    }
}
