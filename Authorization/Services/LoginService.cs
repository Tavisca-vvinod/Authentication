using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authorization.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.Services
{
    public class LoginService
    {
        private IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private static List<User> users = new List<User>()
    {
        new User("krishna","krishna","admin","krishnamurthy"),
        new User("rama","rama","user","ramamurthy")
    };
        public User Validate(LoginRequest loginCredintials)
        {
            return users.Find(user => (user.UserName.Equals(loginCredintials.UserName) && user.Password.Equals(loginCredintials.Password)));
        }

        public string GenarateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
           new Claim("UserName",user.UserName),
          new Claim("FullName",user.FullName),
          new Claim(ClaimTypes.Role,user.Role)
    };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
               _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
