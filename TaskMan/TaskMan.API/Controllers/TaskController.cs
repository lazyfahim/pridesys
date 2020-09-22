using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMan.API.DTOS;
using TaskMan.API.DTOS.Tasks;
using TaskMan.Framework.Services;
using TaskMan.Membership.Entities;
using TaskMan.Membership.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskMan.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;
        public TaskController(IUserService userService, IMapper mapper, ITaskService taskService)
        {
            _userService = userService;
            _mapper = mapper;
            _taskService = taskService;
        }
        // GET: api/<TaskController>
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var username = this.HttpContext.User.Identity.Name;
            IList<User> users = _userService.GetUserListForDropDown(username);
            UserDropDownDTO drops = _mapper.Map<UserDropDownDTO>(users);
            return Ok(new { succeeded = true,users = drops.Users });
        }

        // GET api/<TaskController>/5
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TaskCreateDTO dto)
        {
            var task = _mapper.Map<Framework.Entities.Task>(dto);
            Int32.TryParse(HttpContext.User.Claims.FirstOrDefault().Value,out int userid);
            task.UserId = userid;
            _taskService.AddTask(task);
            return Ok();
        }

        [HttpGet]
        [Route("created")]
        public async Task<IActionResult> Created(int page=1)
        {
            var username = this.HttpContext.User.Identity.Name;
            var tasks =  _taskService.GetOwned(username,page);
            var dto = _mapper.Map<List<ShowTaskDTO>>(tasks.Item1.ToList<Framework.Entities.Task>());
            return Ok(new { succeeded = true,tasks = dto,total = tasks.Item2,display = tasks.Item3 });
        }

        [HttpGet]
        [Route("assigned")]
        public async Task<IActionResult> Assigned(int page = 1)
        {
            var username = this.HttpContext.User.Identity.Name;
            var tasks = _taskService.GetAssigned(username, page);
            var dto = _mapper.Map<List<ShowTaskDTO>>(tasks.Item1.ToList<Framework.Entities.Task>());
            return Ok(new { succeeded = true, tasks = dto, total = tasks.Item2, display = tasks.Item3 });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var username = this.HttpContext.User.Identity.Name;
            var task  = _taskService.GetTask(id, username);
            var dto = _mapper.Map<ShowTaskDTO>(task);
            return Ok(dto);
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut]
        public async Task<IActionResult> Put(ShowTaskDTO dto)
        {
            var username = this.HttpContext.User.Identity.Name;
            if (dto.UserName != username)
                BadRequest("Unauthorized");
            var task = _mapper.Map<Framework.Entities.Task>(dto);
            try
            {
                _taskService.update(task);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var username = this.HttpContext.User.Identity.Name;
            try
            {
                _taskService.Delete(username, id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
