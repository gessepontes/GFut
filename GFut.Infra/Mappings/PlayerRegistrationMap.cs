using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GFut.Infra.Data.Mappings
{
    public class PlayerRegistrationMap : IEntityTypeConfiguration<PlayerRegistration>
    {
        public void Configure(EntityTypeBuilder<PlayerRegistration> builder)
        {
            builder.ToTable("PlayerRegistration");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.Player)
                .WithMany(t => t.PlayerRegistration)
                .HasForeignKey(m => m.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Subscription)
                .WithMany(t => t.PlayerRegistration)
                .HasForeignKey(m => m.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.PlayerId)
                .IsRequired()
                .HasColumnName("PlayerId")
                .HasColumnType("int");

            builder.Property(c => c.SubscriptionId)
                .IsRequired()
                .HasColumnName("SubscriptionId")
                .HasColumnType("int");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("char(1)");

            builder.Property(c => c.ApprovedDate)
                .IsRequired()
                .HasColumnName("ApprovedDate")
                .HasColumnType("datetime");

            builder.Property(c => c.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit");

            builder.Property(c => c.RegisterDate)
                .IsRequired()
                .HasColumnName("RegisterDate")
                .HasColumnType("datetime");

        }
    }

}
