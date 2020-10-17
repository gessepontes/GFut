using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class GroupChampionshipMap : IEntityTypeConfiguration<GroupChampionship>
    {
        public void Configure(EntityTypeBuilder<GroupChampionship> builder)
        {
            builder.ToTable("GroupChampionship");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.Subscription)
                .WithMany(t => t.GroupChampionships)
                .HasForeignKey(m => m.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.SubscriptionId)
                .IsRequired()
                .HasColumnName("SubscriptionId")
                .HasColumnType("int");

            builder.Property(c => c.GroupId)
                .IsRequired()
                .HasColumnName("GroupId")
                .HasColumnType("char(1)");

            builder.Property(c => c.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit");

            builder.Property(c => c.RegisterDate)
                .IsRequired()
                .HasColumnName("RegisterDate")
                .HasColumnType("datetime");

        }
    }

}
