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
        }
    }
}
