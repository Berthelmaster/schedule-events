using backend.Database;
using Hangfire;

namespace backend.Extensions.Hangfire.Background.Tasks.Jobs
{
    public abstract class JobBase
    {
        protected readonly AppDbContext Context;
        protected readonly BackgroundJobClient Client;

        protected JobBase(AppDbContext context)
        {
            Context = context;
            Client = new BackgroundJobClient();
        }

        public abstract void AddHangfireJob();
    }
}