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
                .HasForeignKey(p => p.IdPerson);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdPerson)
                .IsRequired()
                .HasColumnName("IdPerson");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Symbol)
                .IsRequired()
                .HasColumnName("Symbol");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("Type");

            builder.Property(c => c.Observation)
                .IsRequired()
                .HasColumnName("Observation");

            builder.Property(c => c.FundationDate)
                .IsRequired()
                .HasColumnName("FundationDate");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnName("State");
        }
    }
}
