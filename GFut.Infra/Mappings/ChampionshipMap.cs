using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class ChampionshipMap : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.ToTable("Championship");

            builder.HasOne(p => p.Field)
                .WithMany(p => p.Championship)
                .HasForeignKey(p => p.IdField);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.StartDate)
                .IsRequired()
                .HasColumnName("StartDate");

            builder.Property(c => c.EndDate)
                .IsRequired()
                .HasColumnName("EndDate");

            builder.Property(c => c.ChampionshipType)
                .IsRequired()
                .HasColumnName("ChampionshipType");

            builder.Property(c => c.RefereeType)
                .IsRequired()
                .HasColumnName("RefereeType");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("Type");

            builder.Property(c => c.IdField)
                .IsRequired()
                .HasColumnName("IdField");

            builder.Property(c => c.AmountTeam)
                .IsRequired()
                .HasColumnName("AmountTeam");

            builder.Property(c => c.ReleaseSubscription)
            .IsRequired()
            .HasColumnName("ReleaseSubscription");

            builder.Property(c => c.GoBack)
                .IsRequired()
                .HasColumnName("GoBack");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture");

            builder.Property(c => c.IdPerson)
                .IsRequired()
                .HasColumnName("IdPerson");
        }
    }
}
