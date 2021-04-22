using System.Threading.Tasks;
using backend.Database;
using backend.Helpers;
using backend.Models;
using backend.Objects.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO comment)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var claim = Decoder.DecodeJwt(token, Decoder.RequestedClaims.actort);

            if (claim == null) return BadRequest();
            
            var id = int.Parse(claim);

            var user = await _context.Users.FindAsync(id);

            if (user == null) return BadRequest();

            var addComment = new Comment
            {
                Content = comment.Content,
                WrittenBy = user.FullName,
                UserId = id,
                PostId = comment.PostId
            };

            await _context.AddAsync(addComment);
            var isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0) return Ok();

            return BadRequest();
        }
    }
}