using System;
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class PlayerRegistration : BaseEntity
    {
        public int PlayerId { get; set; }
        public int SubscriptionId { get; set; }
        public char State { get; set; }
        public DateTime ApprovedDate { get; set; }

        public virtual Player Player { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
