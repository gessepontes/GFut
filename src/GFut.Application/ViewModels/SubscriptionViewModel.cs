using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class SubscriptionViewModel : BaseEntity
    {
        [DisplayName("ChampionshipId")]
        public int ChampionshipId { get; set; }

        [DisplayName("TeamId")]
        public int TeamId { get; set; }

        [DisplayName("State")]
        public char State { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ApprovedDate")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime ApprovedDate { get; set; }

        public virtual ChampionshipViewModel Championship { get; set; }
        public virtual TeamViewModel Team { get; set; }
    }
}
