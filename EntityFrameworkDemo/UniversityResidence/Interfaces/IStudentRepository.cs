using UniversityResidence.Models;

namespace UniversityResidence.Interfaces
{
    public interface IStudentRepository
    {
        Student Get(string jmbag);
    }
}
