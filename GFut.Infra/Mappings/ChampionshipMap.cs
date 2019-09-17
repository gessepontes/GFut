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
                .HasForeignKey(p => p.IdField);

        }
    }
}
