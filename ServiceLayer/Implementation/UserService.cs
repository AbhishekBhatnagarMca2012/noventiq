using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo; 
        }
        public async Task<ApiResponse> AddUser(User user)
        {
            try
            {
                return await _userRepo.AddUser(user);
                 
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
                return await _userRepo.UpdateUser(user);

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
                return await _userRepo.DeleteUser(user);

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
                return _userRepo.GetAllUser();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
