using System;
using System.Collections.Generic;
using System.Linq;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;

namespace UniversityResidence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(UniversityResidenceDbContext context) : base(context, context.Employees)
        {
        }

        public Employee Get(string oib)
        {
            return _table.FirstOrDefault(e => e.Oib.Equals(oib));
        }

        public List<Employee> GetWorksAs(string position)
        {
            return _table.Where(e => e.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
