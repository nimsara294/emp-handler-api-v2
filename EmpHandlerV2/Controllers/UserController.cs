using emp_handler_api_v2.EmpHandler.Persistance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emp_handler_api_v2.EmpHandlerV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            if(_userContext.Users == null)
            {
                return NotFound();
            }

            return await _userContext.Users.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.id }, user);
        }
    }
}
