namespace GFut.Domain.Models
{
    public class MatchPlayer : BaseEntity
    {
        public int MatchId { get; set; }
        public int Number { get; set; }
        public int Assistance { get; set; }
        public int Points { get; set; }

        public virtual Match Match { get; set; }
    }
}
