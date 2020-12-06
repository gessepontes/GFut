using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void UpdateRange(IEnumerable<TEntity> list);
        void RemoveRange(IEnumerable<TEntity> list);
        void Remove(int id);
        int SaveChanges();
    }
}
