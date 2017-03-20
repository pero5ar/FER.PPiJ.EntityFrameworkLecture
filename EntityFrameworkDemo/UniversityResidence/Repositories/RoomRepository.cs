using System;
using System.Collections.Generic;
using System.Linq;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;

namespace UniversityResidence.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository 
    {
        public RoomRepository(UniversityResidenceDbContext context) : base(context, context.Rooms)
        {
        }

        public Room Get(Guid id)
        {
            return _table.FirstOrDefault(r => r.Id.Equals(id));
        }

        public bool IsFull(Guid id)
        {
            var room = Get(id);
            return room.Occupants.Count == room.Capacity;
        }

        public List<Room> GetEmpty()
        {
            return _table.Where(r => r.Occupants.Count == 0).ToList();
        }

        public List<Room> GetFree()
        {
            return _table.Where(r => r.Occupants.Count < r.Capacity).ToList();
        }
    }
}
