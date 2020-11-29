using System;

namespace GFut.Application.ViewModels
{
    public class MatchSummaryViewModel : BaseEntity
    {
        public int HomeSubscriptionId { get; set; }
        public int GuestSubscriptionId { get; set; }
        public int FieldItemId { get; set; }

        public int HomePoints { get; set; }
        public int GuestPoints { get; set; }

        public DateTime MatchDate { get; set; }
        public string StartTime { get; set; }

        public string Observation { get; set; }
        public bool Calculate { get; set; }
        public int Round { get; set; }

        public virtual FieldItemViewModel FieldItem { get; set; }
        public  SubscriptionViewModel GuestSubscription { get; set; }
        public  SubscriptionViewModel HomeSubscription { get; set; }


        //public virtual ICollection<MatchPlayerChampionship> MatchPlayerChampionships { get; set; }
    }
}
