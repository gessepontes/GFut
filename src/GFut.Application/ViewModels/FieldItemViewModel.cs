using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class FieldItemViewModel : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Display(Name = "FieldId")]
        public int FieldId { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }
    }
}
