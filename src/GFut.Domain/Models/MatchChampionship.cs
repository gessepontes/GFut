using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class MatchChampionship : BaseEntity
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

        public virtual FieldItem FieldItem { get; set; }
        public virtual Subscription HomeSubscription { get; set; }
        public virtual Subscription GuestSubscription { get; set; }

        public virtual ICollection<MatchPlayerChampionship> MatchPlayerChampionships { get; set; }
    }
}
