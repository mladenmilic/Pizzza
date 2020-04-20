using Pizzza.Models;
using Pizzza.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzza.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Pizzza.Models.Response;

namespace Pizzza.DataManager
{
    public class UserManager : IDataRepository
    {
        PizzzaDbContext pizzaContext;
        private readonly AppSettings _appSettings;

        public UserManager(PizzzaDbContext pc, IOptions<AppSettings> appSettings)
        {
            pizzaContext = pc;
            _appSettings = appSettings.Value;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var listUsers =  pizzaContext.Users.ToList();
            return listUsers;
        }

        public async Task<UserResponse> Get(string username, string password)
        {
            var user = pizzaContext.Users.FirstOrDefault(x => x.username == username && x.password == password);
           
            if (user == null)
            {
                throw new Exception( message: "Pogrešan username ili password!");
            }
         
     
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim("userId", user.userId.ToString()),
                    new Claim("fullName",user.fullName.ToString()),
                    new Claim("role", user.role.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserResponse userResponse = new UserResponse();
            userResponse.username = user.username;
            userResponse.userId = user.userId;
            userResponse.fullName = user.fullName;
            userResponse.role = user.role;
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }
    }
}
