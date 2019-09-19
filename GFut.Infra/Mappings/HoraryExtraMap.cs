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
                .HasForeignKey(p => p.IdFieldItem);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdFieldItem)
                .IsRequired()
                .HasColumnName("IdFieldItem");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnName("Description");

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnName("Date");
        }
    }
}
