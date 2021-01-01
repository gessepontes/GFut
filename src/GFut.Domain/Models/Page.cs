
using System.Collections.Generic;

namespace GFut.Domain.Models
{
    public class Page : BaseEntity
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public bool Menu { get; set; }

        public virtual Page PageNavigation { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<PageProfile> PageProfiles { get; set; }

    }
}
