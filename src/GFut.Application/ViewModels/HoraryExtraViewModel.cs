using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class HoraryExtraViewModel : BaseEntity
    {
        [Display(Name = "FieldItemId")]
        public int FieldItemId { get; set; }

        [Display(Name = "Hour")]
        public string Hour { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public virtual FieldItemViewModel FieldItem { get; set; }

    }
}
