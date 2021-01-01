using System.Collections.Generic;

namespace GFut.Application.ViewModels
{
    public class PageViewModel : BaseEntity
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public bool Menu { get; set; }

        public int? ParentId { get; set; }
        public virtual ICollection<PageViewModel> Pages { get; set; }
    }
}
