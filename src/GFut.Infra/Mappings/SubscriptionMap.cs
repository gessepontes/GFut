using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.Championship)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(m => m.ChampionshipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Team)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.ChampionshipId)
                .IsRequired()
                .HasColumnName("ChampionshipId")
                .HasColumnType("int");

            builder.Property(c => c.TeamId)
                .IsRequired()
                .HasColumnName("TeamId")
                .HasColumnType("int");

            builder.Property(c => c.ApprovedDate)
                .IsRequired()
                .HasColumnName("ApprovedDate")
                .HasColumnType("datetime");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("char(1)");

            builder.Property(c => c.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit");

            builder.Property(c => c.RegisterDate)
                .IsRequired()
                .HasColumnName("RegisterDate")
                .HasColumnType("date");

        }
    }

}
