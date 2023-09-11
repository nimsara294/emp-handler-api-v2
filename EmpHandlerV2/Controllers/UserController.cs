using emp_handler_api_v2.EmpHandler.Application.Dtos;
using emp_handler_api_v2.EmpHandler.Application;
using emp_handler_api_v2.EmpHandler.Persistance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Azure;

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
        public async Task<BaseResponse<List<UserDto>>> GetUsers()
        {
            BaseResponse<List<UserDto>> response = new();
            try
            {
                if (_userContext.Users != null)
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

/*                    return LstUser;*/
                    response.data = LstUser;
                }

                if (_userContext.Users == null)
                {
                    response.error = "Invalid ID!";
                }
                return response;

            }
            catch (Exception ex)
            {
                string message = "Error : " + ex.Message;
                response.error = "Error occurred while getting GetUserListAsync";
                response.httpCode = 500;
                response.httpStatus = StatusCodes.Status500InternalServerError;
                HttpContext.Response.StatusCode = response.httpStatus;

                return response;
            }
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<List<UserDto>>> GetUser(int id)
        {
            BaseResponse<List<UserDto>> response = new();
            if(_userContext.Users != null)
            {
                List<UserDto> LstUser = new List<UserDto>();
                var user = await _userContext.Users.FindAsync(id);
                if (user != null)
                {
                    UserDto objUser = new UserDto();
                    objUser.id = user.id;
                    objUser.FirstName = user.fname;
                    objUser.LastName = user.lname;
                    LstUser.Add(objUser);
                }

                if (user == null)
                {
                    response.error = "Invalid ID!";
                }

                response.data = LstUser;
            }

            return response;
        }


        [HttpPost]
        public string PostUser(UserDto user)
        {
            BaseResponse<List<UserDto>> response = new();
            try
            {
                Users userobj = new Users();
                userobj.id = user.id;
                userobj.fname = user.FirstName;
                userobj.lname = user.LastName;

                _userContext.Users.Add(userobj);
                _userContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                string message = "Error : " + ex.Message;
                response.error = "Error occurred while getting GetUserListAsync";
                response.httpCode = 500;
                response.httpStatus = StatusCodes.Status500InternalServerError;
                HttpContext.Response.StatusCode = response.httpStatus;

                return response.error;
            }
        }
    }
}
