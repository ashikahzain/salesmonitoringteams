using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesMarketingTeamAPI.Models;
using SalesMarketingTeamAPI.Repository;

namespace SalesMarketingTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserRepository _userRepository;
        private IConfiguration _config;

        public LoginController(IUserRepository userRepository, IConfiguration config) 
        {
            _config = config;
            _userRepository = userRepository;
        }

        //To get Token
        [AllowAnonymous]
        [HttpGet("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();
            //Authenticate the user
            var user = AuthenticateUser(username, password);



            //validate
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    uName = user.UserName,
                    UserType = user.UserType,
                    token = tokenString
                }) ;
            }
            return response;
        }



        private Login AuthenticateUser(string username, string password)
        {
            Login user = null;
            user = _userRepository.validateUser(username, password);
            if (user != null)
            {
                return user;
            }
            return user;
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getuser/{username}/{password}")]

        public async Task<ActionResult<Login>> GetUserbyPassword(string username, string password)
        {
            try
            {
                var tblUser = await _userRepository.GetUserByPassword(username, password);
                if (tblUser == null)
                {
                    return NotFound();
                }
                return tblUser;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
        [HttpPost]

        public async Task<ActionResult<Login>> AddUser(Login user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = await _userRepository.AddUser(user);
                    if (UserId > 0)
                    {
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        private string GenerateJSONWebToken(Login user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            //signing credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //Generate token
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
