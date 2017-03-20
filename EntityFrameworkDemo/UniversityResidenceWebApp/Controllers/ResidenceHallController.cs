using Microsoft.AspNetCore.Mvc;
using UniversityResidence.Interfaces;

namespace UniversityResidenceWebApp.Controllers
{
    public class ResidenceHallController : Controller
    {
        private readonly IResidenceHallRepository _halls;

        public ResidenceHallController(IResidenceHallRepository residenceHallRepository)
        {
            _halls = residenceHallRepository;
        }

        public IActionResult Index()
        {
            return View(_halls.GetAll());
        }
    }
}
