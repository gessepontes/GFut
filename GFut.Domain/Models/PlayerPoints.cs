using System;
using System.Collections.Generic;
using System.Text;

namespace GFut.Domain.Models
{
    public class PlayerPoints : BaseEntity
    {
        public int MatchPlayerId { get; set; }
        public int Points { get; set; }

        public virtual MatchPlayer MatchPlayer { get; set; }

    }
}
