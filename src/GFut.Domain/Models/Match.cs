using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class Match : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int FieldId { get; set; }

        public int HomePoints { get; set; }
        public int GuestPoints { get; set; }

        public DateTime MatchDate { get; set; }
        public string StartTime { get; set; }

        public string TeamNotRegistered { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
        public virtual Field Field { get; set; }

        public virtual ICollection<MatchPlayer> MatchPlayer { get; set; }

    }
}
