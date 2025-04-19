using DevHabbit.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabbit.Api.Database.Configurations
{
    public class HabbitConfiguration:IEntityTypeConfiguration<Habbit>
    {
        public void Configure(EntityTypeBuilder<Habbit> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(s => s.Id).HasMaxLength(500);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.Name).HasMaxLength(100);

            builder.OwnsOne(s => s.Frequency);
            builder.OwnsOne(s => s.Target, targetTypeBuilder =>
            {
                targetTypeBuilder.Property(e => e.Unit).HasMaxLength(100);
            });
            builder.OwnsOne(s => s.Milestone);
        }
    }
}
