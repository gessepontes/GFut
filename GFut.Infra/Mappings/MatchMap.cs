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

            builder.HasOne(p => p.Field)
                .WithMany(p => p.Matches)
                .HasForeignKey(p => p.IdField);

            //builder.HasOne(p => p.Team1)
            //    .WithMany(p => p.Matches)
            //    .HasForeignKey(p => p.IdTeam1)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p => p.Team2)
            //    .WithMany(p => p.Matches)
            //    .HasForeignKey(p => p.IdTeam2)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Team1)
                .WithOne(b => b.Match)
                .HasForeignKey<Match>(b => b.IdTeam1);

            //builder.HasOne(a => a.Team2)
            //    .WithOne(b => b.Match)
            //    .HasForeignKey<Match>(b => b.IdTeam2);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdTeam1)
                .IsRequired()
                .HasColumnName("IdTeam1")
                .HasColumnType("int");

            builder.Property(c => c.IdTeam2)
                .IsRequired()
                .HasColumnName("IdTeam2")
                .HasColumnType("int");

            builder.Property(c => c.MatchDate)
                .IsRequired()
                .HasColumnName("MatchDate")
                .HasColumnType("date");

            builder.Property(c => c.StartTime)
                .IsRequired()
                .HasColumnName("StartTime")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.IdField)
                .IsRequired()
                .HasColumnName("IdField")
                .HasColumnType("int");

            builder.Property(c => c.Gol1)
                .IsRequired()
                .HasColumnName("Gol1")
                .HasColumnType("int");

            builder.Property(c => c.Gol2)
                .IsRequired()
                .HasColumnName("Gol2")
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
