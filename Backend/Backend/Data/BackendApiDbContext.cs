using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class BackendApiDbContext : DbContext
    {
        public BackendApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> User { get; set; } 
        public DbSet<Airlines> Airline { get; set; }
        public DbSet<Passangers> Passanger { get; set; }
        public DbSet<Bookings> Booking { get; set; }
        public DbSet<Timings> Timing { get; set; }
        public DbSet<Admins> Admin { get; set; }
    }
}
