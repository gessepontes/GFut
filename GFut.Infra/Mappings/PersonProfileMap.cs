using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace GFut.Infra.Data.Mappings
{
    public class PersonProfileMap : IEntityTypeConfiguration<PersonProfile>
    {
        public void Configure(EntityTypeBuilder<PersonProfile> builder)
        {
            builder.ToTable("PersonProfile");

            builder.HasOne(p => p.Person)
                .WithMany(p => p.PersonProfiles)
                .HasForeignKey(p => p.IdPerson);
        }
    }
}
