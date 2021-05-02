using System;
using Hangfire;

namespace backend.Extensions.Hangfire
{
    public static class HangfireJobs
    {
        public static void AddHangfireJobs(this IServiceProvider serviceProvider)
        {
            RecurringJob.AddOrUpdate<backend.Hangfire.Jobs.Recurring.RecurringJob>(x => x.RemoveOldPosts(), Cron.Daily);
        }
    }
}