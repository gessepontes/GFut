using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class PlayerPointsMap : IEntityTypeConfiguration<PlayerPoints>
    {
        public void Configure(EntityTypeBuilder<PlayerPoints> builder)
        {
            builder.ToTable("PlayerPoints");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.MatchPlayer)
                .WithMany(t => t.PlayerPoints)
                .HasForeignKey(m => m.MatchPlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatchPlayerId)
                .IsRequired()
                .HasColumnName("MatchPlayerId")
                .HasColumnType("int");

            builder.Property(c => c.Points)
                .IsRequired()
                .HasColumnName("Points")
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
