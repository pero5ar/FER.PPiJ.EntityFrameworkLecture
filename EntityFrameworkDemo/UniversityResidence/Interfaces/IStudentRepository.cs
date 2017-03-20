using System.Collections.Generic;
using UniversityResidence.Models;

namespace UniversityResidence.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student Get(string jmbag);
        List<Student> GetAllWithRooms();
    }
}
