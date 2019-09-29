namespace GFut.Domain.Models
{
    public class PlayerAssistance : BaseEntity
    {
        public int Assistance { get; set; }
        public int MatchPlayerId { get; set; }

        public virtual MatchPlayer MatchPlayer { get; set; }

    }
}
