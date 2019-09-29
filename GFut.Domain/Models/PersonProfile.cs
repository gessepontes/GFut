
using static GFut.Domain.Others.Enum;

namespace GFut.Domain.Models
{
    public class PersonProfile : BaseEntity
    {
        public ProfileType ProfileType { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
