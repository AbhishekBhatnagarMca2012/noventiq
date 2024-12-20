﻿namespace DataAccessLayer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? UserName { get; set; } 
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public Role? Role { get; set; }
        public int RoleID { get; set;}
    }
}
