using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GFut.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.Property(c => c.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Picture)
                .IsRequired()
                .HasColumnName("Picture")
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(200)");


            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Confirmation)
                .IsRequired()
                .HasColumnName("Confirmation")
                .HasColumnType("bit");

            builder.Property(c => c.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.IdPush)
                .HasColumnName("IdPush")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Token)
                .HasColumnName("Token")
                .HasColumnType("varchar(200)");

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
