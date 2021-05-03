using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Hangfire.Jobs.Recurring
{
    public partial class RecurringJob
    {
        public async Task RemoveOldPosts()
        {
            using(IServiceScope scope = _serviceProvider.CreateScope())
            await using (AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                var currentDate = DateTime.UtcNow.AddDays(-7);
                
                Console.WriteLine(currentDate);

                var shouldBeDeletedPosts =
                    await context.Posts.Where(x => x.DateCreated <= currentDate).AsNoTracking().ToListAsync();

                foreach (var post in shouldBeDeletedPosts)
                {
                    Console.WriteLine($"Removing Post => {post.Title}");
                    context.Posts.Remove(post);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}