namespace GFut.Domain.Models
{
    public class PageProfile : BaseEntity
    {
        public int PageId { get; set; }
        public int ProfileId { get; set; }
        public virtual Page Page { get; set; }
    }
}
