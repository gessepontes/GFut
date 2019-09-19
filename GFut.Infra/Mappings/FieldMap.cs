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
                .HasForeignKey(p => p.IdPerson);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Address");

            builder.Property(c => c.Fone)
                .IsRequired()
                .HasColumnName("Fone");

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

            builder.Property(c => c.IdPerson)
                .IsRequired()
                .HasColumnName("IdPerson");

            builder.Property(c => c.IdCity)
                .IsRequired()
                .HasColumnName("IdCity");
        }
    }
}
