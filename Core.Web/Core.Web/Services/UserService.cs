using Core.Web.Models.Entities;
using Core.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web.Services
{
    public interface IUserService
    {
        void Create(Customer customer);
        string GenerateAccessToken(string userName);
        int Save();
        Task<int> SaveAsync();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration config;
        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            this.config = config;
        }

        public void Create(Customer customer)
        {
            _userRepository.Add(customer);
        }

        public int Save()
        {
            return _userRepository.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _userRepository.SaveChangesAsync();
        }

        public string GenerateAccessToken(string userName)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
