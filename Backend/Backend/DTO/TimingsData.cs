using Backend.Model;

namespace Backend.DTO
{
    public class TimingsData
    {
        public int TimingId { get; set; }
        public int AirlineId { get; set; }
        public string? DepartureDate { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArrivalDate { get; set; }
        public string? ArrivalTime { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
    }
}
