using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class HoraryExtraMap : IEntityTypeConfiguration<HoraryExtra>
    {
        public void Configure(EntityTypeBuilder<HoraryExtra> builder)
        {
            builder.ToTable("HoraryExtra");

            builder.HasOne(p => p.FieldItem)
                .WithMany(p => p.HoraryExtras)
                .HasForeignKey(p => p.FieldItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FieldItemId)
                .IsRequired()
                .HasColumnName("FieldItemId");

            builder.Property(c => c.Hour)
                .IsRequired()
                .HasColumnName("Hour");

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnName("Date");
        }
    }
}
