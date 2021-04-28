using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using backend.Database;
using backend.Extensions.Hangfire.Background.Tasks.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions.Hangfire
{
    public static class HangfireJobsExtensions
    {
        public static void AddHangfireJobs(this IServiceCollection service, IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"));
            var context = new AppDbContext(optionsBuilder.Options);

            var jobs = Assembly.GetAssembly(typeof(JobBase))
                ?.GetTypes()
                .Where(mType => mType.IsClass && !mType.IsAbstract && mType.IsSubclassOf(typeof(JobBase)))
                .Select(type => (JobBase) Activator.CreateInstance(type, context))
                .ToList();

            if (jobs != null)
            {
                foreach (var job in jobs)
                {
                    job.AddHangfireJob();
                }   
            }
        }
    }
}