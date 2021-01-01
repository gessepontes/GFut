namespace GFut.Application.ViewModels
{
    public class PageProfileViewModel : BaseEntity
    {
        public int PageId { get; set; }
        public int ProfileId { get; set; }
        public virtual PageViewModel Page { get; set; }
    }
}
