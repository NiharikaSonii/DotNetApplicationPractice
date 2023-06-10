using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Timings
    {
        [Key]
        public int TimingId { get; set; }
        public string? AirlineName { get; set; }
        public string? AirlineNo { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int Price { get; set; }
        public string? DepartureDate { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArrivalDate { get; set; }
        public string? ArrivalTime { get; set; }
        public string? Boarding { get; set; }
        public string? Destination { get; set; }
    }
}
