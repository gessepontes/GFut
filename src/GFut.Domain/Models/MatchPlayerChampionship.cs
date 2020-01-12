using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class MatchPlayerChampionship : BaseEntity
    {
        public int MatchChampionshipId { get; set; }
        public int PlayerRegistrationId { get; set; }

        public int Number { get; set; }
        public int Points { get; set; }
        public TipoCartao Card { get; set; }

        public virtual MatchChampionship MatchChampionship { get; set; }
        public virtual PlayerRegistration PlayerRegistration { get; set; }
    }
}
