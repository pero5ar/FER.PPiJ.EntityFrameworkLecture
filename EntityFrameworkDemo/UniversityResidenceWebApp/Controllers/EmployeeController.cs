using Microsoft.AspNetCore.Mvc;
using UniversityResidence.Interfaces;

namespace UniversityResidenceWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employees;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employees = employeeRepository;
        }

        public IActionResult Index()
        {
            return View(_employees.GetWithWorkPlace());
        }
    }
}
