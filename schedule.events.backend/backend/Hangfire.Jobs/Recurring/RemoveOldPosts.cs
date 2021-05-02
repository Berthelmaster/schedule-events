using backend.Database;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Hangfire.Jobs.Recurring
{
    public partial class RecurringJob
    {
        public void RemoveOldPosts()
        {
            using(IServiceScope scope = _serviceProvider.CreateScope())
            using (AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                
            }
        }
    }
}