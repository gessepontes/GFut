namespace GFut.Domain.Models
{
    public class Registered : BaseEntity
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }

        public virtual Championship Championship { get; set; }
        public virtual Team Team { get; set; }
    }
}
