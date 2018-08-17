using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AGT.Application.Users;
using AGT.Contracts.Application.Users;
using AGT.Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService service)
        {
            userService = service;
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = userService.GetUser(id);
                return Ok(user);
            }
            catch (ApplicationUsersException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                var addedUser = userService.SignUp(user);
                return CreatedAtRoute("GetById", new { id = addedUser.Id }, addedUser);
            } catch(ApplicationUsersException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
