using System;
using System.Collections.Generic;

namespace UniversityResidence.Interfaces
{
    public interface IGenericRepository<T>
    {
        bool Add(T item);
        void AddAll(IEnumerable<T> items);
        bool Update(T item);
        bool Remove(T item);
        List<T> GetWhere(Func<T, bool> filter);
        List<T> GetAll();
    }
}
