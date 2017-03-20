using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityResidence.Interfaces;

namespace UniversityResidence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        protected UniversityResidenceDbContext _context;
        protected IDbSet<T> _table;

        protected GenericRepository(UniversityResidenceDbContext context, IDbSet<T> table)
        {
            _context = context;
            _table = table;
        }

        public virtual bool Add(T item)
        {
            if (item == null) return false;
            _table.Add(item);
            _context.SaveChanges();
            return true;
        }

        public void AddAll(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (item == null) continue;
                _table.Add(item);
            }
            _context.SaveChanges();
        }

        public bool Update(T item)
        {
            if (item == null || !_table.Any(i => i.Equals(item))) return false;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool Remove(T item)
        {
            if (item == null || !_table.Any(i => i.Equals(item))) return false;
            _table.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public List<T> GetWhere(Func<T, bool> filter)
        {
            return _table.Where(filter).ToList();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }
    }
}
