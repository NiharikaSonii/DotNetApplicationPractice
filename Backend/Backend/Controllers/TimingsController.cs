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
    public class TimingsController : Controller
    {
        private readonly BackendApiDbContext _dbContext;

        public TimingsController(BackendApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPatch]
        [Route("updateSeats")]
        public void updateSeat(BookingDetails b)
        {
                Timings timing = _dbContext.Timing.Find(b.Id);
                if (timing != null)
                {
                    timing.AvailableSeats--;
                    _dbContext.Timing.Update(timing);
                    _dbContext.SaveChanges();
                }
        }


        [HttpPost]
        [Route("getDetailById")]
        public async Task<IActionResult> Index(BookingDetails b)
        {
            Timings timing = _dbContext.Timing.Find(b.Id);
            return Ok(timing);
        }

        [HttpPost]
        [Route("GetAirlines")]
        public async Task<IActionResult> GetAirlinesInfo(TimingsForm tf)
        {
            String connString = "server=IN46TAAL136QSP\\SQLEXPRESS; Database=backendDb; Trusted_Connection=True; TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String sql = "select * from Timing"+
                    " where Boarding='"+tf.From+"' and Destination='"+tf.To+"'"+
                    " and DepartureDate='"+tf.DepartureDate+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);

            //Another way to give Parameters
            /* cmd.Parameters.AddWithValue("@From", tf.From);
            cmd.Parameters.AddWithValue("@To", tf.To);
            cmd.Parameters.AddWithValue("@DepartureDate", tf.DepartureDate);*/

            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            List<Timings> Timinglist = new List<Timings>();
            while (reader.Read())
            {
                Timings td = new Timings();
                td.TimingId = reader.GetInt32(0);
                td.TotalSeats = reader.GetInt32(1);
                td.DepartureDate = reader.GetString(2);
                td.DepartureTime = reader.GetString(3);
                td.ArrivalDate = reader.GetString(4);
                td.ArrivalTime = reader.GetString(5);
                td.Boarding = reader.GetString(6);
                td.Destination = reader.GetString(7);
                td.AirlineName = reader.GetString(8);
                td.AirlineNo = reader.GetString(9);
                td.AvailableSeats = reader.GetInt32(10);
                td.Price = reader.GetInt32(11);
                Timinglist.Add(td);
            }



            return Ok(Timinglist);
        }
    }
}
