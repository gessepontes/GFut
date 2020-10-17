using System;
using System.Collections.Generic;
using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class GroupChampionship : BaseEntity
    {
        public int SubscriptionId { get; set; }
        public Group GroupId { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
