using Backend.Data;
using Backend.DTO;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {

        private readonly BackendApiDbContext _dbContext;

        public BookingController(BackendApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("getDetailById")]
        public async Task<IActionResult> Index(BookingDetails b)
        {
            List<BookingDTO> desiredList = new List<BookingDTO>();
            String connString = "server=IN46TAAL136QSP\\SQLEXPRESS; Database=backendDb; Trusted_Connection=True; TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String sql = "select * from Booking" +
                    " where UserId='"+b.Id+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            
            while (reader.Read())
            {
                BookingDTO bdto = new BookingDTO();
                bdto.Id = reader.GetInt32(0);
                bdto.Passanger = reader.GetInt32(1);
                bdto.Date = reader.GetString(2);
                bdto.User = reader.GetInt32(3);
                bdto.Timing = reader.GetInt32(4);
                desiredList.Add(bdto);
            }


            return Ok(desiredList);
        }

        [HttpPost]
        [Route("AddBooking")]
        public async Task<IActionResult> AddBooking(BookingDTO b)
        {
            String connString = "server=IN46TAAL136QSP\\SQLEXPRESS; Database=backendDb; Trusted_Connection=True; TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String sql = "insert into Booking (PassangerId, Date, UserId, TimingId) " +
                    " values ('"+b.Passanger+"', '"+b.Date+"', '"+b.User+"', '"+b.Timing+"');";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return Ok(await cmd.ExecuteNonQueryAsync());
        }

        [HttpPost]
        [Route("CancelBooking")]
        public async Task<IActionResult> CancelBooking(BookingDTO b)
        {
            Bookings booking = await _dbContext.Booking.FindAsync(b.Id);

            _dbContext.Booking.Remove(booking);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
