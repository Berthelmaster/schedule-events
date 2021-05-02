using System;

namespace backend.Hangfire.Jobs.Recurring
{
    public partial class RecurringJob
    {
        private IServiceProvider _serviceProvider;

        public RecurringJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}