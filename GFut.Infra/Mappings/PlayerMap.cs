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
                .HasColumnName("IdTeam")
                .HasColumnType("int");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Fone)
                .HasColumnName("Fone")
                .HasColumnType("varchar(20)");


            builder.Property(c => c.Rg)
                .HasColumnName("Rg")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Position)
                .IsRequired()
                .HasColumnName("Position")
                .HasColumnType("int");

            builder.Property(c => c.Dispensed)
                .HasColumnName("Dispensed")
                .HasColumnType("bit");

            builder.Property(c => c.DispenseDate)
                .HasColumnName("DispenseDate")
                .HasColumnType("date");

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
