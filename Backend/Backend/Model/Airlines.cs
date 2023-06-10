using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Airlines
    {
        [Key]
        public int AirlineId { get; set; }
        public string? AirlineName { get; set; }
        public string? AirlineNo { get; set; }

    }
}
