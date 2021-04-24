using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Database;
using Microsoft.Extensions.Configuration;

namespace backend.Extensions
{
    public static class InfrastructureExtensions
    {

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"));
            });
        }
    }
}
