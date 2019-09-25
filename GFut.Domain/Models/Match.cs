using System;

namespace GFut.Domain.Models
{
    public class Match : BaseEntity
    {
        public int IdTeam1 { get; set; }
        public int IdTeam2 { get; set; }
        public DateTime MatchDate { get; set; }
        public string StartTime { get; set; }
        public int IdField { get; set; }
        public int Gol1 { get; set; }
        public int Gol2 { get; set; }
        public string TeamNotRegistered { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public Field Field { get; set; }

    }
}
