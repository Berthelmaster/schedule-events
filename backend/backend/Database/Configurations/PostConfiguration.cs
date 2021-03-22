using backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database.Configurations
{
    public class PostConfiguration
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(c => c.User)
                .WithMany(p => p.Posts);
        }
    }
}
