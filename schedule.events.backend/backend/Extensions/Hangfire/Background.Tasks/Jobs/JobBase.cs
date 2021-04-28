using backend.Database;

namespace backend.Extensions.Hangfire.Background.Tasks.Jobs
{
    public abstract class JobBase
    {
        protected readonly AppDbContext Context;

        protected JobBase(AppDbContext context)
        {
            Context = context;
        }

        public abstract void AddHangfireJob();
    }
}