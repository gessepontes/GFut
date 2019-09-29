using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Symbol)
                .IsRequired()
                .HasColumnName("Symbol")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("int");

            builder.Property(c => c.Observation)
                .HasColumnName("Observation")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.FundationDate)
                .HasColumnName("FundationDate")
                .HasColumnType("date");

            builder.Property(c => c.State)
                .HasColumnName("State")
                .HasColumnType("bit");

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
