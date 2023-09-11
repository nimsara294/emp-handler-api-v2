using emp_handler_api_v2.EmpHandler.Application.Dtos;
using emp_handler_api_v2.EmpHandler.Application;
using emp_handler_api_v2.EmpHandler.Persistance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            if (_userContext.Users == null)
            {
                return NotFound();
            }

            return await _userContext.Users.ToListAsync();
        }*/

        [HttpGet]
        public List<UserDto> GetUsers()
        {
            List<UserDto> LstUser = new List<UserDto>();

            foreach (Users user in _userContext.Users.ToList())
            {
                UserDto objuser = new UserDto();
                objuser.id = user.id;
                objuser.FirstName = user.fname;
                objuser.LastName = user.lname;
                LstUser.Add(objuser);
            }

            return LstUser;
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
