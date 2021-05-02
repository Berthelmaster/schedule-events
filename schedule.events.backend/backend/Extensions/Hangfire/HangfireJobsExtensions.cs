using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using backend.Database;
using backend.Extensions.Hangfire.Background.Tasks.Jobs;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions.Hangfire
{
    public class HangfireJobsExtensions : IHangfireJobsExtensions
    {

        public void AddHangfireJobs(IServiceProvider serviceProvider)
        {
            var getContext = serviceProvider.GetService<AppDbContext>();
            
            var jobs = Assembly.GetAssembly(typeof(JobBase))
                ?.GetTypes()
                .Where(mType => mType.IsClass && !mType.IsAbstract && mType.IsSubclassOf(typeof(JobBase)))
                .Select(type => (JobBase) Activator.CreateInstance(type, getContext))
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