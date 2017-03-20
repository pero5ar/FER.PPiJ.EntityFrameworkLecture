using System.Collections.Generic;
using UniversityResidence.Models;

namespace UniversityResidence.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee Get(string oib);
        List<Employee> GetWorksAs(string position);
        List<Employee> GetWithWorkPlace();
    }
}
