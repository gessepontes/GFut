using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class HoraryMap : IEntityTypeConfiguration<Horary>
    {
        public void Configure(EntityTypeBuilder<Horary> builder)
        {
            builder.ToTable("Horary");

            builder.HasOne(p => p.FieldItem)
                .WithMany(p => p.Horarys)
                .HasForeignKey(p => p.FieldItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FieldItemId)
                .IsRequired()
                .HasColumnName("FieldItemId");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnName("Description");

            builder.Property(c => c.DayWeek)
                .IsRequired()
                .HasColumnName("DayWeek");
        }
    }
}
