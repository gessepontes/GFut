using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class PageMap : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Page");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Href)
                .HasColumnName("Href")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Icon)
                .HasColumnName("Icon")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.ParentId)
                .HasColumnName("ParentId");

            builder.HasOne(p => p.PageNavigation)
                .WithMany(t => t.Pages)
                .HasForeignKey(m => m.ParentId);
        }
    }
}
