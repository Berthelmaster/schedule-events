using backend.Database;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<Post>>> GetSelectedPosts(List<Post> posts)
        {
            List<Post> postList = new List<Post>();

            foreach (var post in posts)
            {
                var temp = await _context.Posts.Where(x => x.City == post.City && x.Country == post.Country).AsNoTracking().FirstOrDefaultAsync();

                if(temp != null)
                {
                    postList.Add(temp);
                }
            }

            if(postList.Count == 0)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(postList);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreatePost(Post post, int userid)
        {
            if (post == null) return new BadRequestResult();

            var createpost = new Post
            {
                Title = post.Title,
                Content = post.Content,
                Date = post.Date,
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
    }
}
