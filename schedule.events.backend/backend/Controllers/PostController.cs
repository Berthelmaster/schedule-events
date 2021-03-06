using backend.Database;
using backend.Models;
using backend.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController
    {
        private readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Post>>> GetSelectedPosts(Geo geo)
        {
            List<Post> postList = new List<Post>();

            if(geo.City != null && geo.Country != null)
            {
                postList = await _context.Posts
                    .Where(x => x.Country == geo.Country && x.City == geo.City)
                    .OrderBy(x => x.Id)
                    .Skip(geo.RangeFrom)
                    .Take(10)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if(geo.Country != null)
            {
                postList = await _context.Posts
                    .Where(x => x.Country == geo.Country)
                    .OrderBy(x => x.Id)
                    .Skip(geo.RangeFrom)
                    .Take(10)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                postList = await _context.Posts
                    .OrderBy(x => x.Id)
                    .Skip(geo.RangeFrom)
                    .Take(10)
                    .AsNoTracking()
                    .ToListAsync();
            }

            if(postList.Count == 0) return new NoContentResult();

            return new OkObjectResult(postList);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreatePost([FromBody] Post post, [FromQuery] int userid)
        {
            if (post == null) return new BadRequestResult();

            var createpost = new Post
            {
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                DateCreated = DateTime.UtcNow.AddHours(1),
                DateStarts = post.DateStarts,
                Starts = post.Starts,
                Ends = post.Ends,
                IsPublic = true,
                IsPublished = true,
                Country = post.Country,
                City = post.City,
                Image = post.Image,
                UserId = userid
            };

            await _context.Posts.AddAsync(createpost);
            var saved = await _context.SaveChangesAsync();

            if (saved > 0) return new OkResult();

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<ActionResult<Post>> GetPost([FromQuery] int id)
        {
            var post = await _context.Posts
                .Include(x => x.Comments)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (post == null) return new BadRequestResult();

            return new OkObjectResult(post);
        }
    }
}
