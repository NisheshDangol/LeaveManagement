using LeaveManagement.Models;
using LeaveManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace LeaveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveMgmtController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApiDbContext _context;

        public static Tbl_user user = new Tbl_user();

        public LeaveMgmtController(ILogger<WeatherForecastController> logger, ApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("register")]
        public Task<ActionResult<Tbl_user>> Register(Tbl_user request)
        {
            

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Tbl_user request)
        {
            if (user.email != request.email) {
                return BadRequest("User not found");
            }
            if (user.password != request.password) {
                return BadRequest("Incorrect Password");
            }              

            return Ok();
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("leave")]
        public async Task<ActionResult<string>> add_leave(int id, string leave_type_name)
        {
            Tbl_leavetype tbl_Leavetype = new Tbl_leavetype()
            {
                user_id = id,
                name = leave_type_name,
                created_date = DateOnly.FromDateTime(DateTime.UtcNow),
                updated_date = DateOnly.FromDateTime(DateTime.UtcNow)
            };
            _context.tbl_leave_type.Add(tbl_Leavetype);
            _context.SaveChanges();
            return Ok("Successfully leave added");
        }
    }
}
