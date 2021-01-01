using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class PageProfileMap : IEntityTypeConfiguration<PageProfile>
    {
        public void Configure(EntityTypeBuilder<PageProfile> builder)
        {
            builder.ToTable("PageProfile");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.PageId);

            builder.Property(c => c.ProfileId);

            builder.HasOne(p => p.Page)
                .WithMany(t => t.PageProfiles)
                .HasForeignKey(m => m.PageId);
        }
    }
}
