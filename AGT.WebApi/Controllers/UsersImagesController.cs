using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AGT.Contracts.Application.Users;
using AGT.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGT.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersImagesController : Controller
    {
        private readonly IUserService userService;
        private readonly IHostingEnvironment hostingEnvironment;

        public UsersImagesController(IUserService service, IHostingEnvironment environment)
        {
            userService = service;
            hostingEnvironment = environment;
        }

        [HttpPost("{id}")]
        //[Produces("application/json")]
        //[Route("[action]")]
        public async Task<IActionResult> Post(int id)
        {
            Image image;
            try
            {
                image = new Image(HttpContext.Request.Form.Files.GetFile("image"), hostingEnvironment.WebRootPath);
                await SaveImageToDisk(image);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                var user = userService.ChangeProfileImage(id, image.RemoteLink);
                return Ok(user);
            } catch (ApplicationUsersException ex)
            {
                return NotFound(ex.Message);
            }
        }

        private async Task SaveImageToDisk(Image image)
        {
            // Copy contents to memory stream.
            Stream stream = new MemoryStream();
            image.File.CopyTo(stream);
            stream.Position = 0;

            // Save the file
            using (FileStream writerFileStream = System.IO.File.Create(image.InternalServerPath))
            {
                await stream.CopyToAsync(writerFileStream);
                writerFileStream.Dispose();
            }
        }
    }
}
