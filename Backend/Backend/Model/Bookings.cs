using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public Passangers Passanger { get; set; }
        public Users User { get; set; }
        public string? Date { get; set; }
        public Timings Timing { get; set; }
    }
}
