using DataAccessLayer.DBContext;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public async Task<ApiResponse> AddUserRole(Role role)
        {
            try
            {
                return await _roleRepo.AddUserRole(role);
                  
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
                return await _roleRepo.UpdateUserRole(role);

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
                return await _roleRepo.DeleteUserRole(role);

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
                return  _roleRepo.GetAllUserRoles();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
