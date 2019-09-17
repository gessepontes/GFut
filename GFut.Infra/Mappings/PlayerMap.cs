using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace GFut.Infra.Data.Mappings
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasOne(p => p.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.IdTeam);
        }
    }
}
