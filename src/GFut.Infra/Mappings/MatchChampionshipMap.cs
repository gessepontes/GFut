using GFut.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class MatchChampionshipMap : IEntityTypeConfiguration<MatchChampionship>
    {
        public void Configure(EntityTypeBuilder<MatchChampionship> builder)
        {
            builder.ToTable("MatchChampionship");
            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.HomeSubscription)
                .WithMany(t => t.HomeChampionshipMatches)
                .HasForeignKey(m => m.HomeSubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GuestSubscription)
                .WithMany(t => t.AwayChampionshipMatches)
                .HasForeignKey(m => m.GuestSubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.FieldItem)
                .WithMany(t => t.MatchChampionships)
                .HasForeignKey(m => m.FieldItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.HomeSubscriptionId)
                .IsRequired()
                .HasColumnName("HomeSubscriptionId")
                .HasColumnType("int");

            builder.Property(c => c.GuestSubscriptionId)
                .IsRequired()
                .HasColumnName("GuestSubscriptionId")
                .HasColumnType("int");

            builder.Property(c => c.FieldItemId)
                .IsRequired()
                .HasColumnName("FieldItemId")
                .HasColumnType("int");

            builder.Property(c => c.MatchDate)
                .IsRequired()
                .HasColumnName("MatchDate")
                .HasColumnType("date");

            builder.Property(c => c.StartTime)
                .IsRequired()
                .HasColumnName("StartTime")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Observation)
                .HasColumnName("Observation")
                .HasColumnType("varchar(300)");

            builder.Property(c => c.Calculate)
                .IsRequired()
                .HasColumnName("Calculate")
                .HasColumnType("bit");

            builder.Property(c => c.HomePoints)
                .IsRequired()
                .HasColumnName("HomePoints")
                .HasColumnType("int");

            builder.Property(c => c.GuestPoints)
                .IsRequired()
                .HasColumnName("GuestPoints")
                .HasColumnType("int");

            builder.Property(c => c.Round)
                .IsRequired()
                .HasColumnName("Round")
                .HasColumnType("int");

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
