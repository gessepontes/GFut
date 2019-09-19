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
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.Picture)
            .IsRequired()
            .HasColumnName("Picture");

            builder.Property(c => c.Fone)
                .IsRequired()
                .HasColumnName("Fone");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");


            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Password");

            builder.Property(c => c.Confirmation)
                .IsRequired()
                .HasColumnName("Confirmation");

            builder.Property(c => c.SecurityStamp)
                .IsRequired()
                .HasColumnName("SecurityStamp");

            builder.Property(c => c.IdPush)
                .IsRequired()
                .HasColumnName("IdPush");

            builder.Property(c => c.Token)
                .IsRequired()
                .HasColumnName("Token");
        }
    }
}
