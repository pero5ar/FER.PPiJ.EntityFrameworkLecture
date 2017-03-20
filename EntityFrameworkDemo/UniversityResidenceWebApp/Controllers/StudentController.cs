using Microsoft.AspNetCore.Mvc;
using UniversityResidence.Interfaces;

namespace UniversityResidenceWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _students;

        public StudentController(IStudentRepository studentRepository)
        {
            _students = studentRepository;
        }

        public IActionResult Index()
        {
            return View(_students.GetAllWithRooms());
        }
    }
}
