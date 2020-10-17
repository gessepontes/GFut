namespace GFut.Application.ViewModels
{
    public class TopScorersViewModel : BaseEntity
    {
        public int Position { get; set; }
        public string Player { get; set; }
        public string Team { get; set; }
        public int Goals { get; set; }
    }
}
