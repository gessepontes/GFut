using GFut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryRepository : IRepository<Horary> {
        Task<IEnumerable<Horary>> GetHoraryByFieldId(int fieldId);
        Task<IEnumerable<Horary>> GetAllHorary();

    }
}
