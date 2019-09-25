using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class FieldItemMap : IEntityTypeConfiguration<FieldItem>
    {
        public void Configure(EntityTypeBuilder<FieldItem> builder)
        {
            builder.ToTable("FieldItem");

            builder.HasOne(p => p.Field)
                .WithMany(p => p.FieldItens)
                .HasForeignKey(p => p.IdField);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.IdField)
                .IsRequired()
                .HasColumnName("IdField")
                .HasColumnType("int");

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
