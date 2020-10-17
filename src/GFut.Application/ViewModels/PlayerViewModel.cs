using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.ViewModels
{
    public class PlayerViewModel : BaseEntity
    {
        [Display(Name = "TeamId")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string Phone { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public Position Position { get; set; }

        [Display(Name = "Dispensed")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public bool Dispensed { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Dispense Date")]
        public DateTime? DispenseDate { get; set; }
    }
}
