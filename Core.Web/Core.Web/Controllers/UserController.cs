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

            if (userToVerify == null) return new UnprocessableEntityResult();

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

            if (!result.Succeeded) return new BadRequestObjectResult(identityUser.UserName);

            userService.Create(new Customer()
            {
                Id = Guid.NewGuid(),
                IdentityUserId = identityUser.Id,
            });

            userService.Save();

            return new OkObjectResult("Account created");
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    var userDtos = _mapper.Map<IList<UserDto>>(users);
        //    return Ok(userDtos);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var user = _userService.GetById(id);
        //    var userDto = _mapper.Map<UserDto>(user);
        //    return Ok(userDto);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody]UserDto userDto)
        //{
        //    // map dto to entity and set id
        //    var user = _mapper.Map<User>(userDto);
        //    user.Id = id;

        //    try
        //    {
        //        // save 
        //        _userService.Update(user, userDto.Password);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // return error message if there was an exception
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _userService.Delete(id);
        //    return Ok();
        //}

    }
}
