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

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Scheduling)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("date");

            builder.Property(c => c.HoraryId)
                .IsRequired()
                .HasColumnName("HoraryId")
                .HasColumnType("int");

            builder.Property(c => c.SchedulingType)
                .IsRequired()
                .HasColumnName("SchedulingType")
                .HasColumnType("int");

            builder.Property(c => c.HoraryType)
                .IsRequired()
                .HasColumnName("HoraryType")
                .HasColumnType("int");

            builder.Property(c => c.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("char(1)");

            builder.Property(c => c.PersonId)
                .HasColumnName("PersonId")
                .HasColumnType("int");

            builder.Property(c => c.CustomerNotRegistered)
                .IsRequired()
                .HasColumnName("CustomerNotRegistered")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Fone)
                .IsRequired()
                .HasColumnName("Fone")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.CancelDate)
                .IsRequired()
                .HasColumnName("CancelDate")
                .HasColumnType("datetime");

            builder.Property(c => c.PersonCancelId)
                .HasColumnName("PersonCancelId")
                .HasColumnType("int");

            builder.Property(c => c.MarkedApp)
                .IsRequired()
                .HasColumnName("MarkedApp")
                .HasColumnType("bit");

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
