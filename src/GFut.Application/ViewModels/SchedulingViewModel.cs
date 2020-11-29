using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.ViewModels
{
    public class SchedulingViewModel : BaseEntity
    {
        public string Hour { get; set; }

        public DateTime Date { get; set; }

        public int? HoraryId { get; set; }
        public int? HoraryExtraId { get; set; }

        public SchedulingType SchedulingType { get; set; }

        public HoraryType HoraryType { get; set; }

        public StatusP State { get; set; }

        public int? PersonId { get; set; }

        public string CustomerNotRegistered { get; set; }

        public string Phone { get; set; }

        public DateTime? CancelDate { get; set; }

        public int? PersonCancelId { get; set; }

        public bool MarkedApp { get; set; }

        public virtual PersonViewModel Person { get; set; }
        public virtual HoraryViewModel Horary { get; set; }
        public virtual HoraryExtraViewModel HoraryExtra { get; set; }
    }
}
