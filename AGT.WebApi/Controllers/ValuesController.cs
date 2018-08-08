using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGT.Application.Users;
using AGT.Contracts.Application.Users;
using AGT.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace AGT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUserService userService;

        public ValuesController(IUserService service)
        {
            userService = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            userService.SignUp(new User("juan123", "as@as.com", "juan", "perez", "asd", DateTime.Today));
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
