using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFut.Infra.Data.Mappings
{
    public class PlayerAssistanceMap : IEntityTypeConfiguration<PlayerAssistance>
    {
        public void Configure(EntityTypeBuilder<PlayerAssistance> builder)
        {
            builder.ToTable("PlayerAssistance");

            builder.HasKey(c => c.Id);

            builder.HasOne(p => p.MatchPlayer)
                .WithMany(t => t.PlayerAssistance)
                .HasForeignKey(m => m.MatchPlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatchPlayerId)
                .IsRequired()
                .HasColumnName("MatchPlayerId")
                .HasColumnType("int");

            builder.Property(c => c.Assistance)
                .IsRequired()
                .HasColumnName("Assistance")
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
