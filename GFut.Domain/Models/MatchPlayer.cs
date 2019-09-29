using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class MatchPlayer : BaseEntity
    {
        public int MatchId { get; set; }
        public int Number { get; set; }

        public virtual Match Match { get; set; }

        public virtual ICollection<PlayerPoints> PlayerPoints { get; set; }
        public virtual ICollection<PlayerAssistance> PlayerAssistance { get; set; }

    }
}
