using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFut.Application.ViewModels
{
    public class ChampionshipViewModel : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartDate")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndDate")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public int Type { get; set; }

        [Display(Name = "FieldId")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public int FieldId { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [DisplayName("AmountTeam")]
        public int AmountTeam { get; set; }

        [Display(Name = "ReleaseSubscription")]
        public bool ReleaseSubscription { get; set; }

        [Display(Name = "GoBack")]
        public bool GoBack { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "PersonId")]
        public int PersonId { get; set; }

        //public ICollection<PersonProfile> PessoaPerfis { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        //public virtual ICollection<Field> Field { get; set; }

    }
}
