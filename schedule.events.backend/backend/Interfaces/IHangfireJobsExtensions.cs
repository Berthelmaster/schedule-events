using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IHangfireJobsExtensions
    {
        void AddHangfireJobs(IServiceProvider serviceProvider);
    }
}
