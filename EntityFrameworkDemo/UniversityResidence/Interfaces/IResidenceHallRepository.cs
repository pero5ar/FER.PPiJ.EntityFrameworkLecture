using System;
using System.Collections.Generic;
using UniversityResidence.Models;

namespace UniversityResidence.Interfaces
{
    public interface IResidenceHallRepository : IGenericRepository<ResidenceHall>
    {
        ResidenceHall Get(Guid id);
        int CalculateCapacity(Guid id);
        List<Student> GetOccupants(Guid id);
    }
}
