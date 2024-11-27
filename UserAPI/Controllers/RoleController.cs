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

        [Route("Role/AddRole")]
        [HttpPost]
        public async Task<ApiResponse> AddRole(Role role)
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


        [Route("Role/UpdateRole")]
        [HttpPut]
        public async Task<ApiResponse> UpdateRole(Role role)
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

        [Route("Role/DeleteRole")]
        [HttpDelete]
        public async Task<ApiResponse> DeleteRole(Role role)
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


        [Route("Role/GetAllRoles")]
        [HttpGet]
        public ApiResponse GetAllRoles()
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
