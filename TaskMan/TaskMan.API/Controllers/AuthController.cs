using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskMan.API.DTOS;
using TaskMan.API.DTOS.Register;
using TaskMan.Membership.Entities;
using TaskMan.Membership.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskMan.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config,
            IUserService userService)
        {
            _configuration = config;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO logindto)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var token  = await _userService.GetToken(logindto.UserName, logindto.PassWord, key);
            return Ok(token);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var res = await dto.Create();
            if (res.Item1 == true)
                return Ok();
            else
                return BadRequest(res.Item2);
        }

    }
}
