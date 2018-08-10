using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGT.Contracts.Application.Sessions;
using AGT.Contracts.Application.Users;
using AGT.Domain.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public SessionsController(ISessionService service)
        {
            sessionService = service;
        }


        [HttpGet]
        public IActionResult Get([FromHeader] string session)
        {
            try
            {
                var allSessions = sessionService.GetAllSessions(new Session() { Token = session });
                return Ok(allSessions);
            }
            catch (ApplicationUsersException e)
            {
                return NotFound(e);
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] Session session)
        {
            try
            {
                var fullSession = sessionService.Login(session);
                return Ok(fullSession);
            }
            catch (ApplicationUsersException e)
            {
                return NotFound(e);
            }
        }

        [HttpDelete]
        public IActionResult Logout([FromHeader] string session)
        {
            try
            {
                var sessionCount = sessionService.Logout(new Session() { Token = session });
                return Ok(sessionCount);
            }
            catch (ApplicationUsersException e)
            {
                return NotFound(e);
            }
        }
    }
}