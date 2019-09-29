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
                .HasForeignKey(p => p.FieldId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");


            builder.Property(c => c.StartDate)
                .IsRequired()
                .HasColumnName("StartDate")
                .HasColumnType("date");

            builder.Property(c => c.EndDate)
                .IsRequired()
                .HasColumnName("EndDate")
                .HasColumnType("date");


            builder.Property(c => c.ChampionshipType)
                .IsRequired()
                .HasColumnName("ChampionshipType")
                .HasColumnType("int");

            builder.Property(c => c.RefereeType)
                .IsRequired()
                .HasColumnName("RefereeType")
                .HasColumnType("int");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("int");

            builder.Property(c => c.FieldId)
                .IsRequired()
                .HasColumnName("FieldId")
                .HasColumnType("int");


            builder.Property(c => c.AmountTeam)
                .IsRequired()
                .HasColumnName("AmountTeam")
                .HasColumnType("int");


            builder.Property(c => c.ReleaseSubscription)
            .IsRequired()
            .HasColumnName("ReleaseSubscription")
                .HasColumnType("bit");


            builder.Property(c => c.GoBack)
                .IsRequired()
                .HasColumnName("GoBack")
                .HasColumnType("bit");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("int");

        }
    }
}
