
using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public partial class Team : BaseEntity
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int PersonId { get; set; }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Picture { get; set; }
        public int Type { get; set; }
        public string Observation { get; set; }
        public DateTime FundationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public Person Person { get; set; }

    }
}