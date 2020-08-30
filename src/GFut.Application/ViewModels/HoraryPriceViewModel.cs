using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class HoraryPriceViewModel : BaseEntity
    {
        [Display(Name = "FieldItemId")]
        public int FieldItemId { get; set; }

        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Display(Name = "MonthlyValue")]
        public decimal MonthlyValue { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartDate")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndDate")]
        public DateTime? EndDate { get; set; }

        public virtual FieldItemViewModel FieldItem { get; set; }

    }
}
