using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace backend.Extensions.Hangfire.Background.Tasks.Jobs
{
    public class RemoveOldPosts : JobBase
    {
        public RemoveOldPosts(AppDbContext context) : base(context)
        {
            
        }

        public override async void AddHangfireJob()
        {
            Console.Write($"Running Job: {this}");
            
            var currentDate = DateTime.UtcNow.AddDays(-7);

            var shouldBeDeletedPosts =
                await Context.Posts.Where(x => x.Date >= currentDate).AsNoTracking().ToListAsync();

            foreach (var posts in shouldBeDeletedPosts)
            {
                Debug.WriteLine(posts);
            }
            /*
            if (shouldBeDeletedPosts.Count > 0)
            {
                _context.Posts.RemoveRange(shouldBeDeletedPosts);   
            }
            */
            
        }
    }
}