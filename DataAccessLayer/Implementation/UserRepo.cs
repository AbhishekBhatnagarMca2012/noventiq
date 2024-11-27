using DataAccessLayer.DBContext;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _appDbContext;

        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ApiResponse> AddUser(User user)
        {
            try
            {
                if (_appDbContext.Roles.Where(i => i.Id == user.RoleID) != null)
                {
                    _appDbContext.Users.Add(user);
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
                        ResponseMessage = "User role doesn't exists"

                    };
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse> UpdateUser(User user)
        {
            try
            {
                if (_appDbContext.Users.Where(i => i.ID == user.ID) != null)
                {
                    if (_appDbContext.Roles.Where(i => i.Id == user.RoleID) != null)
                    {
                        _appDbContext.Users.Update(user);
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
                            ResponseMessage = "User Role doesn't exists"

                        };
                    }
                }
                else
                {
                    return new ApiResponse()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ResponseMessage = "User doesn't exists"

                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse> DeleteUser(User user)
        {
            try
            {
                if (_appDbContext.Users.Where(i => i.ID == user.ID) != null)
                {
                    _appDbContext.Users.Remove(user);
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
                        ResponseMessage = "User doesn't exists"

                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ApiResponse GetAllUser()
        {
            try
            {
                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    ResponseData = _appDbContext.Users.ToList()
                };


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
