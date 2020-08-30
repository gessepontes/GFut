using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class FieldViewModel : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Display(Name = "MonthlyValue")]
        public decimal MonthlyValue { get; set; }

        [Display(Name = "Scheduled")]
        public bool Scheduled { get; set; }

        [Display(Name = "PersonId")]
        public int PersonId { get; set; }

        [Display(Name = "CityId")]
        public int CityId { get; set; }
    }
}
