﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void UpdateRange(IEnumerable<TEntity> list);
        void RemoveRange(IEnumerable<TEntity> list);
        void Remove(int id);
        int SaveChanges();
    }
}
