using backend.Database;

namespace backend.Extensions.Hangfire.Background.Tasks.Jobs
{
    public abstract class JobBase
    {
        protected readonly AppDbContext _context;

        protected JobBase(AppDbContext context)
        {
            _context = context;
        }

        public abstract void AddHangfireJob();
    }
}