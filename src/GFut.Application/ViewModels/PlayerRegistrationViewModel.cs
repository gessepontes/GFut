using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GFut.Application.ViewModels
{
    public class PlayerRegistrationViewModel : BaseEntity
    {
        [DisplayName("PlayerId")]
        public int PlayerId { get; set; }

        [DisplayName("SubscriptionId")]
        public int SubscriptionId { get; set; }

        [DisplayName("State")]
        public char State { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ApprovedDate")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime ApprovedDate { get; set; }

        public virtual PlayerViewModel Player { get; set; }
        public virtual SubscriptionViewModel Subscription { get; set; }
    }
}
