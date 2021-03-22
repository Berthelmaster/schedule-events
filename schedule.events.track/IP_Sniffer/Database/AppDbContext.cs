using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Sniffer.Models;
using Microsoft.EntityFrameworkCore;

namespace IP_Sniffer.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<GeoLocation> GeoLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
