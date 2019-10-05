using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFut.Infra.Data.Mappings
{
    public class MatchPlayerChampionshipMap : IEntityTypeConfiguration<MatchPlayerChampionship>
    {
        public void Configure(EntityTypeBuilder<MatchPlayerChampionship> builder)
        {
            builder.ToTable("MatchPlayerChampionship");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.MatchChampionship)
                .WithMany(t => t.MatchPlayerChampionships)
                .HasForeignKey(m => m.MatchChampionshipId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PlayerRegistration)
                .WithMany(t => t.MatchPlayerChampionships)
                .HasForeignKey(m => m.PlayerRegistrationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatchChampionshipId)
                .IsRequired()
                .HasColumnName("MatchChampionshipId")
                .HasColumnType("int");

            builder.Property(c => c.PlayerRegistrationId)
                .IsRequired()
                .HasColumnName("PlayerRegistrationId")
                .HasColumnType("int");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("int");

            builder.Property(c => c.Points)
                .IsRequired()
                .HasColumnName("Points")
                .HasColumnType("int");

            builder.Property(c => c.Card)
                .IsRequired()
                .HasColumnName("Card")
                .HasColumnType("int");

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
