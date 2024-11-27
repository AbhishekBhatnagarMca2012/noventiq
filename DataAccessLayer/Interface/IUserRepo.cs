﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IUserRepo
    {
        Task<ApiResponse> AddUser(User user);
        Task<ApiResponse> UpdateUser(User user);
        Task<ApiResponse> DeleteUser(User user);

        ApiResponse GetAllUser();
    }
}
