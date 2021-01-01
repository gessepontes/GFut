using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IPageProfileRepository : IRepository<PageProfile> {
        Task<IEnumerable<PageProfile>> GetPageProfileByProfileId(int profileId);
    }
}
