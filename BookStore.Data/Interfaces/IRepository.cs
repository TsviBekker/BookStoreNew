﻿using System;
using System.Collections.Generic;

namespace BookStore.Data.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IDataEntity
    {//repository = storage
        Guid Insert(T item);
        bool Delete(Guid id);
        T Update(T item);
        T Get(Guid id);
        IEnumerable<T> Get(Predicate<T> filter = null);
    }
}
