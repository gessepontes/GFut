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
                .HasForeignKey(p => p.IdFieldItem);
        }
    }
}
