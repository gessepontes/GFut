using GFut.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.GuestTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.GuestTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Field)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.FieldId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.HomeTeamId)
                .IsRequired()
                .HasColumnName("HomeTeamId")
                .HasColumnType("int");

            builder.Property(c => c.GuestTeamId)
                .IsRequired()
                .HasColumnName("GuestTeamId")
                .HasColumnType("int");

            builder.Property(c => c.MatchDate)
                .IsRequired()
                .HasColumnName("MatchDate")
                .HasColumnType("date");

            builder.Property(c => c.StartTime)
                .IsRequired()
                .HasColumnName("StartTime")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.FieldId)
                .IsRequired()
                .HasColumnName("FieldId")
                .HasColumnType("int");

            builder.Property(c => c.HomePoints)
                .IsRequired()
                .HasColumnName("HomePoints")
                .HasColumnType("int");

            builder.Property(c => c.GuestPoints)
                .IsRequired()
                .HasColumnName("GuestPoints")
                .HasColumnType("int");

            builder.Property(c => c.TeamNotRegistered)
                .HasColumnName("TeamNotRegistered")
                .HasColumnType("varchar(100)");

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
