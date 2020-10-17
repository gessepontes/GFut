namespace GFut.Application.ViewModels
{
    public class StandingsViewModel : BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalsDifference { get; set; }
        public int Percentage { get; set; }

    }
}
