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

                var shouldBeDeletedPosts =
                    await context.Posts.Where(x => x.Date >= currentDate).AsNoTracking().ToListAsync();

                foreach (var posts in shouldBeDeletedPosts)
                {
                    Debug.WriteLine(posts);
                    Console.WriteLine(posts);
                }
            }
        }
    }
}