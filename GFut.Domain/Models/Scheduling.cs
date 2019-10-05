using System;
using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class Scheduling : BaseEntity
    {
        public Scheduling()
        {
            MarkedApp = true;
            State = "A";
            SchedulingType = SchedulingType.Avulso;
        }

        public DateTime Date { get; set; }
        public int HoraryId { get; set; }
        public SchedulingType SchedulingType { get; set; }
        public SchedulingType HoraryType { get; set; }
        public string State { get; set; }
        public int? PersonId { get; set; }
        public string CustomerNotRegistered { get; set; }
        public string Fone { get; set; }

        public DateTime? CancelDate { get; set; }
        public int? PersonCancelId { get; set; }
        public bool MarkedApp { get; set; }

        public virtual Person Person { get; set; }

    }
}
