using System;

namespace GFut.Application.ViewModels
{
    public class TeamViewModel : BaseEntity
    {
        public TeamViewModel()
        {
            State = true;
            Active = true;
        }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Picture { get; set; }
        public int Type { get; set; }
        public string Observation { get; set; }
        public DateTime FundationDate { get; set; }
        public bool State { get; set; }

    }
}
