using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(u => u.Post)
                .WithMany(c => c.Comments);
            builder.HasOne(u => u.User)
                .WithMany(c => c.Comments);
        }
    }
}