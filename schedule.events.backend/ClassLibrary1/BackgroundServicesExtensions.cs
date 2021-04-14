using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Hangfire.MemoryStorage;

namespace backend.ClassLibrary1
{
    public static class BackgroundServicesExtensions
    {
        public static void AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage();
            });

            services.AddHangfireServer();
        }

        public static void AddBackgroundServicesDashboard(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
        }
    }
}
