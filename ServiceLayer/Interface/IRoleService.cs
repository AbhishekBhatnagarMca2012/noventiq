using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IRoleService
    {
        Task<ApiResponse> AddUserRole(Role role);
        Task<ApiResponse> UpdateUserRole(Role role);
        Task<ApiResponse> DeleteUserRole(Role role);
        ApiResponse GetAllUserRoles();
    }
}
