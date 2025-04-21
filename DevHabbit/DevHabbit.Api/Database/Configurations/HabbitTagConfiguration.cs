using DevHabbit.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabbit.Api.Database.Configurations
{
    public class HabbitTagConfiguration: IEntityTypeConfiguration<HabbitTag>
    {
        public void Configure(EntityTypeBuilder<HabbitTag> builder)
        {
            builder.HasKey(ht => new { ht.HabbitId, ht.TagId });

            builder.HasOne<Tag>().WithMany().HasForeignKey(s => s.TagId);
            builder.HasOne<Habbit>().WithMany(h=> h.HabbitTags).HasForeignKey(s => s.HabbitId);
        }
    }
}
