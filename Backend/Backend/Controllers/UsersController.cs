using Backend.Data;
using Backend.DTO;
using Backend.Model;
using Backend.Security;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly BackendApiDbContext _dbContext;

        public UsersController(BackendApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> AddUser(Users u)
        {
            await _dbContext.User.AddAsync(u);
            await _dbContext.SaveChangesAsync();
            List<Users> user = await _dbContext.User.ToListAsync();
            Users newuser = new Users();
            foreach (var item in user)
            {
                if(item.Email.Equals(u.Email) && item.Password.Equals(u.Password))
                {
                    newuser = item;
                    break;
                }
            }
            return Ok(newuser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserCredientials u)
        {
            List<Users> users = await _dbContext.User.ToListAsync();

            Users newuser = new Users();
            if(u != null)
            {
                foreach (var user in users)
                {
                    if (user.Email != null && user.Password != null)
                    {
                        if (user.Email.Equals(u.Email))
                        {
                            if (user.Password.Equals(u.Password))
                            {
                                newuser = user;
                                break;
                            }
                        }
                    }
                }
            }

            if (newuser != null)
                return Ok(newuser);
            else
                return Ok(newuser);
        }
    }
}
