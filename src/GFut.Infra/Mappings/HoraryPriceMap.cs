using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class HoraryPriceMap : IEntityTypeConfiguration<HoraryPrice>
    {
        public void Configure(EntityTypeBuilder<HoraryPrice> builder)
        {
            builder.ToTable("HoraryPrice");

            builder.HasOne(p => p.FieldItem)
                .WithMany(p => p.HoraryPrices)
                .HasForeignKey(p => p.FieldItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FieldItemId)
                .IsRequired()
                .HasColumnName("FieldItemId");

            builder.Property(c => c.StartDate);
            builder.Property(c => c.EndDate);
            builder.Property(c => c.Value);
            builder.Property(c => c.MonthlyValue);
        }
    }
}
