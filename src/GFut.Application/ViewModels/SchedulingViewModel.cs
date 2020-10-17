using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.ViewModels
{
    public class SchedulingViewModel : BaseEntity
    {
        [Display(Name = "Hour")]
        public string Hour { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "HoraryId")]
        public int HoraryId { get; set; }

        [Display(Name = "SchedulingType")]
        public SchedulingType SchedulingType { get; set; }

        [Display(Name = "HoraryType")]
        public HoraryType HoraryType { get; set; }

        [Display(Name = "State")]
        public StatusP State { get; set; }

        [Display(Name = "PersonId")]
        public int? PersonId { get; set; }

        [Display(Name = "CustomerNotRegistered")]
        public string CustomerNotRegistered { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "CancelDate")]
        public DateTime? CancelDate { get; set; }

        [Display(Name = "PersonCancelId")]
        public int? PersonCancelId { get; set; }

        [Display(Name = "MarkedApp")]
        public bool MarkedApp { get; set; }

        public virtual PersonViewModel Person { get; set; }
        public virtual HoraryViewModel Horary { get; set; }
    }
}
