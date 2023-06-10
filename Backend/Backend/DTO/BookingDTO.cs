using Backend.Model;

namespace Backend.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Passanger { get; set; }
        public string? Date { get; set; }
        public int Timing { get; set; }
    }
}
