using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class HoraryViewModel : BaseEntity
    {
        [Display(Name = "FieldItemId")]
        public int FieldItemId { get; set; }

        [Display(Name = "Hour")]
        public string Hour { get; set; }

        [Display(Name = "DayWeek")]
        public int DayWeek { get; set; }

        [Display(Name = "State")]
        public bool State { get; set; }

        public virtual FieldItemViewModel FieldItem { get; set; }

    }
}
