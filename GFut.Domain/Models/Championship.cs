
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class Championship : BaseEntity
    {
        public Championship()
        {
            ReleaseSubscription = true;
        }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ChampionshipType ChampionshipType { get; set; }
        public RefereeType RefereeType { get; set; }
        public int Type { get; set; }
        public int IdField { get; set; }
        public int AmountTeam { get; set; }
        public bool ReleaseSubscription { get; set; }
        public bool GoBack { get; set; }
        public string Picture { get; set; }
        public int IdPerson { get; set; }

        public virtual Field Field { get; set; }
        //public virtual ICollection<Registered> Subscribed { get; set; }

    }
}
