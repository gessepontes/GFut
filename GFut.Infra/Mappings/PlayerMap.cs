using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace GFut.Infra.Data.Mappings
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.IdTeam);
        
            builder.Property(c => c.IdTeam)
                .IsRequired()
                .HasColumnName("IdTeam");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture");

            builder.Property(c => c.Fone)
                .IsRequired()
                .HasColumnName("Fone");

            builder.Property(c => c.Rg)
                .IsRequired()
                .HasColumnName("Rg");

            builder.Property(c => c.Position)
                .IsRequired()
                .HasColumnName("Position");

            builder.Property(c => c.Dispensed)
                .IsRequired()
                .HasColumnName("Dispensed");

            builder.Property(c => c.DispenseDate)
                .IsRequired()
                .HasColumnName("DispenseDate");
        }
    }
}
