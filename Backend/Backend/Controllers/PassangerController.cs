using Backend.Data;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PassangerController : Controller
    {
        private readonly BackendApiDbContext _dbContext;

        public PassangerController(BackendApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddPassanger")]
        public async Task<IActionResult> addPassanger(Passangers p)
        {  
            await _dbContext.Passanger.AddAsync(p);
            await _dbContext.SaveChangesAsync();
            List<Passangers> list = await _dbContext.Passanger.ToListAsync();
            Passangers newPass = new Passangers();
            foreach (var item in list)
            {
                if(item.FName.Equals(p.FName) && item.LName.Equals(p.LName) && item.Mobile.Equals(p.Mobile))
                {
                    newPass = item;
                    break;
                }
            }
            return Ok(newPass);
        }
    }
}
