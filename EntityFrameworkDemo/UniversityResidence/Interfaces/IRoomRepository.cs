using System;
using System.Collections.Generic;
using UniversityResidence.Models;

namespace UniversityResidence.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Room Get(Guid id);
        bool IsFull(Guid id);
        List<Room> GetEmpty();
        List<Room> GetFree();
        List<Room> GetWithOccupants();
    }
}
