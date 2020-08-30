using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class FieldMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Field");

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Field)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Address");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasColumnName("Phone");

            builder.Property(c => c.Value)
                .IsRequired()
                .HasColumnName("Value");

            builder.Property(c => c.MonthlyValue)
                .IsRequired()
                .HasColumnName("MonthlyValue");

            builder.Property(c => c.Scheduled)
                .IsRequired()
                .HasColumnName("Scheduled");

            builder.Property(c => c.Picture)
            .IsRequired()
            .HasColumnName("Picture");

            builder.Property(c => c.PersonId)
                .IsRequired()
                .HasColumnName("PersonId");

            builder.Property(c => c.CityId)
                .IsRequired()
                .HasColumnName("CityId");

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
