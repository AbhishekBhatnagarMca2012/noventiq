using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace UserAPI.Controllers
{
    
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("User/AddUser")]
        [HttpPost]
        public async Task<ApiResponse> AddUser(User user)
        {
            try
            {
                if (user != null) // apply validations
                {
                    return await _userService.AddUser(user);
                    
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };

                }
                
            }
            catch (Exception ex)
            {
                // Log
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

        }


        [Route("User/UpdateUser")]
        [HttpPut]
        public async Task<ApiResponse> UpdateUser(User user)
        {
            try
            {
                if (user != null && user.ID != 0) // apply validations
                {
                    return await _userService.UpdateUser(user);
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };

                }

            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

        }

        [Route("User/DeleteUser")]
        [HttpDelete]
        public async Task<ApiResponse> DeleteUser(User user)
        {
            try
            {
                if (user != null && user.ID != 0) // apply validations
                {
                    return await _userService.DeleteUser(user);
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };

                }

            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

        }


        [Route("User/GetAllUser")]
        [HttpGet]
        public ApiResponse GetAllUser()
        {
            try
            {
                return _userService.GetAllUser();
            }
            catch (Exception ex)
            {
                // Log exception
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

        }


    }
}
