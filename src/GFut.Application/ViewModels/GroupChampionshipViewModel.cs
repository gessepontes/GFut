using System.ComponentModel;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.ViewModels
{
    public class GroupChampionshipViewModel : BaseEntity
    {
        [DisplayName("SubscriptionId")]
        public int SubscriptionId { get; set; }

        [DisplayName("GroupId")]
        public Group GroupId { get; set; }

        public virtual SubscriptionViewModel Subscription { get; set; }
    }
}
