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
        }
    }
}
