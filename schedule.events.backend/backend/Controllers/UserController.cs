using backend.Database;
using backend.Helpers;
using backend.Objects.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var claim = Decoder.DecodeJwt(token, Decoder.RequestedClaims.actort);

            var id = int.Parse(claim);

            var user = await _context.Users.FindAsync(id);

            if(user != null)
            {
                return new OkObjectResult(new UserDTO(user));
            }

            return BadRequest();
        }
    }
}
