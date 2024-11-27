using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserAPI.Controllers
{
    public class LoginController : Controller
    {


        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [Route("Login/GenerateToken")]
        public async Task<ApiResponse> GenerateToken([FromBody]User user)
        {
            if (user.UserName == _config["SuperAdmin:UserName"] && user.Password == _config["SuperAdmin:Password"])
            {
                var claim = new[]
                {
                   new  Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                   new  Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                   new Claim ("UserId",user.UserName.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                     claim,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn

                   );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);


                return new ApiResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    ResponseData = new { Token = tokenValue }
                };
            }
            return new ApiResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };

        }
    }
}
