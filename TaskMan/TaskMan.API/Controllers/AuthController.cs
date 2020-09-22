using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config,
            IUserService userService, IMapper mapper)
        {
            _configuration = config;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO logindto)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            try
            {
                var token = await _userService.GetToken(logindto.UserName, logindto.PassWord, key);
                return Ok(new { succeeded=true, token = token});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            try
            {
                var res = await dto.Create();
                if (res.Item1 == true)
                    return Ok();
                else
                    return BadRequest(res.Item2);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers(int page=1)
        {
            try
            {
                var model =  _userService.GetUsers(page);
                var dto = _mapper.Map<List<ShowUserDTO>>(model.Item1);
                return Ok(new { succeeded = true, users = dto,total = model.Item2,totaldisplay = model.Item3 });
            }
            catch(Exception ex)
            {
                return BadRequest(new { succeeded = false, error = ex.Message.ToString() });
            }
        }

    }
}
