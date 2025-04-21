using DevHabbit.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabbit.Api.Database.Configurations
{
    public sealed class TagConfiguration: IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasMaxLength(500);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

            builder.Property(s => s.Description).HasMaxLength(500);

            builder.HasIndex(s => new { s.Name }).IsUnique();
        }
    }
}
