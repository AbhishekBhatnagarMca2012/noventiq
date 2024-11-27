using DataAccessLayer.DBContext;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class RoleRepo : IRoleRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public RoleRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionStrings");
        }
        public async Task<ApiResponse> AddUserRole(Role role)
        {
            try
            {
                if (_appDbContext.Roles.Where(i => i.Name.ToLower() == role.Name.ToLower()) == null)
                {
                    _appDbContext.Roles.Add(role);
                    await _appDbContext.SaveChangesAsync();

                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,

                    };
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ResponseMessage = "Role Already exists"

                    };
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<ApiResponse> UpdateUserRole(Role role)
        {
            try
            {
                if (_appDbContext.Roles.Where(i => i.Id == role.Id) != null)
                {
                    _appDbContext.Roles.Update(role);
                    await _appDbContext.SaveChangesAsync();

                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,

                    };
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ResponseMessage = "Role doesn't exists"

                    };
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse> DeleteUserRole(Role role)
        {
            try
            {
                if (_appDbContext.Roles.Where(i => i.Id == role.Id) != null)
                {
                    if (_appDbContext.Users.Where(i => i.RoleID == role.Id) == null)
                    {
                        _appDbContext.Remove(role);
                        await _appDbContext.SaveChangesAsync();

                        return new ApiResponse()
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,

                        };
                    }
                    else
                    {
                        return new ApiResponse()
                        {
                            StatusCode = System.Net.HttpStatusCode.BadRequest,
                            ResponseMessage = "Please delete forign ket references first"

                        };
                    }
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ResponseMessage = "Role doesn't exists"

                    };
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ApiResponse GetAllUserRoles()
        {
            try
            {
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    ResponseData = _appDbContext.Roles.ToList()
                };


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
