using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class SchedulingMap : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("Scheduling");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnName("Date");

            builder.Property(c => c.IdHorary)
                .IsRequired()
                .HasColumnName("IdHorary");

            builder.Property(c => c.SchedulingType)
                .IsRequired()
                .HasColumnName("SchedulingType");

            builder.Property(c => c.HoraryType)
                .IsRequired()
                .HasColumnName("HoraryType");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnName("State");

            builder.Property(c => c.IdPerson)
                .HasColumnName("IdPerson");

            builder.Property(c => c.CustomerNotRegistered)
                .IsRequired()
                .HasColumnName("CustomerNotRegistered");

            builder.Property(c => c.Fone)
                .IsRequired()
                .HasColumnName("Fone");

            builder.Property(c => c.CancelDate)
                .IsRequired()
                .HasColumnName("CancelDate");

            builder.Property(c => c.IdPersonCancel)
                .HasColumnName("IdPersonCancel");

            builder.Property(c => c.MarkedApp)
                .IsRequired()
                .HasColumnName("MarkedApp");

        }
    }
}
