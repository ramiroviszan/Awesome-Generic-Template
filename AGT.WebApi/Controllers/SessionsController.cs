using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGT.Contracts.Application.Sessions;
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
        public IActionResult Get()
        {
            try
            {
                string token = Response.Headers["X-Auth-Token"];
                var allSessions = sessionService.GetAllSessions(new Session() { Token = token });
                return Ok(allSessions);
            }
            catch (ApplicationSessionsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] Session session)
        {
            try
            {
                var fullSession = sessionService.Login(session);
                Response.Headers.Add("X-Auth-Token", fullSession.Token);
                return Ok();
            }
            catch (ApplicationSessionsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Logout()
        {
            try
            {
                string token = Request.Headers["X-Auth-Token"];
                var sessionCount = sessionService.Logout(new Session() { Token = token });
                return Ok(sessionCount);
            }
            catch (ApplicationSessionsException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}