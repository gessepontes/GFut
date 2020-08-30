
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class FieldItem : BaseEntity
    {
        public string Name { get; set; }
        public int FieldId { get; set; }
        public string Picture { get; set; }

        public virtual Field Field { get; set; }
        public virtual ICollection<Horary> Horarys { get; set; }
        public virtual ICollection<HoraryPrice> HoraryPrices { get; set; }

        public virtual ICollection<HoraryExtra> HoraryExtras { get; set; }
        public virtual ICollection<MatchChampionship> MatchChampionships { get; set; }
    }
}
