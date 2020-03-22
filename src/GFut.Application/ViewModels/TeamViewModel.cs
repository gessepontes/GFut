using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class TeamViewModel : BaseEntity
    {
        public TeamViewModel()
        {
            State = true;
            Active = true;
        }

        [Display(Name = "PersonId")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Display(Name = "Symbol")]
        public string Symbol { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public int Type { get; set; }

        [Display(Name = "Observation")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string Observation { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fundation Date")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime FundationDate { get; set; }

        [Display(Name = "State")]
        public bool State { get; set; }

    }
}
