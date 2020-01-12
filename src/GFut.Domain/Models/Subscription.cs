using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class Subscription: BaseEntity
    {
        public int ChampionshipId { get; set; }
        public int TeamId { get; set; }
        public char State { get; set; }
        public DateTime ApprovedDate { get; set; }

        public virtual Championship Championship { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<PlayerRegistration> PlayerRegistration { get; set; }

        public virtual ICollection<MatchChampionship> HomeChampionshipMatches { get; set; }
        public virtual ICollection<MatchChampionship> AwayChampionshipMatches { get; set; }        
    }
}
