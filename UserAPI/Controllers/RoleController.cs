using DataAccessLayer.DBContext;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers
{
    
    [ApiController]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("User/AddUserRole")]
        [HttpPost]
        public async Task<ApiResponse> AddUserRole(Role role)
        {
            try
            {
                if (role != null) // apply validations
                {
                    return  await _roleService.AddUserRole(role);                    
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


        [Route("User/UpdateUserRole")]
        [HttpPut]
        public async Task<ApiResponse> UpdateUserRole(Role role)
        {
            try
            {
                if (role != null && role.Id != 0) // apply validations
                {
                    return await _roleService.AddUserRole(role);
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

        [Route("User/DeleteUserRole")]
        [HttpDelete]
        public async Task<ApiResponse> DeleteUserRole(Role role)
        {
            try
            {
                if (role != null && role.Id != 0) // apply validations
                {
                    return await _roleService.AddUserRole(role);
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


        [Route("User/GetAllUserRoles")]
        [HttpGet]
        public ApiResponse GetAllUserRoles()
        {
            try
            {
                return  _roleService.GetAllUserRoles();
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
