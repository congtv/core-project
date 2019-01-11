using AutoMapper;
using Core.Web.Models.Entities;
using Core.Web.Models.Entities.Dto.Request;
using Core.Web.Models.Entities.Dto.Result;
using Core.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;
        private UserManager<IdentityUser> userManager;

        public UsersController(
        IUserService userService,
        UserManager<IdentityUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.UserName) || string.IsNullOrWhiteSpace(userRequest.Password))
                return new UnprocessableEntityResult();

            // get the user to verifty
            var userToVerify = await userManager.FindByNameAsync(userRequest.UserName);

            if (userToVerify == null)
                return new UnprocessableEntityResult();

            // check the credentials
            if (await userManager.CheckPasswordAsync(userToVerify, userRequest.Password))
            {
                return new OkObjectResult(new UserLoginResult()
                {
                    UserName = userRequest.UserName,
                    AccessToken = userService.GenerateAccessToken(userRequest.UserName)
                });
            }
            return new BadRequestResult();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest userRequest)
        {
            var identityUser = Mapper.Map<IdentityUser>(userRequest);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userManager.CreateAsync(identityUser, userRequest.Password);

            if (!result.Succeeded)
                return new BadRequestObjectResult(identityUser.UserName);

            userService.Create(new Customer()
            {
                Id = Guid.NewGuid(),
                IdentityUserId = identityUser.Id,
            });

            userService.Save();

            return new OkObjectResult("Account created");
        }
    }
}
