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
        public int IdHorary { get; set; }
        public SchedulingType SchedulingType { get; set; }
        public SchedulingType HoraryType { get; set; }
        public string State { get; set; }
        public int? IdPerson { get; set; }
        public string CustomerNotRegistered { get; set; }
        public string Fone { get; set; }

        public DateTime? CancelDate { get; set; }
        public int? IdPersonCancel { get; set; }
        public bool MarkedApp { get; set; }
    }
}
