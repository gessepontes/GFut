using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFut.Infra.Data.Mappings
{
    public class MatchPlayerMap : IEntityTypeConfiguration<MatchPlayer>
    {
        public void Configure(EntityTypeBuilder<MatchPlayer> builder)
        {
            builder.ToTable("MatchPlayer");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.Match)
                .WithMany(t => t.MatchPlayer)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatchId)
                .IsRequired()
                .HasColumnName("MatchId")
                .HasColumnType("int");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnName("Number")
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
