using System;
using System.Collections.Generic;
using System.Linq;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;

namespace UniversityResidence.Repositories
{
    public class ResidenceHallRepository : GenericRepository<ResidenceHall>, IResidenceHallRepository
    {
        public ResidenceHallRepository(UniversityResidenceDbContext context) : base(context, context.Halls)
        {
        }

        public ResidenceHall Get(Guid id)
        {
            return _table.FirstOrDefault(h => h.Id.Equals(id));
        }

        public int CalculateCapacity(Guid id)
        {
            var hall = Get(id);
            return hall?.Rooms.Select(r => r.Capacity).Sum() ?? 0;
        }

        public List<Student> GetOccupants(Guid id)
        {
            var hall = Get(id);
            return hall?.Rooms.SelectMany(r => r.Occupants).ToList();
        }
    }
}
